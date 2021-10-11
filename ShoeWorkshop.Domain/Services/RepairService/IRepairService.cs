using ShoeWorkshop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeWorkshop.Domain.Services
{
    public interface IRepairService : IDataService<Repair>
    {
        IOrderedEnumerable<Repair> Sort(RepairSortType sortType);
        IEnumerable<Repair> GetAllOverPeriodOfTime(DateTime from, DateTime to);
        IEnumerable<Repair> GetAllByType(RepairType repairType);
        Dictionary<RepairType, double> GetAverageAmountByType();
        RepairType GetTheMostPopularType(DateTime from, DateTime to);
        Task<Repair> Add(Customer customer, Worker worker, decimal price,
                         RepairType repairType, DateTime endTime, DateTime paymentTime);
    }
    public enum RepairSortType
    {
        ByCustomerNames,
        ByCustomerSurnames,
        ByWorkerNames,
        ByWorkerSurnames,
        ByPaymentTimeInrcreasing,
        ByPaymentTimeDecreasing,
        ByPriceIncreasing,
        ByPriceDecreasing,
        ByRepairType
    }
}
