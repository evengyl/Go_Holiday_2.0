using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.Announces
{
    public class Announces
    {
        public int AnnID { get; set; }
        public string Name { get; set; }
        public string SubName { get; set; }
        public string Desc { get; set; }
        public int UserID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Vues { get; set; }
        public bool UserValid { get; set; }
        public bool AdminValid { get; set; }
        public DateTime CreateDate { get; set; }
        public string AddressPays { get; set; }
        public string AddressVille { get; set; }
        public string AddressCodePostal { get; set; }
        public string AddressRue { get; set; }
        public string AddressNumero { get; set; }


        /* liste des MTM et OTM */

        public List<Sport> ListSport { get; set; }
        public List<Activity> ListActivity { get; set; }
        public List<Commoditer> ListCommoditer { get; set; }
        public List<TypeHoliday> ListTypeHoliday { get; set; }
        public TypeHabitat TypeHabitat { get; set; }

    }
}
