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
using Application.EmployeeDesignationHistorys.Commands.EditDesignationHistory;
using Application.EmployeeDesignationHistorys.Queries.GetEmpDesignationHistById;
using AutoMapper;
using Application.Designations.Queries.GetDesignations;
using FluentValidation.Results;
using FluentValidation.AspNetCore;
using WebApp.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Application.Users;

namespace WebApp.Pages.EmployeeDesignationHistorys
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
        public EditDesignationHistoryCommand EmpDesignationHistItem { get; set; }
        public SelectList DesignationNameSL { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            await InitSelectListItems();
            EmpDesignationHistItem = _mapper.Map<EditDesignationHistoryCommand>(await _mediator.Send(new GetEmpDesignationHistByIdQuery() { Id = id.Value }));

            if (EmpDesignationHistItem == null)
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

            ValidationResult validationCheck = new EditDesignationHistoryCommandValidator().Validate(EmpDesignationHistItem);
            validationCheck.AddToModelState(ModelState, nameof(EmpDesignationHistItem));

            if (!ModelState.IsValid)
            {
                return Page();
            }

            List<string> errors = await _mediator.Send(EmpDesignationHistItem);

            foreach (var error in errors)
            {
                ModelState.AddModelError(string.Empty, error);
            }

            // check if we have any errors and redirect if successful
            if (errors.Count == 0)
            {
                _logger.LogInformation("User Designation History edit operation successful");
                return RedirectToPage($"./{nameof(Index)}", routeValues: new { usrId = EmpDesignationHistItem.ApplicationUserId })
                            .WithSuccess("User Designation History editing done");
            }

            return Page();
        }

        public async Task InitSelectListItems()
        {
            DesignationNameSL = new SelectList(await _mediator.Send(new GetDesignationsQuery()), "Id", "Name");
        }
    }
}
