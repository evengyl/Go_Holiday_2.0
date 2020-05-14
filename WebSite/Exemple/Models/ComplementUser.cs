using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ComplementUser
    {
        public string Gsm { get; set; }
        public string Phone { get; set; }
        public int Benefice { get; set; }
        public int TotalPrice_InLocate { get; set; }
        public int TotalPrice_InAttemps { get; set; }
    }
}
