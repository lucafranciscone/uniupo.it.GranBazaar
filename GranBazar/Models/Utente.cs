using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GranBazar.Models
{
    [Table("Utente")]
    public class Utente
    {
        [Key]
        [StringLength(50)]
        public String Email { get; set; }
        public String Ruolo { get; set; }
        public string Psw { get; set; }

    }
}
