using FluentValidation;

namespace Application.EmployeeGradeHistorys.Commands.CreateGradeHistory
{
    public class CreateGradeHistoryCommandValidator : AbstractValidator<CreateGradeHistoryCommand>
    {
        public CreateGradeHistoryCommandValidator()
        {
            RuleFor(x => x.FromDate).NotEmpty();
        }
    }
}
