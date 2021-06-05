using System;
using SecullumInfraWeb.Models.Enums;


namespace SecullumInfraWeb.Models
{
    public class Software
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Key { get; set; }
        public Hardware Hardware { get; set; }
        public Department Department { get; set; }
        public SoftwareStatus Status { get; set; }

        public Software()
        {

        }

        public Software(int id, string name, DateTime date, string key, 
                        Hardware hardware, Department department, SoftwareStatus status)
        {
            Id = id;
            Name = name;
            Date = date;
            Key = key;
            Hardware = hardware;
            Department = department;
            Status = status;
        }
    }
}
