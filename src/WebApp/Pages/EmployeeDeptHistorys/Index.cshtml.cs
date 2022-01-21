using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Core.Entities;
using MediatR;
using Application.EmployeeDeptHistorys.Queries.GetDeptHistoryForEmp;
using Application.Users.Queries.IsUsrSelfOrAdmin;

namespace WebApp.Pages.EmployeeDeptHistorys
{
    public class IndexModel : PageModel
    {
        private readonly IMediator _mediator;

        public IndexModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IList<EmployeeDeptHistory> EmpDeptHistory { get; set; }
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
            EmpDeptHistory = await _mediator.Send(new GetDeptHistoryForEmpQuery() { ApplicationUserId = usrId });
            EmployeeId = usrId;
            return Page();
        }
    }
}
