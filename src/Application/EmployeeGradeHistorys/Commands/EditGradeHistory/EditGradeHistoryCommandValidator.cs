using FluentValidation;

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
