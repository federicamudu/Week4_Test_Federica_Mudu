namespace Test4.Opzionale.Core.Entities
{
    public class Spesa
    {
        public int Id { get; set; }
        public DateTime DataSpesa { get; set; }
        public string Descrizione { get; set; }
        public string Utente { get; set; }
        public decimal Importo { get; set; }
        public bool Approvato { get; set; }


        public Spesa(DateTime dataSpesa, string descrizione, string utente, decimal importo, bool approvato = false)
        {
            DataSpesa = dataSpesa; Descrizione = descrizione; Utente = utente; Importo = importo; Approvato = approvato;
        }

        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}