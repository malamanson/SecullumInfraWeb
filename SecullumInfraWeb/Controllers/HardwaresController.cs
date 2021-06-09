using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SecullumInfraWeb.Models;

namespace SecullumInfraWeb.Controllers
{
    public class HardwaresController : Controller
    {
        private readonly SecullumInfraWebContext _context;

        public HardwaresController(SecullumInfraWebContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hardware.ToListAsync());
        }

        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hardware = await _context.Hardware
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hardware == null)
            {
                return NotFound();
            }

            return View(hardware);
        }

        
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Processor, Ram, HdSsd")] Hardware hardware)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hardware);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hardware);
        }

        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hardware = await _context.Hardware.FindAsync(id);
            if (hardware == null)
            {
                return NotFound();
            }
            return View(hardware);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Processor, Ram, HdSsd")] Hardware hardware)
        {
            if (id != hardware.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hardware);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HardwareExists(hardware.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(hardware);
        }

        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hardware = await _context.Hardware
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hardware == null)
            {
                return NotFound();
            }

            return View(hardware);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hardware = await _context.Hardware.FindAsync(id);
            _context.Hardware.Remove(hardware);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HardwareExists(int id)
        {
            return _context.Hardware.Any(e => e.Id == id);
        }
    }
}
