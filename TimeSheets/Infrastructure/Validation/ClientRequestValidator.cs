using FluentValidation;
using TimeSheets.Models.Dto.Requests;

namespace Timesheets.Infrastructupe.Validation
{
    public class ClientRequestValidator : AbstractValidator<ClientRequest>
    {
        public ClientRequestValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
        }
    }
}
