using Microsoft.EntityFrameworkCore;
using SecullumInfraWeb.Models;
using SecullumInfraWeb.Models.Enums;
using SecullumInfraWeb.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecullumInfraWeb.Services
{
    public class HardwareService
    {
        private readonly SecullumInfraWebContext _context;

        public HardwareService(SecullumInfraWebContext context)
        {
            _context = context;
        }

        public async Task<List<Hardware>> FindAllAsync()
        {
            return await _context.Hardware.ToListAsync();
        }

        public async Task InsertAsync(Hardware obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Hardware> FindByIdAsync(int id)
        {
            return await _context.Hardware.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Hardware.FindAsync(id);
                _context.Hardware.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw new IntegrityException("Você não pode apagar este Equipamento...existem Softwares vinculados à ele");
            }
        }
        public async Task UpdateAsync(Hardware obj)
        {
            var anycon = await _context.Hardware.AnyAsync(x => x.Id == obj.Id);
            if (!anycon)
            {
                throw new NotFoundException("Hardware ID não encontrado!");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

        public async Task<List<Hardware>> FindByDateAsync(DateTime? minDate, DateTime? maxDate, string searchString)
        {
            var result = from obj in _context.Hardware select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                result = result.Where(obj => obj.Processor.Contains(searchString)
                                       || obj.Name.Contains(searchString) || obj.Description.Contains(searchString));
            }
            return await result.ToListAsync();
        }
    }
}
