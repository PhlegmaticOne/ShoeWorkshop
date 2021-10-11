using ShoeWorkshop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ShoeWorkshop.Domain.Services
{
    public class WorkerService : IWorkerService
    {
        private readonly IDataService<Worker> _workersDataService;

        public WorkerService(IDataService<Worker> dataService) => _workersDataService = dataService;

        public Task<Worker> Create(Worker entity) => _workersDataService.Create(entity);

        public Task<bool> Delete(int id) => _workersDataService.Delete(id);

        public Task<IEnumerable<Worker>> GetAll() => _workersDataService.GetAll();

        public Task<Worker> GetById(int id) => _workersDataService.GetById(id);

        public Task<IEnumerable<Worker>> GetWithInclude(params Expression<Func<Worker, object>>[] includeProperties) =>
            _workersDataService.GetWithInclude(includeProperties);

        public IOrderedEnumerable<Worker> Sort(LiveEntitySortType sortType) => sortType switch
        {
            LiveEntitySortType.BySurnames => GetAll().Result.OrderBy(x => x.Surname),
            LiveEntitySortType.ByTotalRepairs => GetAll().Result.OrderBy(x => x.TotalRepairs),
            _ => GetAll().Result.OrderBy(x => x.Name)
        };

        public Task<Worker> Update(int id, Worker newEntity) => _workersDataService.Update(id, newEntity);
    }
}
