using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test4.Opzionale.Core.Entities;

namespace Test4.Opzionale.Core.InterfaceRepository
{
    public interface IRepositorySpesa : IRepository<Spesa>
    {
        List<Spesa> GetByApprovato(bool approvato);
        bool UpdateApprovato(Spesa spesa);
        bool DeleteAll();
        List<Spesa> GetByUtente(string utente);
        decimal GetTotaleByUtenteECategoria(string utente, Categoria categoria);
    }
}
