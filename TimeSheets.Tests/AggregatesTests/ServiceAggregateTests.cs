using FluentAssertions;
using TimeSheets.Domain.Aggregates;
using TimeSheets.Tests.Build;
using Xunit;

namespace TimeSheets.Tests.AggregatesTests
{
	public class ServiceAggregateTests
	{
		[Fact]
		public void ServiceAggregate_CreateTest()
		{
			//Arrange
			var request = Builder.CreateTestService();

			//Act
			var service = ServiceAggregate.CreateRequest(request);

			// Assert
			service.Name.Should().Be(request.Service);
			service.IsDeleted.Should().BeFalse();

		}

		[Fact]
		public void ServiceAggregate_UpdateTest()
		{
			//Arrange
			var request = Builder.CreateTestService();
			var service = ServiceAggregate.CreateRequest(request);
			var updateRequest = Builder.CreateTestService();

			//Act
			service.UpdateRequest(updateRequest);

			// Assert
			service.Name.Should().Be(updateRequest.Service);
		}



		[Fact]
		public void ServiceAggregate_DeletedTest()
		{
			//Arrange
			var request = Builder.CreateTestService();
			var service = ServiceAggregate.CreateRequest(request);

			//Act
			service.FlagDeleted();

			//Assert
			service.IsDeleted.Should().BeTrue();
		}

	}
}
