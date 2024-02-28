using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scarpe_Co.Models
{
    public class Utente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}