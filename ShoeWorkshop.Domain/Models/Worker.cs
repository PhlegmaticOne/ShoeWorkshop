using System.Collections.Generic;

namespace ShoeWorkshop.Domain.Models
{
    public class Worker : DomainModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public int TotalRepairs { get; set; }
        public ICollection<Repair> Repairs { get; set; }
    }
}
