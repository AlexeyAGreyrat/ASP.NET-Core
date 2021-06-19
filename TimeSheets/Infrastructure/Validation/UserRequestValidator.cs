using FluentValidation;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Infrastructure.Validation
{
    public class UserRequestValidator  : AbstractValidator<UserRequest>
	{
		public UserRequestValidator()
		{
			RuleFor(x => x.Username)
				.NotEmpty();			

			RuleFor(x => x.Password)
				.NotEmpty();
		}
	}
}
