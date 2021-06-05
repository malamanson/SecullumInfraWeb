using System;
using System.Collections.Generic;
using SecullumInfraWeb.Models.Enums;

namespace SecullumInfraWeb.Models
{
    public class Hardware
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Configuration { get; set; }
        public Department Department { get; set; }
        public HardwareStatus Status { get; set; }
        public ICollection<Software> Softwares { get; set; } = new List<Software>(); 

        public Hardware()
        {

        }

        public Hardware(int id, string name, DateTime date, string description,
                        string configuration, Department department, HardwareStatus status)
        {
            Id = id;
            Name = name;
            Date = date;
            Description = description;
            Configuration = configuration;
            Department = department;
            Status = status;
        }

        public void AddSoftware (Software sw)
        {
            Softwares.Add(sw);
        }

        public void RemoveSoftware(Software sw)
        {
            Softwares.Remove(sw);
        }
    }
}
