﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }

        public string Gsm { get; set; }
        public string Phone { get; set; }
        public int TypeUser { get; set; }



        public string Rue { get; set; }
        public string Ville { get; set; }
        public string Pays { get; set; }
        public string Numero { get; set; }
        public int CodePostal { get; set; }
        //for models Uniquement
        public string Password { get; set; }
    }
}
