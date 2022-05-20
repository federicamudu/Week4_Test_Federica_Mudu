using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test4.Opzionale.Core.BusinessLayer;
using Test4.Opzionale.Core.Entities;
using Test4.Opzionale.RepositoryEF;

namespace Test4.Opzionale.Presentation
{
    public class Menu
    {
        private static readonly IBusinessLayer bl = new BusinessLayer(new RepositorySpesaEF(), new RepositoryCategoriaEF());
        public static void Start()
        {           

            bool keepGoing = true;
            int pick;

            Console.WriteLine("*** Benvenuto ***");
            do
            {
                Console.WriteLine("\nSeleziona l'operazione da eseguire:" +
                    "\n0 - Uscire" +
                    "\n1 - Inserire una nuova spesa" +
                    "\n2 - Approva una spesa" +
                    "\n3 - Cancella tutte le spese" + //DeleteRange
                    "\n4 - Mostra tutte le spese approvate" +
                    "\n5 - Elenca le spese di un utente" +
                    "\n6 - Mostra il totale delle spese per Utente e per Categoria");

                while (!int.TryParse(Console.ReadLine(), out pick) || pick < 0 || pick > 7)
                {
                    Console.WriteLine("\nInserisci una scelta valida.");
                }

                switch (pick)
                {
                    case 0:
                        Console.WriteLine("\n*** Arrivederci ***");
                        keepGoing = !keepGoing;
                        break;
                    case 1:
                        //AggiungiSpesa();
                        break;
                    case 2:
                        //ApprovaSpesa();
                        break;
                    case 3:
                        //CancellaSpese();
                        break;
                    case 4:
                        //MostraApprovate();
                        break;
                    case 5:
                        //MostraSpeseUtente();
                        break;
                    case 6:
                        //MostraTotaleUtenteCategoria();
                        break;
                        case 7:
                        //MostraTutto();
                        break;
                    default:
                        break;
                }
            } while (keepGoing);
        }

        private static void MostraTutto()
        {
            bl.FetchSpese();
        }

        private static void AggiungiSpesa()
        {
            DateTime data = GetDateTime();
            String descrizione = GetString("Descrizione", 500);
            string utente = GetString("Utente", 100);
            decimal importo = GetDecimal("Importo");
            Categoria categoria = GetCategoria();
            if (categoria != null)
            {
                Spesa spesa = new Spesa(data, descrizione, utente, importo);
                spesa.Categoria = categoria;
                bool success = bl.AddSpesa(spesa);
                if (success)
                    Console.WriteLine("\nInserimento avvenuto");
                else Console.WriteLine("\nErrore nell'inserimento spesa");
            }
            else Console.WriteLine("\nErrore nella scelta della Categoria.");
        }
        private static void ApprovaSpesa()
        {
            List<Spesa> spese = bl.GetApprovate(false);
            if (spese.Count == 0) Console.WriteLine("\nNon ci sono spese da approvare.");
            else if (spese == null) Console.WriteLine("\nErrore nel reperimento dati.");
            else
            {
                int count = 1;
                int pick;

                foreach (Spesa spesa in spese)
                {
                    Console.WriteLine($"\nPremi {count} per {spesa.Descrizione} - {spesa.Importo}");
                    count++;
                }
                while (!int.TryParse(Console.ReadLine(), out pick) || pick < 1 || pick > spese.Count)
                {
                    Console.WriteLine("\nInserisci una scelta valida.");
                }

                Spesa selezione = spese.ElementAt(pick - 1);
                bool success = bl.CambiaApprovato(selezione);

                if (success) Console.WriteLine("\nCambiamento avvenuto");
                else { Console.WriteLine("\nErrore nel reperimento dati."); }
            }
        }
        private static void CancellaSpese()
        {
            bool success = bl.EliminaSpese();
            if (success)
                Console.WriteLine("\nEliminazione Avvenuta");
            else Console.WriteLine("\nErrore nell'eliminazione di tutte le spese.");
        }
        private static void MostraApprovate()
        {
            List<Spesa> spese = bl.GetApprovate(true);
            if (spese.Count == 0) Console.WriteLine("\nNon ci sono spese approvate.");
            if (spese == null) Console.WriteLine("\nErrore nel reperimento dati.");
            else
            {
                foreach (Spesa spesa in spese)
                {
                    Console.WriteLine($"Spesa: {spesa.Descrizione} - {spesa.Importo} - con Categoria: {spesa.Categoria.Descrizione}");
                }
            }
        }
        private static void MostraSpeseUtente()
        {

            string utente = GetUtente();
            if (utente != null)
            {
                List<Spesa> speseUtente = bl.GetSpeseUtente(utente);
                if (speseUtente == null) Console.WriteLine("\nErrore nel reperimento dati");
                else if (speseUtente.Count == 0) Console.WriteLine("\nNon vi sono spese per l'utente selezionato");
                else
                {
                    Console.WriteLine("\nDi seguito le spese di " + utente);
                    foreach (Spesa spesa in speseUtente)
                    {
                        Console.WriteLine($"{spesa.Descrizione} - {spesa.Importo}");
                    }
                }
            }

        }
        private static void MostraTotaleUtenteCategoria()
        {
            string utente = GetUtente();
            Categoria categoria = GetCategoria();
            decimal totale = bl.GetTotaleByUtenteECategoria(utente, categoria);
            if (totale == 0) Console.WriteLine($"\nNon ci sono spese registrate per l'utente {utente} e la categoria {categoria.Descrizione} ");
            else if (totale == -1) Console.WriteLine("\nErrore nel reperimento dati");
            else
            {
                Console.WriteLine($"Il totale delle spese per l'utente {utente} di categoria {categoria.Descrizione} ammonta a EUR {totale}");
            }
        }

