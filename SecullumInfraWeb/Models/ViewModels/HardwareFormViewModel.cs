using System.Collections.Generic;

namespace SecullumInfraWeb.Models.ViewModels
{
    public class HardwareFormViewModel
    {
        public Hardware Hardware { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
}
