using System;
using System.Collections.Generic;

namespace GranBazar.Models
{
    public partial class Utente
    {
        public Utente()
        {
            Ordine = new HashSet<Ordine>();
        }

        public string Email { get; set; }
        public string Ruolo { get; set; }
        public string Psw { get; set; }

        public virtual Carrello Carrello { get; set; }
        public virtual ICollection<Ordine> Ordine { get; set; }
    }
}
