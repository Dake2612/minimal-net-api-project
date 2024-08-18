using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dario.Robles.Store.Service.Infrastructure.Persistence.Helpers.DataMapping.TypeHelper
{
    public interface ITypeHelperService
    {
        bool TypeHasProperties<T>(string fields);
    }
}
