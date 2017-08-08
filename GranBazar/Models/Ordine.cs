using System;
using System.Collections.Generic;

namespace GranBazar.Models
{
    public partial class Ordine
    {
        public int IdOrdine { get; set; }
        public DateTime DataOrdine { get; set; }
        public string Stato { get; set; }
        public DateTime? DataSpedizione { get; set; }
        public string Email { get; set; }

        public virtual Contiene Contiene { get; set; }
        public virtual Utente EmailNavigation { get; set; }
    }
}
