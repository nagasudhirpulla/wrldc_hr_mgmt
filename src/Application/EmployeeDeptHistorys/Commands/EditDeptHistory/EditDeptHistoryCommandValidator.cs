using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EmployeeDeptHistorys.Commands.EditDeptHistory
{
    public class EditDeptHistoryCommandValidator : AbstractValidator<EditDeptHistoryCommand>
    {
        public EditDeptHistoryCommandValidator()
        {
            RuleFor(x => x.FromDate).NotEmpty();
        }
    }
}
