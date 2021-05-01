using Audit.Client.Data.Repositories;
using System.Threading.Tasks;

namespace Audit.Client.Data.Services.AuditDomain
{
    public class InsertAuditService : IInsertAuditService
    {
        private readonly IRepository repository;

        public InsertAuditService(IRepository repository)
        {
            this.repository = repository;
        }
        public async Task<Models.Audit> Insert(Models.Audit audit)
        {
            await repository.Add(audit);
            return audit;
        }
    }
}
