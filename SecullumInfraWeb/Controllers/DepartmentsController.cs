using Microsoft.AspNetCore.Mvc;
using SecullumInfraWeb.Models;
using SecullumInfraWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecullumInfraWeb.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly DepartmentService _departmentService;
         
        public DepartmentsController(DepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            var list = _departmentService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Department department)
        {
            _departmentService.Insert(department);
            return RedirectToAction(nameof(Index));
        }
    }
}
