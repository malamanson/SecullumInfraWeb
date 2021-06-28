using Microsoft.AspNetCore.Mvc;
using SecullumInfraWeb.Models;
using SecullumInfraWeb.Models.ViewModels;
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
        private readonly DepartmentService _departmentService;

        public SoftwaresController(SoftwareService softwareService, DepartmentService departmentService)
        {
            _softwareService = softwareService;
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            var list = _softwareService.FindAll();

            return View(list);
        }
        
        public IActionResult Create()
        {
            var departments = _departmentService.FindAll();
            var viewModel = new SoftwareFormViewModel { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Software software)
        {
            _softwareService.Insert(software);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _softwareService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _softwareService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
