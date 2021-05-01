using Audit.Client.Data.Enums;
using System.Threading.Tasks;

namespace Audit.Client.Data.Services.LogChangesBettwenTwoEntityDomain
{
    public interface ILogChangesBettwenTwoEntity
    {
        Task<bool> Log<T>(AuditLevel level, string userName, string key, string description, T oldValue, T newValue, params string[] propertyIgnore);
        Task<bool> LogError<T>(string userName, string key, string description, T oldValue, T newValue, params string[] propertyIgnore);
        Task<bool> LogInformation<T>(string userName, string key, string description, T oldValue, T newValue, params string[] propertyIgnore);
        Task<bool> LogWarning<T>(string userName, string key, string description, T oldValue, T newValue, params string[] propertyIgnore);
    }
}