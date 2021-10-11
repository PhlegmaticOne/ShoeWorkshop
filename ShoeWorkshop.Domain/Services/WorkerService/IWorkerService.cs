using ShoeWorkshop.Domain.Models;
using System.Linq;

namespace ShoeWorkshop.Domain.Services
{
    public interface IWorkerService : IDataService<Worker>
    {
        IOrderedEnumerable<Worker> Sort(LiveEntitySortType sortType);
    }
}
