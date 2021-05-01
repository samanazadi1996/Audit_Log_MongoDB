using Audit.Client.Data.Services.AuditDomain;
using Audit.Client.Data.Services.DifferenceTwoObjectsDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audit.Client.Data.Services.LogChangesBettwenTwoEntityDomain
{
    public class LogChangesBettwenTwoEntity : ILogChangesBettwenTwoEntity
    {
        private readonly IGetDifferenceObjectService getDifferenceObjectService;
        private readonly IInsertAuditService insertAuditService;

        public LogChangesBettwenTwoEntity(IGetDifferenceObjectService getDifferenceObjectService, IInsertAuditService insertAuditService)
        {
            this.getDifferenceObjectService = getDifferenceObjectService;
            this.insertAuditService = insertAuditService;
        }

        public async Task<bool> LogWarning<T>(string userName, string key, string description, T oldValue, T newValue, params string[] propertyIgnore)
        {
            return await Log(Enums.AuditLevel.Warning, userName, key, description, oldValue, newValue, propertyIgnore);
        }

        public async Task<bool> LogInformation<T>(string userName, string key, string description, T oldValue, T newValue, params string[] propertyIgnore)
        {
            return await Log(Enums.AuditLevel.Information, userName, key, description, oldValue, newValue, propertyIgnore);
        }

        public async Task<bool> LogError<T>(string userName, string key, string description, T oldValue, T newValue, params string[] propertyIgnore)
        {
            return await Log(Enums.AuditLevel.Error, userName, key, description, oldValue, newValue, propertyIgnore);
        }

        public async Task<bool> Log<T>(Enums.AuditLevel level, string userName, string key, string description, T oldValue, T newValue, params string[] propertyIgnore)
        {
            var changes = await getDifferenceObjectService.Get(oldValue, newValue, propertyIgnore);
            var model = new Models.Audit()
            {
                Level = level,
                Messages = changes,
                UserName = userName,
                Key = key,
                Description = description
            };
            await insertAuditService.Insert(model);
            return true;
        }
    }
}
