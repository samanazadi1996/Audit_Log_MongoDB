using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Audit.Client.Data.Services.DifferenceTwoObjectsDomain
{
    public class GetDifferenceObjectService : IGetDifferenceObjectService
    {
        public Task<IList<string>> Get<T>(T oldValue, T newValue, params string[] propertyIgnore)
        {
            var oType = oldValue.GetType();
            IList<string> changes = new List<string>();
            foreach (var oProperty in oType.GetProperties())
            {
                var oOldValue = oProperty.GetValue(oldValue, null);
                var oNewValue = oProperty.GetValue(newValue, null);
                // this will handle the scenario where either value is null
                if (!Equals(oOldValue, oNewValue) && !propertyIgnore.Any(p => p.Equals(oProperty.Name)))
                {
                    // Handle the display values when the underlying value is null
                    var sOldValue = oOldValue == null ? "null" : oOldValue.ToString();
                    var sNewValue = oNewValue == null ? "null" : oNewValue.ToString();

                    changes.Add($"Property {oProperty.Name} was: {sOldValue}; is: {sNewValue}");
                }
            }
            return Task.FromResult(changes);
        }

    }
}
