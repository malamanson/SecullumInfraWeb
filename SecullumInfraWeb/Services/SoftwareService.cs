using SecullumInfraWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<Software> FindAll()
        {
            return _context.Software.ToList();
        }

        public void Insert(Software obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Software FindById(int id)
        {
            return _context.Software.FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj =_context.Software.Find(id);
            _context.Software.Remove(obj);
            _context.SaveChanges();
        }

    }
}
