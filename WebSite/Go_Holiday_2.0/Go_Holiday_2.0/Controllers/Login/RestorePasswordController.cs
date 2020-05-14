using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Go_Holiday_2._0.Controllers.Login
{
    public class RestorePasswordController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}