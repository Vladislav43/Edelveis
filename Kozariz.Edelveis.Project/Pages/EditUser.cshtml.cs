using Kozariz.Edelveis.EF.Database;
using Kozariz.Edelveis.Models.UsersTable;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Kozariz.Edelveis.Project.Pages
{
    public class EditUserModel : PageModel
    {
        private readonly MyDbContext _dbContext;

        public EditUserModel(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        public new User User { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            User = await _dbContext.UsersTable.FindAsync(id);

            if (User == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _dbContext.Attach(User).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(User.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/Users");
        }

        private bool UserExists(int id)
        {
            return _dbContext.UsersTable.Any(e => e.Id == id);
        }
    }
}
