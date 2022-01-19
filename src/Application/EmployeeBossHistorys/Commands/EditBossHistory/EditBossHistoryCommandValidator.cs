using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EmployeeBossHistorys.Commands.EditBossHistory
{
    public class EditBossHistoryCommandValidator : AbstractValidator<EditBossHistoryCommand>
    {
        public EditBossHistoryCommandValidator()
        {
            RuleFor(x => x.FromDate).NotEmpty();
        }
    }
}
