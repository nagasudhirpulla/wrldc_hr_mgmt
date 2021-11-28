using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Application.Common.Interfaces;
using Application.Users;
using Core.Entities;
using Infra.Persistence;

namespace WebApp.Pages.Designations
{
    [Authorize(Roles = SecurityConstants.AdminRoleString)]
    public class CreateModel : PageModel
    {
        private readonly IAppDbContext _context;

        public CreateModel(IAppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Designation Designation { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Designations.Add(Designation);
            await _context.SaveChangesAsync(new CancellationToken());

            return RedirectToPage("./Index");
        }
    }
}
