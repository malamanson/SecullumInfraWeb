using System;
using SecullumInfraWeb.Models.Enums;


namespace SecullumInfraWeb.Models
{
    public class Software
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public DateTime Date { get; set; }
        public string Serial { get; set; }
        public Hardware Hardware { get; set; }
        public Department Department { get; set; }
        public SoftwareStatus Status { get; set; }

        public Software()
        {
        }

        public Software(int id, string name, string version, DateTime date, 
            string serial, Hardware hardware, Department department, SoftwareStatus status)
        {
            Id = id;
            Name = name;
            Version = version;
            Date = date;
            Serial = serial;
            Hardware = hardware;
            Department = department;
            Status = status;
        }
    }
}
