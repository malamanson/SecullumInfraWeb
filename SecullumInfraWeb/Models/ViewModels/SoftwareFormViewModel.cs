using System.Collections.Generic;

namespace SecullumInfraWeb.Models.ViewModels
{
    public class SoftwareFormViewModel
    {
        public Software Software { get; set; }
        public ICollection<Hardware> Hardwares { get; set; }
        public ICollection<Department> Departments { get; set; }
        
    }
}
