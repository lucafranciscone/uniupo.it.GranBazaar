using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GranBazar.Models
{
    [Table("Contiene")]
    public class Contiene
    {
        public Carrello IdCarrello { get;set; }
        public Prodotto IdProdotto { get; set; }
        public Ordine IdOrdine { get; set; }

    }
}
