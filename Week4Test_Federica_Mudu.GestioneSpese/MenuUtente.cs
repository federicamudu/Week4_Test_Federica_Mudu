using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4Test_Federica_Mudu.GestioneSpese
{
    public class MenuUtente
    {
        internal static void Start()
        {
            bool continua = true;

            while (continua)
            {
                int scelta = SchermoMenu();
                continua = AnalizzaScelta(scelta);
            }
        }

        private static bool AnalizzaScelta(int scelta)
        {
            switch (scelta)
            {
                case 1:
                    DisconnectedMode.InsertSpesa();
                    break;
                case 2:
                    ConnectedMode.ApproveSpesa();
                    break;
                case 3:
                    ConnectedMode.DeleteSpesa();
                    break;
                case 4:
                    ConnectedMode.ShowSpeseApproved();
                    break;
                case 5:
                    ConnectedMode.ShowSpeseUser();
                    break;
                case 6:
                    ConnectedMode.TotSpeseByCategory();
                    break;
                case 7:
                    DisconnectedMode.FetchAllSpese();
                    break;
                case 0:
                    return false;
                default:
                    Console.WriteLine("Scelta errata. Inserisci scelta corretta: ");
                    break;
            }
            return true;
        }
        private static int SchermoMenu()
        {
            Console.WriteLine("******************MENU*****************");
            Console.WriteLine("[1] Inserisci Nuova Spesa");
            Console.WriteLine("[2] Approva Spese Esistenti");
            Console.WriteLine("[3] Cancella Spese Esistenti");
            Console.WriteLine("[4] Elenco Spese Approvate");
            Console.WriteLine("[5] Elenco Spese di un Utente");
            Console.WriteLine("[6] Totale delle Spese per una Categoria");
            Console.WriteLine("[7] Vedi la Lista Completa");
            Console.WriteLine();
            Console.WriteLine("[0] Esci");
            Console.WriteLine();

            int scelta;
            Console.WriteLine("Inserisci la tua scelta: ");
            while (!(int.TryParse(Console.ReadLine(), out scelta)))
            {
                Console.WriteLine("Scelta errata. Inserisci scelta corretta: ");
            };

            return scelta;
        }
    }
}
