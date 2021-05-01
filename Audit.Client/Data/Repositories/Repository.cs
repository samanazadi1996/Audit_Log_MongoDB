using Audit.Client.Data.Enums;
using Audit.Client.Data.Settings;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Audit.Client.Data.Repositories
{
    public class Repository : IRepository
    {
        private readonly IMongoCollection<Models.Audit> _audits;

        public Repository(DbSettings dbSettings)
        {
            var client = new MongoClient(dbSettings.ConnectionString);
            var database = client.GetDatabase(dbSettings.DatabaseName);

            _audits = database.GetCollection<Models.Audit>(dbSettings.AuditCollectionName);
        }

        public async Task Add(Models.Audit audit)
        {
            await _audits.InsertOneAsync(audit);
        }

        public async Task Delete(string id)
        {
            await _audits.FindOneAndDeleteAsync(p => p.Id.Equals(id));
        }

        public async Task<IEnumerable<Models.Audit>> Get(AuditLevel? auditLevel = null)
        {
            var query = _audits.AsQueryable();
            if (auditLevel is not null)
            {
                query = query.Where(p => p.Level.Equals(auditLevel));
            }
            return await query.ToListAsync();
        }
    }
}
