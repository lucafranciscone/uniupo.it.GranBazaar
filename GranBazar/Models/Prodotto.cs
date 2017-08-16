using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GranBazar.Models
{
    [Table("Prodotto")]
    public partial class Prodotto
    {
        public Prodotto()
        {
            OrdineProdotto = new HashSet<Ordine_Prodotto>();
        }

        [Key]
        public int IdProdotto { get; set; }
        public string NomeProdotto { get; set; }
        public string DescrizioneProdotto { get; set; }
        public decimal Prezzo { get; set; }
        public byte? Sconto { get; set; }
        public string LinkImmagine { get; set; }
        public bool Disponibile { get; set; }

        public virtual ICollection<Ordine_Prodotto> OrdineProdotto { get; set; }
    }
}
