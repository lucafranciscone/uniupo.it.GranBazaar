using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GranBazar.Models
{
    [Table("OrdineProdotto")]
    public partial class OrdineProdotto
    {

        public int IdOrdine { get; set; }
        public int IdProdotto { get; set; }
        public int Quantita { get; set; }

        public virtual Ordine IdOrdineNavigation { get; set; }
        public virtual Prodotto IdProdottoNavigation { get; set; }
    }
}
