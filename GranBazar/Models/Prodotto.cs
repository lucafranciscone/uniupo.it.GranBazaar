using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GranBazar.Models
{
    [Table("Prodotto")]
    public class Prodotto
    {
        [Key]
        public int IdProdotto { get; set; }

        public string NomeProdotto { get; set; }

        public string DesrizioneProgotto { get; set; }

        public Decimal Prezzo { get; set; }

        public Byte? Sconto  { get;set; }

        public String LinkImmagine { get; set; }

        public Boolean disponibile { get; set; }

        public ICollection<Contiene> Contiene { get; set; }
    }
}
