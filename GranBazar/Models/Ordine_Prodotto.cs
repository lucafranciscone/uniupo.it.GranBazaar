using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GranBazar.Models
{
    /*
     * La classe rappresenta la relazione n-n tra Ordine e Prodotto, l'abbiamo trasformata in un model a se stante. 
     * 
     * */


    [Table("Ordine_Prodotto")]
    public partial class Ordine_Prodotto
    {

        public int IdOrdine { get; set; }
        public int IdProdotto { get; set; }
        public int Quantita { get; set; }

        public virtual Ordine IdOrdineNavigation { get; set; }//<-- Sono corretti?
        public virtual Prodotto IdProdottoNavigation { get; set; }//<-- Sono corretti?
    }
}
