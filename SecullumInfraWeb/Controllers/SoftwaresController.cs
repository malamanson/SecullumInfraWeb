using Microsoft.AspNetCore.Mvc;
using SecullumInfraWeb.Models;
using SecullumInfraWeb.Models.ViewModels;
using SecullumInfraWeb.Services;
using SecullumInfraWeb.Services.Exceptions;
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
        private readonly HardwareService _hardwareService;

        public SoftwaresController(SoftwareService softwareService, DepartmentService departmentService, HardwareService hardwareService)
        {
            _softwareService = softwareService;
            _departmentService = departmentService;
            _hardwareService = hardwareService;
        
        }

        public IActionResult Index()
        {
            var list = _softwareService.FindAll();

            return View(list);
        }

        public IActionResult Create()
        {
            var hardwares = _hardwareService.FindAll();
            var departments = _departmentService.FindAll();
            var viewModel = new SoftwareFormViewModel {  Departments = departments, Hardwares = hardwares };
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

        public IActionResult Details(int? id)
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

        public IActionResult Edit(int? id)
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
            List<Department> departments = _departmentService.FindAll();
            SoftwareFormViewModel viewModel = new SoftwareFormViewModel { Software = obj, Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Software software)
        {
            if (id != software.Id)
            {
                return BadRequest();
            }
            try
            {
                _softwareService.Update(software);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (DbConcurrencyException)
            {
                return BadRequest();
            }
        }
        public IActionResult Search(DateTime? minDate, DateTime maxDate, string searchString)
        {
            var result = _softwareService.FindByDate(minDate, maxDate, searchString);

            return View(result);
        }
    }
}
