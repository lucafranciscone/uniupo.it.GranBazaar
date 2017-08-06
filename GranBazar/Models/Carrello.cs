using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GranBazar.Models
{
    [Table("Carrello")]
    public class Carrello
    {
        public int IdCarrello { get; set; }
        public DateTime DataCreazioneCarrello { get; set; }

        public Utente utente { get; set; }

        public ICollection<Contiene> Contiene { get; set; }
     }
}
