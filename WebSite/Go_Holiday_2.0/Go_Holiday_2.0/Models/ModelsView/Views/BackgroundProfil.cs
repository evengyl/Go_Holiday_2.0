using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Go_Holiday_2._0.Models.ModelsView.Views
{
    public class BackgroundProfil
    {
        private List<string> _url;
        private List<string> _shortUrl;

        public List<string> Url
        {
            get { return _url ??= new List<string>(); }
            set { _url = value; }
        }

        public List<string> ShortUrl
        {
            get { return _shortUrl ??= new List<string>(); }
            set { _shortUrl = value; }
        }

    }
}
