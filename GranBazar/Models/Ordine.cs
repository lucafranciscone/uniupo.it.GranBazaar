using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GranBazar.Models
{
    [Table("Ordine")]
    public class Ordine
    {
        [Key]
        public int IdOrdine { get; set; }
        public DateTime DataOrdine { get; set; }
        public string Stato { get; set; }
        public System.Nullable<DateTime> DataSpedizione {get;set;}

        public Utente Utente { get; set; }




    }
}
