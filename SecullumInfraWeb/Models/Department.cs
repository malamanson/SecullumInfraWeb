using System;
using System.Collections.Generic;


namespace SecullumInfraWeb.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Software> Softwares { get; set; } = new List<Software>();
        public ICollection<Hardware> Hardwares { get; set; } = new List<Hardware>();

        public Department()
        {
        }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AddSoftware(Software sw)
        {
            Softwares.Add(sw);
        }

        public void RemoveSoftware(Software sw)
        {
            Softwares.Remove(sw);
        }

        public void AddHardware(Hardware hw)
        {
            Hardwares.Add(hw);
        }

        public void RemoveHardware(Hardware hw)
        {
            Hardwares.Remove(hw);
        }
    }
}
