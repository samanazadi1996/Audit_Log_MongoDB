using System.Collections.Generic;
using System.Threading.Tasks;

namespace Audit.Client.Data.Services.DifferenceTwoObjectsDomain
{
    public interface IGetDifferenceObjectService
    {
        Task<IList<string>> Get<T>(T oldValue, T newValue, params string[] propertyIgnore);
    }
}