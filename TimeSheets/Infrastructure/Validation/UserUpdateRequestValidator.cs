using FluentValidation;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Infrastructure.Validation
{
    public class UserUpdateRequestValidator : AbstractValidator<UserUpdateRequest>
    {
		public UserUpdateRequestValidator()
		{
			RuleFor(x => x.Username)
				.NotEmpty();

			RuleFor(x => x.Password)
				.NotEmpty();

		}
	}
}
