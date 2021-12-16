using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Infra.Persistence;

namespace WebApp.Pages.EmployeeDeptHistorys
{
    public class EditModel : PageModel
    {
        private readonly Infra.Persistence.AppDbContext _context;

        public EditModel(Infra.Persistence.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EmployeeDeptHistory EmployeeDeptHistory { get; set; }
        public SelectList DepartmentNameSL { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EmployeeDeptHistory = await _context.EmployeeDeptHistorys
                .Include(e => e.Department).FirstOrDefaultAsync(m => m.Id == id);

            if (EmployeeDeptHistory == null)
            {
                return NotFound();
            }
           ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(EmployeeDeptHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeDeptHistoryExists(EmployeeDeptHistory.Id))
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

        private bool EmployeeDeptHistoryExists(int id)
        {
            return _context.EmployeeDeptHistorys.Any(e => e.Id == id);
        }
    }
}
