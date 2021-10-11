using ShoeWorkshop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ShoeWorkshop.Domain.Services
{
    public class RepairService : IRepairService
    {
        private readonly IDataService<Repair> _repairsDataService;

        public RepairService(IDataService<Repair> repairDataService) => _repairsDataService = repairDataService;

        public async Task<Repair> Add(Customer customer, Worker worker, decimal price, RepairType repairType, DateTime endTime, DateTime paymentTime)
        {
            return await Create(new Repair()
            {
                Customer = customer,
                Worker = worker,
                Price = price,
                RepairType = repairType,
                EndOfRepair = endTime,
                PaymentTime = paymentTime,
                IsEnded = false
            });
        }

        public Task<Repair> Create(Repair entity) => _repairsDataService.Create(entity);

        public Task<bool> Delete(int id) => _repairsDataService.Delete(id);

        public Task<IEnumerable<Repair>> GetAll() => _repairsDataService.GetAll();

        public IEnumerable<Repair> GetAllByType(RepairType repairType) => GetAll().Result.Where(x => x.RepairType == repairType);

        public IEnumerable<Repair> GetAllOverPeriodOfTime(DateTime from, DateTime to) => GetAll().Result.Where(x => x.PaymentTime >= from && x.PaymentTime <= to);

        public Dictionary<RepairType, double> GetAverageAmountByType()
        {
            var result = new Dictionary<RepairType, double>();

            var allRepairs = GetAll().Result;
            var groupedRepairs = allRepairs.GroupBy(x => x.RepairType);
            var minDate = allRepairs.Min(x => x.PaymentTime);
            var maxDate = allRepairs.Max(x => x.PaymentTime);

            foreach (var repairTypeCollection in groupedRepairs)
            {
                var average = (double)repairTypeCollection.Count() / (maxDate - minDate).Days;
                result.Add(repairTypeCollection.Key, average);
            }
            return result;
        }

        public Task<Repair> GetById(int id) => _repairsDataService.GetById(id);

        public RepairType GetTheMostPopularType(DateTime from, DateTime to) =>
            GetAllOverPeriodOfTime(from, to).GroupBy(x => x.RepairType).OrderBy(y => y.Count()).Last().Key;

        public Task<IEnumerable<Repair>> GetWithInclude(params Expression<Func<Repair, object>>[] includeProperties)
            => _repairsDataService.GetWithInclude(includeProperties);

        public IOrderedEnumerable<Repair> Sort(RepairSortType sortType) => sortType switch
        {
            RepairSortType.ByCustomerNames => GetAll().Result.OrderBy(x => x.Customer.Name),
            RepairSortType.ByCustomerSurnames => GetAll().Result.OrderBy(x => x.Customer.Surname),
            RepairSortType.ByPaymentTimeDecreasing => GetAll().Result.OrderByDescending(x => x.PaymentTime),
            RepairSortType.ByPaymentTimeInrcreasing => GetAll().Result.OrderBy(x => x.PaymentTime),
            RepairSortType.ByPriceDecreasing => GetAll().Result.OrderByDescending(x => x.Price),
            RepairSortType.ByPriceIncreasing => GetAll().Result.OrderBy(x => x.Price),
            RepairSortType.ByRepairType => GetAll().Result.OrderBy(x => x.RepairType),
            RepairSortType.ByWorkerNames => GetAll().Result.OrderBy(x => x.Worker.Name),
            RepairSortType.ByWorkerSurnames => GetAll().Result.OrderBy(x => x.Worker.Surname),
            _ => GetAll().Result.OrderBy(x => x.Id)
        };

        public Task<Repair> Update(int id, Repair newEntity) => _repairsDataService.Update(id, newEntity);
    }
}
