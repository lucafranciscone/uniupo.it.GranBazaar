using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GranBazar.Models
{
    [Table("Ordine")]
    public partial class Ordine
    {
        public Ordine()
        {
            Ordine_Prodotto = new HashSet<Ordine_Prodotto>();
        }

        [Key]
        public int IdOrdine { get; set; }
        public DateTime DataOrdine { get; set; }
        public string Stato { get; set; }
        public DateTime? DataSpedizione { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Ordine_Prodotto> Ordine_Prodotto { get; set; }
        public virtual Utente EmailNavigation { get; set; }
    }
}
