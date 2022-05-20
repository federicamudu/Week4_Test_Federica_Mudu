using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test4.Opzionale.Core.Entities;
using Test4.Opzionale.Core.InterfaceRepository;

namespace Test4.Opzionale.Core.BusinessLayer
{
    public class BusinessLayer : IBusinessLayer
    {
        private readonly IRepositorySpesa spesaRepo;
        private readonly IRepositoryCategoria categoriaRepo;

        public BusinessLayer(IRepositorySpesa spesa, IRepositoryCategoria categRepo)
        {
            spesaRepo = spesa; 
            categoriaRepo = categRepo;
        }

        public List<Categoria> FetchCategorie()
        {
            try
            {
                List<Categoria> categorie = categoriaRepo.Fetch();
                return categorie;
            }
            catch
            {
                return null;
            }
        }
        public List<Spesa> FetchSpese()
        {
            try 
            { 
                return spesaRepo.Fetch(); 
            } 
            catch 
            { 
                return null; 
            }
        }
        public bool EliminaSpese()
        {
            try 
            { 
                return spesaRepo.DeleteAll(); 
            } 
            catch 
            { 
                return false; 
            }
        }
        public bool AddSpesa(Spesa spesa)
        {
            try 
            { 
                return spesaRepo.Add(spesa); 
            } 
            catch 
            { 
                return false; 
            }
        }
        public List<Spesa> GetApprovate(bool approvato)
        {
            try 
            { 
                return spesaRepo.GetByApprovato(approvato); 
            } 
            catch 
            { 
                return null; 
            }
        }
        public bool CambiaApprovato(Spesa selezione)
        {
            try 
            { 
                return spesaRepo.UpdateApprovato(selezione); 
            } 
            catch 
            { 
                return false; 
            }
        }
        public List<Spesa> GetSpeseUtente(string utente)
        {
            try 
            { 
                return spesaRepo.GetByUtente(utente); 
            } 
            catch 
            { 
                return null; 
            }
        }
        public decimal GetTotaleByUtenteECategoria(string utente, Categoria categoria)
        {
            try 
            { 
                decimal res = spesaRepo.GetTotaleByUtenteECategoria(utente, categoria); 
                return res; 
            } 
            catch 
            { 
                return -1; 
            }
        }
    }
}
