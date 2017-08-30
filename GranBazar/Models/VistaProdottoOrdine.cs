using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GranBazar.Models
{
    public class VistaProdottoOrdine
    {
        public int IdOrdine { get; set; }
        public DateTime DataOrdine { get; set; }
        public string Stato { get; set; }
        public DateTime? DataSpedizione { get; set; }

        public int Quantita { get; set; }

        public int IdProdotto { get; set; }
        public string NomeProdotto { get; set; }
        public string DescrizioneProdotto { get; set; }
        public decimal Prezzo { get; set; }
        public byte? Sconto { get; set; }
        public string LinkImmagine { get; set; }

        public String Email { get; set; }

    }
}
