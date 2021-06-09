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
    }
}
