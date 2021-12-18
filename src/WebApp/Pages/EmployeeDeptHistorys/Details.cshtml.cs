using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Infra.Persistence;
using MediatR;
using Application.EmployeeDeptHistorys.Queries.GetEmpDeptHistById;

namespace WebApp.Pages.EmployeeDeptHistorys
{
    public class DetailsModel : PageModel
    {
        private readonly IMediator _mediator;

        public DetailsModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public EmployeeDeptHistory EmpDeptHistory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EmpDeptHistory = await _mediator.Send(new GetEmpDeptHistByIdQuery() { Id = id.Value });

            if (EmpDeptHistory == null)
            {
                return Page();
            }
            return Page();
        }
    }
}
