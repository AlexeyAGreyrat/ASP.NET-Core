using FluentValidation;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Infrastructure.Validation
{
	public class SheetRequestValidator : AbstractValidator<SheetRequest>
	{
		public SheetRequestValidator()
		{
			RuleFor(x => x.Hour)
				.InclusiveBetween(1, 8)
				.WithMessage(ValidationsMessages.SheetAmountError);

			RuleFor(x => x.ContractId)
				.NotEmpty()
				.WithMessage(ValidationsMessages.InvalidValue);

		}
	}
}
