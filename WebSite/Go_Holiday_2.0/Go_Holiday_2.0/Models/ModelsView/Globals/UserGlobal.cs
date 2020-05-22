using Go_Holiday_2._0.Models.ModelsView.Partials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Go_Holiday_2._0.Models.ModelsView.Globals
{
    public class UserGlobal
    {
        private BackgroundProfil _backgroundProfil;

        public BackgroundProfil BackgroundProfil
        {
            get { return _backgroundProfil ??= new BackgroundProfil(); }
            set { _backgroundProfil = value; }
        }


        public UserInfos UserInfos { get; set; }
    }
}
