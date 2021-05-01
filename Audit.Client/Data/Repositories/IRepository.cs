using Audit.Client.Data.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Audit.Client.Data.Repositories
{
    public interface IRepository
    {
        Task Add(Models.Audit audit);
        Task Delete(string id);

        Task<IEnumerable<Models.Audit>> Get(AuditLevel? auditLevel = null);
    }
}