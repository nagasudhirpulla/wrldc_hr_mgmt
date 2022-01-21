using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Application.Common.Interfaces;
using Application.Users;
using Core.Entities;

namespace WebApp.Pages.Designations
{
    [Authorize(Roles = SecurityConstants.AdminRoleString)]
    public class EditModel : PageModel
    {
        private readonly IAppDbContext _context;

        public EditModel(IAppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Designation Designation { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Designation = await _context.Designations.FirstOrDefaultAsync(m => m.Id == id);

            if (Designation == null)
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

            _context.Attach(Designation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync(new CancellationToken());
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DesignationExists(Designation.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DesignationExists(int id)
        {
            return _context.Designations.Any(e => e.Id == id);
        }
    }
}
