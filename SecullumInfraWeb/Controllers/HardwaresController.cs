using Microsoft.AspNetCore.Mvc;
using SecullumInfraWeb.Models;
using SecullumInfraWeb.Models.Enums;
using SecullumInfraWeb.Models.ViewModels;
using SecullumInfraWeb.Services;
using SecullumInfraWeb.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public async Task<IActionResult> Index()
        {
            var list = await _hardwareService.FindAllAsync();

            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var departments = await _departmentService.FindAllAsync();
            var viewModel = new HardwareFormViewModel { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Hardware hardware)
        {
            await _hardwareService.InsertAsync(hardware);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = await _hardwareService.FindByIdAsync(id.Value);
            
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
            try
            {
                await _hardwareService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = await _hardwareService.FindByIdAsync(id.Value);

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

            var obj = await _hardwareService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            List<Department> departments = await _departmentService.FindAllAsync();
            HardwareFormViewModel viewModel = new HardwareFormViewModel { Hardware = obj, Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Hardware hardware)
        {
            if (id != hardware.Id)
            {
                return BadRequest();
            }
            try
            {
                await _hardwareService.UpdateAsync(hardware);
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
            var result = await _hardwareService.FindByDateAsync(minDate, maxDate, searchString);
            
            return View(result);
        }
        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}