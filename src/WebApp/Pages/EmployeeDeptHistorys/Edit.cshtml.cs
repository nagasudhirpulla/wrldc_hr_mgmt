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
using MediatR;
using Application.EmployeeDeptHistorys.Commands.EditDeptHistory;
using Application.EmployeeDeptHistorys.Queries.GetEmpDeptHistById;
using AutoMapper;
using Application.Departments.Queries.GetDepartments;
using FluentValidation.Results;
using FluentValidation.AspNetCore;
using WebApp.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Application.Users;

namespace WebApp.Pages.EmployeeDeptHistorys
{
    [Authorize(Roles = SecurityConstants.AdminRoleString)]
    public class EditModel : PageModel
    {
        private readonly ILogger<EditModel> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public EditModel(IMediator mediator, IMapper mapper, ILogger<EditModel> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        [BindProperty]
        public EditDeptHistoryCommand EmpDeptHistItem { get; set; }
        public SelectList DepartmentNameSL { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            await InitSelectListItems();
            EmpDeptHistItem = _mapper.Map<EditDeptHistoryCommand>(await _mediator.Send(new GetEmpDeptHistByIdQuery() { Id = id.Value }));

            if (EmpDeptHistItem == null)
            {
                return NotFound();
            }

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            await InitSelectListItems();

            ValidationResult validationCheck = new EditDeptHistoryCommandValidator().Validate(EmpDeptHistItem);
            validationCheck.AddToModelState(ModelState, nameof(EmpDeptHistItem));

            if (!ModelState.IsValid)
            {
                return Page();
            }

            List<string> errors = await _mediator.Send(EmpDeptHistItem);

            foreach (var error in errors)
            {
                ModelState.AddModelError(string.Empty, error);
            }

            // check if we have any errors and redirect if successful
            if (errors.Count == 0)
            {
                _logger.LogInformation("User Department History edit operation successful");
                return RedirectToPage($"./{nameof(Index)}", routeValues: new { usrId = EmpDeptHistItem.ApplicationUserId })
                            .WithSuccess("User Department History editing done");
            }

            return Page();
        }

        public async Task InitSelectListItems()
        {
            DepartmentNameSL = new SelectList(await _mediator.Send(new GetDepartmentsQuery()), "Id", "Name");
        }
    }
}
