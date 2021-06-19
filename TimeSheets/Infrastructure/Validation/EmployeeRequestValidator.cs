using FluentValidation;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Infrastructure.Validation
{
    public class EmployeeRequestValidator : AbstractValidator<EmployeeRequest>
    {
		public EmployeeRequestValidator()
		{
			RuleFor(x => x.UserId)
				.NotEmpty();

			

		}
	}
}
