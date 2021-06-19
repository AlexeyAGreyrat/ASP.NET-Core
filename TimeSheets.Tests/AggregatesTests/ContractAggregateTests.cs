using FluentAssertions;
using TimeSheets.Domain.Aggregates;
using Xunit;
using TimeSheets.Tests.Build;

namespace TimeSheets.Tests.AggregatesTests
{
	public class ContractAggregateTests
	{
		[Fact]
		public void ContractAggregate_CreateTest()
		{
			//Arrange
			var request = Builder.CreateTestContractCreate();

			//Act
			var contract = ContractAgg.CreateRequest(request);

			// Assert
			contract.NameContract.Should().Be(request.NameContract);
			contract.DateFrom.Should().Be(request.DateFrom);
			contract.DateTo.Should().Be(request.DateTo);
			contract.Annotations.Should().Be(request.Annotations);
			contract.IsDeleted.Should().BeFalse();
		}

		[Fact]
		public void ContractAggregate_UpdateTest()
		{
			//Arrange
			var request = Builder.CreateTestContractCreate();
			var contract = ContractAgg.CreateRequest(request);
			var updateRequest = Builder.CreateTestContractUpdate();

			//Act
			contract.UpdateRequest(updateRequest);

			// Assert
			contract.NameContract.Should().Be(updateRequest.NameContract);
			contract.Annotations.Should().Be(updateRequest.Annotations);

		}


		[Fact]
		public void ContractAggregate_DeletedTest()
		{
			//Arrange
			var request = Builder.CreateTestContractCreate();
			var contract = ContractAgg.CreateRequest(request);

			//Act
			contract.FlagDeleted();

			//Assert
			contract.IsDeleted.Should().BeTrue();
		}

	}
}
