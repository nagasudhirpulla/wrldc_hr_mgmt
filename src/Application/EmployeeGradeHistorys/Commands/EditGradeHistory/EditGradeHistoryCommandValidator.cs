using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EmployeeGradeHistorys.Commands.EditGradeHistory
{
    public class EditGradeHistoryCommandValidator : AbstractValidator<EditGradeHistoryCommand>
    {
        public EditGradeHistoryCommandValidator()
        {
            RuleFor(x => x.FromDate).NotEmpty();
        }
    }
}
