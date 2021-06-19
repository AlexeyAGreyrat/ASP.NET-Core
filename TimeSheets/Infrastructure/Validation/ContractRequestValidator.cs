using FluentValidation;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Infrastructure.Validation
{
	public class ContractRequestValidator : AbstractValidator<ContractRequest>
	{
		public ContractRequestValidator()
		{
			RuleFor(x => x.NameContract)
				.NotEmpty();

			RuleFor(x => x.DateFrom)
				.LessThanOrEqualTo(x => x.DateTo)
				.WithMessage(ValidationsMessages.RequestDateStartError);

			RuleFor(x => x.DateTo)
				.GreaterThanOrEqualTo(x => x.DateFrom)
				.WithMessage(ValidationsMessages.RequestDateEndError);

			RuleFor(x => x.Annotations)
				.NotEmpty();

		}
	}
}
