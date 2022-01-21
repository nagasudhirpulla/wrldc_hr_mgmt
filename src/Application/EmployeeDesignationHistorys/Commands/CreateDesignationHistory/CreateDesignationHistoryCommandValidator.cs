using FluentValidation;

namespace Application.EmployeeDesignationHistorys.Commands.CreateDesignationHistory
{
    public class CreateDesignationHistoryCommandValidator : AbstractValidator<CreateDesignationHistoryCommand>
    {
        public CreateDesignationHistoryCommandValidator()
        {
            RuleFor(x => x.FromDate).NotEmpty();
        }
    }
}
