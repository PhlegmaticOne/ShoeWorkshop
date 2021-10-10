using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoeWorkshop.Domain
{
    public interface IDataService<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Update(int id, T newEntity);
        Task<T> Create(T entity);
        Task<bool> Delete(int id);
    }
}
