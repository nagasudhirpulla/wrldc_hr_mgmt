using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Application.EmployeeDeptHistorys.Commands.CreateDeptHistory;
using MediatR;
using Application.Departments.Queries.GetDepartments;
using FluentValidation.Results;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Application.Users;

namespace WebApp.Pages.EmployeeDeptHistorys
{
    [Authorize(Roles = SecurityConstants.AdminRoleString)]
    public class CreateModel : PageModel
    {
        private readonly IMediator _mediator;

        public CreateModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> OnGetAsync(string usrId)
        {
            if (usrId == null)
            {
                return NotFound();
            }
            await InitSelectListItems();
            NewDeptHistory = new()
            {
                ApplicationUserId = usrId,
                FromDate = DateTime.Now
            };
            return Page();
        }

        [BindProperty]
        public CreateDeptHistoryCommand NewDeptHistory { get; set; }
        public SelectList DepartmentNameSL { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            await InitSelectListItems();

            ValidationResult validationCheck = new CreateDeptHistoryCommandValidator().Validate(NewDeptHistory);
            validationCheck.AddToModelState(ModelState, nameof(NewDeptHistory));
            if (!ModelState.IsValid)
            {
                return Page();
            }

            List<string> errs = await _mediator.Send(NewDeptHistory);
            if (errs.Count == 0)
            {
                return RedirectToPage($"./{nameof(Index)}", routeValues: new { usrId = NewDeptHistory.ApplicationUserId });
            }

            ModelState.AddModelError(null, string.Join(", ", errs));
            return Page();
        }

        public async Task InitSelectListItems()
        {
            DepartmentNameSL = new SelectList(await _mediator.Send(new GetDepartmentsQuery()), "Id", "Name");
        }
    }
}
