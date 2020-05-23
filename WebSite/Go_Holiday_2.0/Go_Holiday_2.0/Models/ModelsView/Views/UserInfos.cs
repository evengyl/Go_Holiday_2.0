using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Go_Holiday_2._0.Models.ModelsView.Views
{
    public class UserInfos
    {
        public string UserID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Rue { get; set; }
        public string Ville { get; set; }
        public string Pays { get; set; }
        public string Numero { get; set; }
        public int CodePostal { get; set; }
        public string Gsm { get; set; }
        public string Phone { get; set; }
        public string TypeUser { get; set; }
    }
}
