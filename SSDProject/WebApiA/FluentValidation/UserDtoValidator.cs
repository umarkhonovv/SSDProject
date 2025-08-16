using FluentValidation;
using WebApiA.DTOs;

namespace WebApiA.FluentValidation
{
    public class UserDtoValidator : AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(35);

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.")
                .Matches(@"^[\w\.-]+@[\w\.-]+\.\w{2,}$");
        }
    }
}
