using Kozariz.Edelveis.Core.Services;
using Kozariz.Edelveis.Models.UsersTable;
using Microsoft.AspNetCore.Mvc;

namespace Kozariz.Edelveis.Project.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userRepository.GetUsersAsync();
            return View(users);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                await _userRepository.CreateUserAsync(user);
                return RedirectToAction("/Index");
            }
            return View(user);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var originalUser = await _userRepository.GetUserByIdAsync(user.Id);
                if (originalUser == null)
                {
                    return NotFound();
                }

                originalUser.Username = user.Username;
                originalUser.Email = user.Email;

                await _userRepository.UpdateUserAsync(originalUser, user);
                return RedirectToAction("/Index");
            }
            return View(user);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userRepository.DeleteUserAsync(id);
            return Json(new { success = result });
        }


    }
}
