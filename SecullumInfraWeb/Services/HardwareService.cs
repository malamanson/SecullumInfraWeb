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

        public List<Hardware> FindAll()
        {
            return _context.Hardware.ToList();
        }

        public void Insert(Hardware obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Hardware FindById(int id)
        {
            return _context.Hardware.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remone(int id)
        {
            var obj = _context.Hardware.Find(id);
            _context.Hardware.Remove(obj);
            _context.SaveChanges();
        }
        public void Update(Hardware obj)
        {
            if (!_context.Hardware.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Hardware ID não encontrado!");
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

        public List<Hardware> FindByDate(DateTime? minDate, DateTime? maxDate, string searchString)
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
            return result.ToList();
        }
    }
}
