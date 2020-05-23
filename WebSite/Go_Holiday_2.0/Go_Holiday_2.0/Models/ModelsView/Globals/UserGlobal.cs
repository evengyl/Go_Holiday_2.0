using ModelsView_Forms = Go_Holiday_2._0.Models.ModelsView.Forms;
using ModelsView_Views = Go_Holiday_2._0.Models.ModelsView.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Go_Holiday_2._0.Models.ModelsView.Globals
{
    public class UserGlobal
    {
        private ModelsView_Views.BackgroundProfil _backgroundProfil;

        public ModelsView_Views.BackgroundProfil BackgroundProfil
        {
            get { return _backgroundProfil ??= new ModelsView_Views.BackgroundProfil(); }
            set { _backgroundProfil = value; }
        }


        public ModelsView_Views.UserInfos UserInfos { get; set; }
    }
}
