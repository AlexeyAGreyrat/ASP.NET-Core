using FluentAssertions;
using TimeSheets.Domain.Aggregates;
using Xunit;
using TimeSheets.Tests.Build;

namespace TimeSheets.Tests.AggregatesTests
{
	public class ClientAggregateTests
	{
		[Fact]
		public void ClientAggregate_CreateTestRequest()
		{
			//Arrange
			var request = Builder.CreateTestClientCreate();

			//Act
			var client = ClientAgg.CreateRequest(request);

			// Assert
			client.UserId.Should().Be(request.UserId);
			client.IsDeleted.Should().BeFalse();

		}

		[Fact]
		public void ClientAggregate_DeletedTest()
		{
			//Arrange
			var request = Builder.CreateTestClientCreate();
			var client = ClientAgg.CreateRequest(request);

			//Act
			client.FlagDeleted();

			//Assert
			client.IsDeleted.Should().BeTrue();
		}

	}
}
