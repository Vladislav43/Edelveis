using System.Collections.Generic;
using System.Threading.Tasks;
using Kozariz.Edelveis.Models.UsersTable;

namespace Kozariz.Edelveis.Core.Services
{
    public interface IDbEntityService<T> where T : User
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task DeleteAsync(int id);
    }
}
