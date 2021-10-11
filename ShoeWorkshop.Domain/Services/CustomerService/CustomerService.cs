using ShoeWorkshop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ShoeWorkshop.Domain.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IDataService<Customer> _customersDataService;

        public CustomerService(IDataService<Customer> customerDataService) => 
            _customersDataService = customerDataService;

        public async Task<Customer> Create(Customer entity) => await _customersDataService.Create(entity);

        public async Task<bool> Delete(int id) => await _customersDataService.Delete(id);

        public async Task<IEnumerable<Customer>> GetAll() => await _customersDataService.GetAll();

        public async Task<Customer> GetById(int id) => await _customersDataService.GetById(id);

        public Task<IEnumerable<Customer>> GetWithInclude(params Expression<Func<Customer, object>>[] includeProperties) =>
            _customersDataService.GetWithInclude(includeProperties);

        public IOrderedEnumerable<Customer> Sort(LiveEntitySortType sortType) => sortType switch
        {
            LiveEntitySortType.ByTotalRepairs => GetAll().Result.OrderBy(x => x.TotalRepairs),
            LiveEntitySortType.BySurnames => GetAll().Result.OrderBy(x => x.Surname),
            _ => GetAll().Result.OrderBy(x => x.Name)
        };

        public async Task<Customer> Update(int id, Customer newEntity) => await _customersDataService.Update(id, newEntity);

    }
}
