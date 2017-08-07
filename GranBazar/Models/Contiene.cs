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
        public Carrello Carrello { get;set; }

        public Prodotto Prodotto { get; set; }

        public Ordine Ordine { get; set; }

    }
}
