using FluentValidation;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Infrastructure.Validation
{
	public class InvoiceRequestValidator : AbstractValidator<InvoiceRequest>
	{
		public InvoiceRequestValidator()
		{
			RuleFor(x => x.ContractId)
				.NotEmpty();

			RuleFor(x => x.DateFrom)
				.LessThanOrEqualTo(x => x.DateTo)
				.WithMessage(ValidationsMessages.RequestDateStartError);

			RuleFor(x => x.DateTo)
				.GreaterThanOrEqualTo(x => x.DateFrom)
				.WithMessage(ValidationsMessages.RequestDateEndError);

		}
	}
}
