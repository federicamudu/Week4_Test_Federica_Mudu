using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test4.Opzionale.Core.Entities
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Descrizione { get; set; }

        public virtual IList<Spesa> Spese { get; set; }


        public Categoria(string descrizione) { Descrizione = descrizione; }
    }
}
