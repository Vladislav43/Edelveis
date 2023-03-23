using System;
using Kozariz.Edelveis.Core.Services;
using Kozariz.Edelveis.Models.UsersTable;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Kozariz.Edelveis.Project.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserRepository userRepository, ILogger<UserController> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
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
                _logger.LogInformation("Created new user: {@User}", user);
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
                _logger.LogInformation("Updated user with Id {UserId}", user.Id);
                return RedirectToAction("/Index");
            }
            return View(user);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userRepository.DeleteUserAsync(id);
            _logger.LogInformation("Deleted user with Id {UserId}. Result: {Result}", id, result);
            return Json(new { success = result });
        }
    }
}

public class DebugTest
{
    private readonly ILogger<DebugTest> _logger;

    public DebugTest(ILogger<DebugTest> logger)
    {
        _logger = logger;
    }

    public void LogDebug()
    {
        _logger.LogDebug("This is a debug message");
    }

    public void LogInformation()
    {
        _logger.LogInformation("This is an information message");
    }

    public void LogWarning()
    {
        _logger.LogWarning("This is a warning message");
    }

    public void LogError()
    {
        try
        {
            throw new Exception("This is an exception");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred");
        }
    }

    public void LogCritical()
    {
        try
        {
            throw new Exception("This is a critical exception");
        }
        catch (Exception ex)
        {
            _logger.LogCritical(ex, "A critical error occurred");
        }
    }
}
