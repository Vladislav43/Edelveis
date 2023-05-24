using Kozariz.Edelveis.Models.UsersTable;

namespace Kozariz.Edelveis.Core.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> CreateUserAsync(User newUser);
        Task UpdateUserAsync(User userToBeUpdated, User user);
        Task DeleteUserAsync(User user);
    }
}