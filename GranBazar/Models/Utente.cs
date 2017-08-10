using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GranBazar.Models
{
    [Table("Utente")]
    public partial class Utente
    {
        public Utente()
        {
            Ordine = new HashSet<Ordine>();
        }

        [Key]
        public string Email { get; set; }
        public string Ruolo { get; set; }
        public string Psw { get; set; }

        public virtual ICollection<Ordine> Ordine { get; set; }
    }
}
