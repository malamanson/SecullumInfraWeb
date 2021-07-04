using SecullumInfraWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SecullumInfraWeb.Services.Exceptions;
using System.Threading.Tasks;

namespace SecullumInfraWeb.Services
{
    public class SoftwareService
    {
        private readonly SecullumInfraWebContext _context;

        public SoftwareService(SecullumInfraWebContext context)
        {
            _context = context;
        }

        public async Task<List<Software>> FindAllAsync()
        {
            return await _context.Software.ToListAsync();
        }

        public async Task InsertAsync(Software obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Software> FindByIdAsync(int id)
        {
            return await _context.Software.Include(obj => obj.Department.Hardwares).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Software.FindAsync(id);
            _context.Software.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Software obj)
        {
            var anycon = await _context.Software.AnyAsync(x => x.Id == obj.Id);
            if (!anycon)
            {
                throw new NotFoundException("Software ID não encontrado!");
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
        public async Task<List<Software>> FindByDateAsync(DateTime? minDate, DateTime? maxDate, string searchString)
        {
            var result = from obj in _context.Software select obj;
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
                result = result.Where(obj => obj.Version.Contains(searchString)
                                       || obj.Name.Contains(searchString) || obj.Serial.Contains(searchString));
            }
            return await result.ToListAsync();
        }
    }
}
