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
using Application.EmployeeGradeHistorys.Queries.GetEmpGradeHistById;
using Application.Common;
using Microsoft.AspNetCore.Identity;
using Application.Users.Queries.IsUsrSelfOrAdmin;

namespace WebApp.Pages.EmployeeGradeHistorys
{
    public class DetailsModel : PageModel
    {
        private readonly IMediator _mediator;

        public DetailsModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public EmployeeGradeHistory EmpGradeHistory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EmpGradeHistory = await _mediator.Send(new GetEmpGradeHistByIdQuery() { Id = id.Value });

            if (EmpGradeHistory == null)
            {
                return NotFound();
            }

            // show details only for self or admin
            bool isUsrSelfOrAdmin = await _mediator.Send(new IsUsrSelfOrAdminQuery() { UsrId = EmpGradeHistory.ApplicationUserId });
            if (!isUsrSelfOrAdmin)
            {
                return Unauthorized();
            }

            return Page();
        }
    }
}
