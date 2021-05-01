using System.Threading.Tasks;

namespace Audit.Client.Data.Services.AuditDomain
{
    public interface IInsertAuditService
    {
        Task<Models.Audit> Insert(Models.Audit audit);
    }
}