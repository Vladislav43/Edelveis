using System.Collections.Generic;
using System.Threading.Tasks;
using Kozariz.Edelveis.Core;
using Kozariz.Edelveis.EF.Database;
using Kozariz.Edelveis.Models.UsersTable;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Kozariz.Edelveis.Project.Pages
{
    public class UserModel : PageModel
    {
        private readonly MyDbContext _dbContext;

        public UserModel(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<User> Users { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Users = await _dbContext.UsersTable.ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(List<User> users)
        {
            if (!ModelState.IsValid)
            {
                Users = await _dbContext.UsersTable.ToListAsync();
                return Page();
            }

            foreach (var user in users)
            {
                _dbContext.UsersTable.Add(user);
            }

            await _dbContext.SaveChangesAsync();

            return RedirectToPage("/User");
        }
    }
}
