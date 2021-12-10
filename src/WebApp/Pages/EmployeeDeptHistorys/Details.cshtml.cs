using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Infra.Persistence;

namespace WebApp.Pages.EmployeeDeptHistorys
{
    public class DetailsModel : PageModel
    {
        private readonly Infra.Persistence.AppDbContext _context;

        public DetailsModel(Infra.Persistence.AppDbContext context)
        {
            _context = context;
        }

        public EmployeeDeptHistory EmployeeDeptHistory { get; set; }

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
                return Page();
            }
            return Page();
        }
    }
}
