using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test4.Opzionale.Core.Entities;
using Test4.Opzionale.Core.InterfaceRepository;

namespace Test4.Opzionale.RepositoryEF
{
    public class RepositoryCategoriaEF : IRepositoryCategoria
    {
        public List<Categoria> Fetch()
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Categorie.ToList();
            }                
        }
    }
}
