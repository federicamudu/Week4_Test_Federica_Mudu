using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test4.Opzionale.Core.Entities;

namespace Test4.Opzionale.Core.BusinessLayer
{
    public interface IBusinessLayer
    {
        List<Categoria> FetchCategorie();
        List<Spesa> FetchSpese();
        bool EliminaSpese();
        bool AddSpesa(Spesa spesa);
        List<Spesa> GetApprovate(bool approvato);
        bool CambiaApprovato(Spesa selezione);
        List<Spesa> GetSpeseUtente(string utente);
        decimal GetTotaleByUtenteECategoria(string utente, Categoria categoria);
    }
}
