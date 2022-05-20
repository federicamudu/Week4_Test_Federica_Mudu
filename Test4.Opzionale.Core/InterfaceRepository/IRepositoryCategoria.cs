using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test4.Opzionale.Core.Entities;

namespace Test4.Opzionale.Core.InterfaceRepository
{
    public interface IRepositoryCategoria 
    {
        List<Categoria> Fetch();
    }
}
