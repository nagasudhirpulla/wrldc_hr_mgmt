using FluentValidation;

namespace Application.Grades.Commands.CreateGrade
{
    public class CreateGradeCommandValidator : AbstractValidator<CreateGradeCommand>
    {
        public CreateGradeCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Level).GreaterThan(0);
        }
    }
}
