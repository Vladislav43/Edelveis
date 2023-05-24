using System.Threading.Tasks;
using Kozariz.Edelveis.Models;
using Kozariz.Edelveis.Models.UsersTable;

namespace Kozariz.Edelveis.Core.Services.Interfaces
{
    public interface IUsersService
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> CreateUserAsync(User newUser);
        Task UpdateUserAsync(User userToBeUpdated, User user);
        Task DeleteUserAsync(User user);
    }
}