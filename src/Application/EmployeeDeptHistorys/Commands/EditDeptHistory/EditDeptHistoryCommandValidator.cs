using FluentValidation;

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
