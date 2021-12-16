using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Core.Entities;
using Infra.Persistence;
using Application.EmployeeDeptHistorys.Commands.CreateDeptHistory;
using MediatR;
using Application.Departments.Queries.GetDepartments;

namespace WebApp.Pages.EmployeeDeptHistorys
{
    public class CreateModel : PageModel
    {
        private readonly IMediator _mediator;

        public CreateModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> OnGetAsync(string usrId)
        {
            NewDeptHistory = new();
            NewDeptHistory.ApplicationUserId = usrId;
            List<Department> depts = await _mediator.Send(new GetDepartmentsQuery());
            DepartmentNameSL = new SelectList(depts, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public CreateDeptHistoryCommand NewDeptHistory { get; set; }
        public SelectList DepartmentNameSL { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _ = await _mediator.Send(NewDeptHistory);

            // TODO show errors in create page if present
            return RedirectToPage("./Index");
        }
    }
}
