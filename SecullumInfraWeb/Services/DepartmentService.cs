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

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }

        public void Insert(Department obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
        
        public Department FindById(int id)
        {
            return _context.Department.FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Department.Find(id);
            _context.Department.Remove(obj);
            _context.SaveChanges();
        }
        public void Update(Department obj)
        {
            if (!_context.Department.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Department ID não encontrado!");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
