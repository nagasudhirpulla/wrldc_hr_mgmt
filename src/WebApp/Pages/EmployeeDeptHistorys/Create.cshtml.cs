using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Core.Entities;
using Infra.Persistence;

namespace WebApp.Pages.EmployeeDeptHistorys
{
    public class CreateModel : PageModel
    {
        private readonly Infra.Persistence.AppDbContext _context;

        public CreateModel(Infra.Persistence.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public EmployeeDeptHistory EmployeeDeptHistory { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.EmployeeDeptHistorys.Add(EmployeeDeptHistory);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
