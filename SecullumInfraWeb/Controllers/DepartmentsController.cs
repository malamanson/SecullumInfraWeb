using Microsoft.AspNetCore.Mvc;
using SecullumInfraWeb.Models;
using SecullumInfraWeb.Models.ViewModels;
using SecullumInfraWeb.Services;
using SecullumInfraWeb.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

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

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _departmentService.FindById(id.Value);
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
            try
            {
                _departmentService.Remove(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _departmentService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            DepartmentFormViewModel viewModel = new DepartmentFormViewModel { Department = obj};
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Department department)
        {
            if (id != department.Id)
            {
                return BadRequest();
            }
            try
            {
                _departmentService.Update(department);
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
