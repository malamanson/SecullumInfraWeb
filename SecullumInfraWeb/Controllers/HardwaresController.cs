using Microsoft.AspNetCore.Mvc;
using SecullumInfraWeb.Models;
using SecullumInfraWeb.Models.Enums;
using SecullumInfraWeb.Models.ViewModels;
using SecullumInfraWeb.Services;
using SecullumInfraWeb.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecullumInfraWeb.Controllers
{
    public class HardwaresController : Controller
    {
        private readonly HardwareService _hardwareService;
        private readonly DepartmentService _departmentService;

        public HardwaresController(HardwareService hardwareService, DepartmentService departmentService)
        {
            _hardwareService = hardwareService;
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            var list = _hardwareService.FindAll();

            return View(list);
        }

        public IActionResult Create()
        {
            var departments = _departmentService.FindAll();
            var viewModel = new HardwareFormViewModel { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Hardware hardware)
        {
            _hardwareService.Insert(hardware);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _hardwareService.FindById(id.Value);
            
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
            _hardwareService.Remone(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _hardwareService.FindById(id.Value);

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

            var obj = _hardwareService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            List<Department> departments = _departmentService.FindAll();
            HardwareFormViewModel viewModel = new HardwareFormViewModel { Hardware = obj, Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Hardware hardware)
        {
            if (id != hardware.Id)
            {
                return BadRequest();
            }
            try
            {
                _hardwareService.Update(hardware);
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
            var result = _hardwareService.FindByDate(minDate, maxDate, searchString);
            
            return View(result);
        }
    }
}