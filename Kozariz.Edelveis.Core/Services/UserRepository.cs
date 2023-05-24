using Kozariz.Edelveis.Models.Configuration;
using Kozariz.Edelveis.EF.Database;
using Kozariz.Edelveis.Models.UsersTable;
using Microsoft.EntityFrameworkCore;


namespace Kozariz.Edelveis.Core.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly MyDbContext _context;

        public UserRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.UsersTable.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.UsersTable.FindAsync(id);
        }

        public async Task<User> CreateUserAsync(User newUser)
        {
            _context.UsersTable.Add(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }

        public async Task UpdateUserAsync(User userToBeUpdated, User user)
        {
            userToBeUpdated.Id = user.Id;
            userToBeUpdated.Username = user.Username;
            userToBeUpdated.Email = user.Email;

            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _context.UsersTable.FindAsync(id);
            if (user == null)
            {
                return false;
            }

            _context.UsersTable.Remove(user);
            await _context.SaveChangesAsync();

            return true;
        }


    }
}

