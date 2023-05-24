using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kozariz.Edelveis.Models.UsersTable;
using Microsoft.EntityFrameworkCore;

namespace Kozariz.Edelveis.Core.Services
{
    public class DbEntityService<T> : IDbEntityService<T> where T : User
    {
        private readonly DbContext _context;

        public DbEntityService(DbContext context)
        {
            _context = context;
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public virtual IQueryable<T> Query()
        {
            return _context.Set<T>().AsQueryable();
        }

        Task<IEnumerable<T>> IDbEntityService<T>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<T> IDbEntityService<T>.CreateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
