using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Go_Holiday_2._0.Controllers.Search
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}