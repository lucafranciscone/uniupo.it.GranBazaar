using System;
using System.Collections.Generic;

namespace GranBazar.Models
{
    public partial class Prodotto
    {
        public Prodotto()
        {
            Contiene = new HashSet<Contiene>();
        }

        public int IdProdotto { get; set; }
        public string NomeProdotto { get; set; }
        public string DescrizioneProdotto { get; set; }
        public decimal Prezzo { get; set; }
        public byte? Sconto { get; set; }
        public string LinkImmagine { get; set; }
        public bool Disponibile { get; set; }

        public virtual ICollection<Contiene> Contiene { get; set; }
    }
}
