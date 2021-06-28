using SecullumInfraWeb.Models;
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
            return _context.Hardware.FirstOrDefault(obj => obj.Id == id);
        }

        public void Remone(int id)
        {
            var obj = _context.Hardware.Find(id);
            _context.Hardware.Remove(obj);
            _context.SaveChanges();
        }
    }
}
