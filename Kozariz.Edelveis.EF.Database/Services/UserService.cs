using Kozariz.Edelveis.Models.UsersTable;
using Kozariz.Edelveis.EF.Database;

namespace Kozariz.Edelveis.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IDbEntityService<User> _userService;

        public UserService(IDbEntityService<User> userService)
        {
            _userService = userService;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _userService.GetAllAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userService.GetByIdAsync(id);
        }

        public async Task<User> CreateUserAsync(User newUser)
        {
            if (newUser == null)
            {
                throw new ArgumentNullException(nameof(newUser));
            }

            return await _userService.CreateAsync(newUser);
        }

        public async Task UpdateUserAsync(User userToBeUpdated, User user)
        {
            if (userToBeUpdated == null)
            {
                throw new ArgumentNullException(nameof(userToBeUpdated));
            }

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            userToBeUpdated.Id = user.Id;
            userToBeUpdated.Username = user.Username;
            userToBeUpdated.Email = user.Email;

            await _userService.UpdateAsync(userToBeUpdated);
        }

        public async Task DeleteUserAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            await _userService.DeleteAsync(user);
        }
    }
}