        ///Utils
        private static string GetString(string keyword, int maxRange)
        {
            string toReturn = null;

            Console.WriteLine($"\nInserisci {keyword}");
            toReturn = Console.ReadLine().Trim();
            while (toReturn.Length <= 0 || toReturn.Length > maxRange)
            {
                Console.WriteLine("\nInserisci una scelta valida");

            }

            return toReturn;
        }
        private static decimal GetDecimal(string keyword)
        {
            decimal toReturn;

            Console.WriteLine($"\nInserisci {keyword}");
            while (!decimal.TryParse(Console.ReadLine(), out toReturn) || toReturn <= 0)
            {
                Console.WriteLine("\nInserisci una scelta valida");
            }

            return toReturn;
        }
        private static DateTime GetDateTime()
        {
            DateTime toReturn;

            Console.WriteLine("\nInserisci una data (anno-mese-giorno)");
            while (!DateTime.TryParse(Console.ReadLine(), out toReturn) || toReturn > DateTime.Now)
            {
                Console.WriteLine("\nInserisci una scelta valida.");
            }

            return toReturn;
        }
        private static string GetUtente()
        {
            List<Spesa> spese = bl.FetchSpese();
            if (spese == null) Console.WriteLine("\nErrore nel reperimento dati");
            else if (spese.Count == 0) Console.WriteLine("\nNon vi sono Spese in lista");
            else
            {
                int count = 1;
                int pick;
                List<string> utenti = new List<string>();

                foreach (Spesa spesa in spese)
                {
                    if (!utenti.Contains(spesa.Utente))
                    {
                        utenti.Add(spesa.Utente);
                        Console.WriteLine($"\nPremi {count} per {spesa.Utente}");
                        count++;
                    }
                }
                while (!int.TryParse(Console.ReadLine(), out pick) || pick < 1 || pick > spese.Count)
                {
                    Console.WriteLine("\nInserisci una scelta valida.");
                }

                return utenti.ElementAt(pick - 1);
            }
            return null;
        }
        private static Categoria GetCategoria()
        {
            List<Categoria> categorie = bl.FetchCategorie();
            if (categorie == null) { Console.WriteLine("\nErrore nel reperimento dati."); return null; }
            else if (categorie.Count == 0) { Console.WriteLine("\nNon ci sono elementi desiderati in lista."); return null; }
            else
            {
                int count = 1;
                int pick;

                foreach (Categoria categoria in categorie)
                {
                    Console.WriteLine($"\nPremi {count} per {categoria.Descrizione}");
                    count++;
                }
                while (!int.TryParse(Console.ReadLine(), out pick) || pick < 1 || pick > categorie.Count)
                {
                    Console.WriteLine("\nInserisci una scelta valida.");
                }

                return categorie.ElementAt(pick - 1);
            }
        }
    }
}
