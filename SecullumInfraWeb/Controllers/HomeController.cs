using Microsoft.AspNetCore.Mvc;
using SecullumInfraWeb.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using SecullumInfraWeb.Models.ViewModels;

namespace SecullumInfraWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Secullum Infra Web Version 1.0.0";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Wiliam Maciel(Malamanson)";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
