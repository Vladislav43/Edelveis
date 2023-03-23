using Kozariz.Edelveis.EF.Database;
using Kozariz.Edelveis.Models.UsersTable;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Kozariz.Edelveis.Project.Pages
{
    public class CreateUserModel : PageModel
    {
        private readonly MyDbContext _dbContext;

        public CreateUserModel(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        public User User { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _dbContext.UsersTable.Add(User);
            await _dbContext.SaveChangesAsync();

            return RedirectToPage("/Users");
        }
    }
}
