using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test4.Opzionale.Core.Entities;
using Test4.Opzionale.Core.InterfaceRepository;

namespace Test4.Opzionale.RepositoryEF
{
    public class RepositorySpesaEF : IRepositorySpesa
    {
        public List<Spesa> Fetch()
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Spese.Include(s => s.Categoria).ToList();
            }
            
        }
        public bool DeleteAll()
        {
            using (var ctx = new MasterContext())
            {
                ctx.Spese.RemoveRange(ctx.Spese);
                int success = ctx.SaveChanges();
                if (success != 0) return true; else return false;
            }
            
        }
        public bool Add(Spesa item)
        {
            using (var ctx = new MasterContext())
            {
                var nuovaSpesa = new Spesa
                {
                    DataSpesa = item.DataSpesa,
                    Descrizione = item.Descrizione,
                    Utente = item.Utente,
                    Importo = item.Importo,
                    Approvato = item.Approvato,
                    CategoriaId = item.Categoria.Id
                };
                ctx.Add(nuovaSpesa);
                int success = ctx.SaveChanges();
                if (success != 0) return true;
                else return false;
            }
            
        }
        public bool UpdateApprovato(Spesa spesa)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Spese.Single(s => s.Id == spesa.Id).Approvato = !spesa.Approvato;
                int success = ctx.SaveChanges();
                if (success != 0) return true; else return false;
            }
            
        }
        public List<Spesa> GetByApprovato(bool approvato)
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Spese.Where(s => s.Approvato == approvato).Include(s => s.Categoria).ToList();
            }
            
        }
        public List<Spesa> GetByUtente(string utente)
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Spese.Where(s => s.Utente == utente).Include(s => s.Categoria).ToList();
            }
            
        }
        public decimal GetTotaleByUtenteECategoria(string utente, Categoria categoria)
        {
            using (var ctx = new MasterContext())
            {
                decimal totale = 0;
                List<Spesa> spese = ctx.Spese.Where(s => s.Utente == utente).Where(s => s.CategoriaId == categoria.Id).ToList();

                foreach (Spesa spesa in spese)
                {
                    totale += spesa.Importo;
                }
                return totale;
            }
            
        }
    }
}
