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
using Application.EmployeeBossHistorys.Queries.GetBossHistoryForEmp;
using Application.Users;
using Microsoft.AspNetCore.Authorization;
using Application.Common;
using Microsoft.AspNetCore.Identity;
using Application.Users.Queries.IsUsrSelfOrAdmin;

namespace WebApp.Pages.EmployeeBossHistorys
{
    public class IndexModel : PageModel
    {
        private readonly IMediator _mediator;

        public IndexModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IList<EmployeeBossHistory> EmpBossHistory { get; set; }
        public string EmployeeId { get; set; }

        public async Task<ActionResult> OnGetAsync(string usrId)
        {
            if (usrId == null)
            {
                return NotFound();
            }
            bool isUsrSelfOrAdmin = await _mediator.Send(new IsUsrSelfOrAdminQuery() { UsrId = usrId });
            if (!isUsrSelfOrAdmin)
            {
                return Unauthorized();
            }
            EmpBossHistory = await _mediator.Send(new GetBossHistoryForEmpQuery() { ApplicationUserId = usrId });
            EmployeeId = usrId;
            return Page();
        }
    }
}
