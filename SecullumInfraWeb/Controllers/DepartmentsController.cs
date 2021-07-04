using Microsoft.AspNetCore.Mvc;
using SecullumInfraWeb.Models;
using SecullumInfraWeb.Models.ViewModels;
using SecullumInfraWeb.Services;
using SecullumInfraWeb.Services.Exceptions;
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

        public async Task<IActionResult> Index()
        {
            var list = await _departmentService.FindAllAsync();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Department department)
        {
            await _departmentService.InsertAsync(department);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = await _departmentService.FindByIdAsync(id.Value);
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
                await _departmentService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = await _departmentService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            DepartmentFormViewModel viewModel = new DepartmentFormViewModel { Department = obj};
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Department department)
        {
            if (id != department.Id)
            {
                return BadRequest();
            }
            try
            {
                await _departmentService.Update(department);
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
