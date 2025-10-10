namespace StudentAffairs.Application;

public class CreateStudentDtoValidator : AbstractValidator<StudentDto>
{
    public CreateStudentDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MinimumLength(2).WithMessage("Name cannot be smaller than 2 characters")
            .MaximumLength(50).WithMessage("Name cannot exceed 50 characters");

        RuleFor(x => x.Mobile)
            .NotEmpty().WithMessage("Mobile number is required")
            .Length(11).WithMessage("Mobile number must be exactly 11 digits");

        RuleFor(x => x.Telephone)
            .NotEmpty().WithMessage("Telephone number is required")
            .Length(10).WithMessage("Telephone number must be exactly 10 digits");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Please enter a valid email address")
            .MaximumLength(100).WithMessage("Email cannot exceed 100 characters");

        RuleFor(x => x.Age)
            .GreaterThan(0).WithMessage("Age must be greater than 0")
            .LessThan(120).WithMessage("Age must be less than 120");

        RuleFor(x => x.Message)
            .NotEmpty().WithMessage("Message is required")
            .MaximumLength(200).WithMessage("Message cannot exceed 200 characters");
    }
}
