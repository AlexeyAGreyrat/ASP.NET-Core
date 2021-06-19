using FluentValidation;
using TimeSheets.Models.Dto.Requests;

namespace Timesheets.Infrastructupe.Validation
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.Login).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
