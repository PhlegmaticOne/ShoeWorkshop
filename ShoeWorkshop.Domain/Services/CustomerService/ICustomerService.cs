using ShoeWorkshop.Domain.Models;
using System.Linq;

namespace ShoeWorkshop.Domain.Services
{
    public interface ICustomerService : IDataService<Customer>
    {
        IOrderedEnumerable<Customer> Sort(LiveEntitySortType sortType);
    }
}
