using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EmployeeDeptHistorys.Commands.CreateDeptHistory
{
    public class CreateDeptHistoryCommandValidator : AbstractValidator<CreateDeptHistoryCommand>
    {
        public CreateDeptHistoryCommandValidator()
        {
            RuleFor(x => x.FromDate).NotEmpty();
        }
    }
}
