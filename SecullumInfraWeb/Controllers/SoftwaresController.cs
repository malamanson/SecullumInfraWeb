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

        public async Task<IActionResult> Index()
        {
            var list = await _softwareService.FindAllAsync();

            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var hardwares = await _hardwareService.FindAllAsync();
            var departments = await _departmentService.FindAllAsync();
            var viewModel = new SoftwareFormViewModel {  Departments = departments, Hardwares = hardwares };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Software software)
        {
            await _softwareService.InsertAsync(software);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = await _softwareService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _softwareService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = await _softwareService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = await _softwareService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            List<Department> departments = await _departmentService.FindAllAsync();
            List<Hardware> hardwares = await _hardwareService.FindAllAsync();
            SoftwareFormViewModel viewModel = new SoftwareFormViewModel { Software = obj, Hardwares = hardwares, Departments = departments};
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Software software)
        {
            if (id != software.Id)
            {
                return BadRequest();
            }
            try
            {
                await _softwareService.UpdateAsync(software);
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
        public async Task<IActionResult> Search(DateTime? minDate, DateTime maxDate, string searchString)
        {
            var result = await _softwareService.FindByDateAsync(minDate, maxDate, searchString);

            return View(result);
        }
    }
}
