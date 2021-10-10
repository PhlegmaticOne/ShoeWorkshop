using System;

namespace ShoeWorkshop.Domain.Models
{
    public class Repair : DomainModel
    {
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int? WorkerId { get; set; }
        public Worker Worker { get; set; }
        public decimal Price { get; set; }
        public DateTime PaymentTime { get; set; }
        public DateTime EndOfRepair { get; set; }
        public bool IsEnded { get; set; }
        public RepairType RepairType { get; set; }
    }
}
