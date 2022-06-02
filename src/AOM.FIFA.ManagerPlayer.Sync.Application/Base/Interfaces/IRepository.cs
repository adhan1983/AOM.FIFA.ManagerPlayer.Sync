using System.Threading.Tasks;
using System.Collections.Generic;

namespace AOM.FIFA.ManagerPlayer.Sync.Application.Base.Interfaces
{
    public interface IRepository<T>
    {

        Task<List<T>> GetAllAsync();

        Task<T> GetByIdAsync(object id);

        Task<bool> InsertAsync(T entity);

        Task<bool> UpdateAsync(T entity);
    }
}
