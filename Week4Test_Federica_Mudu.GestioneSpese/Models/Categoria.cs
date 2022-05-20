using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4Test_Federica_Mudu.GestioneSpese.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Descrizione { get; set; }

        public virtual IList<Spesa> Spese { get; set; }
    }
}
