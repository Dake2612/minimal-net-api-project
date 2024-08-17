using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dario.Robles.Store.Service.Infrastructure.Persistence.Helpers.DataMapping.PropertyMapping
{
    public interface IPropertyMappingService<TSource, TDestination>
    {
        bool ValidMappingExistsFor(string fields);

        Dictionary<string, PropertyMappingValue> GetPropertyMapping();
    }
}
