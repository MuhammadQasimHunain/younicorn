using System.Collections.Generic;
using System.Threading.Tasks;

namespace YounicornApp.SharedKernel.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<List<T>> ListAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<int> CountAsync();
        Task<T> FirstAsync();
        Task<T> FirstOrDefaultAsync();
    }
}