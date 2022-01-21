using FluentValidation;

namespace Application.EmployeeDesignationHistorys.Commands.EditDesignationHistory
{
    public class EditDesignationHistoryCommandValidator : AbstractValidator<EditDesignationHistoryCommand>
    {
        public EditDesignationHistoryCommandValidator()
        {
            RuleFor(x => x.FromDate).NotEmpty();
        }
    }
}
