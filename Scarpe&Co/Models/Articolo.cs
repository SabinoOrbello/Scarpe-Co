using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scarpe_Co.Models
{
    public class Articolo
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Prezzo { get; set; }
        public string DescrizioneDettagliata { get; set; }
        public bool InVendita { get; set; }
        public string ImmagineCopertina { get; set; }
        public string ImmagineAggiuntiva1 { get; set; }
        public string ImmagineAggiuntiva2 { get; set; }

    }
}