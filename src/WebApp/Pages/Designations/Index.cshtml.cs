using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Application.Common.Interfaces;
using Application.Users;
using Core.Entities;

namespace WebApp.Pages.Designations
{
    [Authorize(Roles = SecurityConstants.AdminRoleString)]
    public class IndexModel : PageModel
    {
        private readonly IAppDbContext _context;

        public IndexModel(IAppDbContext context)
        {
            _context = context;
        }

        public IList<Designation> Designation { get;set; }

        public async Task OnGetAsync()
        {
            Designation = await _context.Designations.ToListAsync();
        }
    }
}
