using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Go_Holiday_2._0.Models.ModelsAPI
{
    public class UserAPI
    {
        public int UserID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }

        //for models Uniquement
        public string Password { get; set; }
    }
}
