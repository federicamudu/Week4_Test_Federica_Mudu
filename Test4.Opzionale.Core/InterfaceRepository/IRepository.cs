using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test4.Opzionale.Core.InterfaceRepository
{
    public interface IRepository<T>
    {
        List<T> Fetch();
        bool Add(T item);
    }
}
