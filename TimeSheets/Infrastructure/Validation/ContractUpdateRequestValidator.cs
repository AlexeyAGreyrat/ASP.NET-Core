using FluentValidation;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Infrastructure.Validation
{
    public class ContractUpdateRequestValidator : AbstractValidator<ContractUpdateRequest>
    {
		public ContractUpdateRequestValidator()
		{
			RuleFor(x => x.NameContract)
				.NotEmpty();

			RuleFor(x => x.Annotations)
				.NotEmpty();

		}
	}
}
