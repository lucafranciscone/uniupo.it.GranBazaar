using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GranBazar.Models
{
    public partial class Carrello
    {
        public Carrello()
        {
            Contiene = new HashSet<Contiene>();
        }

        [Key]
        public int IdCarrello { get; set; }
        public DateTime DataCreazioneCarrello { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Contiene> Contiene { get; set; }
        public virtual Utente EmailNavigation { get; set; }
    }
}
