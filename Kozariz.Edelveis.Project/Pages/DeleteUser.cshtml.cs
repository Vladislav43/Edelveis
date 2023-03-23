using Kozariz.Edelveis.EF.Database;
using Kozariz.Edelveis.Models.UsersTable;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Kozariz.Edelveis.Project.Pages
{
    public class DeleteUserModel : PageModel
    {
        private readonly MyDbContext _context;

        public DeleteUserModel(MyDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User User { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User = await _context.UsersTable.FirstOrDefaultAsync(m => m.Id == id);

            if (User == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User = await _context.UsersTable.FindAsync(id);

            if (User != null)
            {
                _context.UsersTable.Remove(User);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Users");
        }
    }
}
