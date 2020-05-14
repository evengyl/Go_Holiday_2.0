using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public AddressUser AddressUser { get; set; }
        public ComplementUser ComplementUser { get; set; }

        //for models Uniquement
        public string Password { get; set; }
    }
}
