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
    public class DetailsModel : PageModel
    {
        private readonly IAppDbContext _context;

        public DetailsModel(IAppDbContext context)
        {
            _context = context;
        }

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
    }
}
