using System;
using System.Collections.Generic;

namespace GranBazar.Models
{
    public partial class Contiene
    {
        public int IdCarrello { get; set; }
        public int IdProdotto { get; set; }
        public int IdOrdine { get; set; }

        public virtual Carrello IdCarrelloNavigation { get; set; }
        public virtual Ordine IdOrdineNavigation { get; set; }
        public virtual Prodotto IdProdottoNavigation { get; set; }
    }
}
