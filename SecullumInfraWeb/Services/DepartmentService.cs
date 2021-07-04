using Microsoft.EntityFrameworkCore;
using SecullumInfraWeb.Models;
using SecullumInfraWeb.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecullumInfraWeb.Services
{
    public class DepartmentService
    {
        private readonly SecullumInfraWebContext _context;

        public DepartmentService(SecullumInfraWebContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }

        public async Task InsertAsync(Department obj)
        {
            _context.Add(obj);
           await _context.SaveChangesAsync();
        }
        
        public async Task <Department> FindByIdAsync(int id)
        {
            return await _context.Department.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = _context.Department.Find(id);
                _context.Department.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw new IntegrityException("Você não pode apagar este Departamento...existem Equipamentos ou Softwares vinculados à ele");
            }
        }
        public async Task Update(Department obj)
        {
            if (!_context.Department.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Department ID não encontrado!");
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
    }
}
