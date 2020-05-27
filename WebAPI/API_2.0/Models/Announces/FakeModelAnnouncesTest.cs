using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_2.Models.Announces
{
    public class FakeModelAnnouncesTest
    {
        public Announces announce = new Announces
        {
            AnnID = 14,
            Name = "Test fake update",
            SubName = " Test Fake",
            Desc = "Test fake",
            UserID = 1,
            StartDate = DateTime.Now,
            EndDate = DateTime.Now,
            Vues = 15,
            UserValid = false,
            AdminValid = false,
            CreateDate = DateTime.Now,
            AddressPays = " Test Fake",
            AddressVille = " Test Fake",
            AddressRue = " Test Fake",
            AddressCodePostal = " Test Fake",
            AddressNumero = " Test Fake",

        };

        public Announces annonce {
            get;
            set;
        }

        public FakeModelAnnouncesTest()
        {
            announce.ListSport = new List<Sport>();
            announce.ListActivity = new List<Activity>();
            announce.TypeHabitat = new TypeHabitat();
            announce.ListTypeHoliday = new List<TypeHoliday>();
            announce.ListCommoditer = new List<Commoditer>();

            Sport sport1 = new Sport { SportID = 4 };
            Sport sport2 = new Sport { SportID = 3 };


            Activity Activity1 = new Activity { ActivityID = 2 };
            Activity Activity2 = new Activity { ActivityID = 3 };


            TypeHabitat habitat = new TypeHabitat { TypeID = 4 };

            TypeHoliday holiday1 = new TypeHoliday { TypeID = 3 };
            TypeHoliday holiday2 = new TypeHoliday { TypeID = 2 };

            Commoditer com1 = new Commoditer { ComID = 3 };
            Commoditer com2 = new Commoditer { ComID = 2 };


            announce.ListSport.Add(sport1);
            announce.ListSport.Add(sport2);

            announce.ListActivity.Add(Activity1);
            announce.ListActivity.Add(Activity2);

            announce.TypeHabitat = habitat;

            announce.ListTypeHoliday.Add(holiday1);
            announce.ListTypeHoliday.Add(holiday2);

            announce.ListCommoditer.Add(com1);
            announce.ListCommoditer.Add(com2);
        }
    }
}
