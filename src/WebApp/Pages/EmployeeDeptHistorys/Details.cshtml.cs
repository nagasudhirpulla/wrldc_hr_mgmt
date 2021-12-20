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
using Application.Common;
using Microsoft.AspNetCore.Identity;
using Application.Users.Queries.IsUsrSelfOrAdmin;

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
                return NotFound();
            }

            // show details only for self or admin
            bool isUsrSelfOrAdmin = await _mediator.Send(new IsUsrSelfOrAdminQuery() { UsrId = EmpDeptHistory.ApplicationUserId });
            if (!isUsrSelfOrAdmin)
            {
                return Unauthorized();
            }

            return Page();
        }
    }
}
