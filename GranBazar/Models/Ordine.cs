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
            OrdineProdotto = new HashSet<OrdineProdotto>();
        }

        [Key]
        public int IdOrdine { get; set; }
        public DateTime DataOrdine { get; set; }
        public string Stato { get; set; }
        public DateTime? DataSpedizione { get; set; }
        public string Email { get; set; }

        public virtual ICollection<OrdineProdotto> OrdineProdotto { get; set; }
        public virtual Utente EmailNavigation { get; set; }
    }
}
