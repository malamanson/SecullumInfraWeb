using Microsoft.AspNetCore.Mvc;
using SecullumInfraWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecullumInfraWeb.Controllers
{
    public class SoftwaresController : Controller
    {
        private readonly SoftwareService _softwareService;

        public SoftwaresController(SoftwareService softwareService)
        {
            _softwareService = softwareService;
        }

        public IActionResult Index()
        {
            var list = _softwareService.FindAll();

            return View(list);
        }
         public IActionResult Create()
        {
            return View();
        }
    }
}
