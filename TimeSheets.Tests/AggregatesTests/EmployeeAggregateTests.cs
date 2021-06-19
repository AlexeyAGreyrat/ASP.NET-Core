using FluentAssertions;
using TimeSheets.Domain.Aggregates;
using Xunit;
using TimeSheets.Tests.Build;

namespace TimeSheets.Tests.AggregatesTests
{
	public class EmployeeAggregateTests
	{
		[Fact]
		public void EmployeeAggregate_CreateTest()
		{
			//Arrange
			var request = Builder.CreateTestEmployeeCreate();

			//Act
			var employee = EmployeeAgg.CreateRequest(request);

			// Assert
			employee.UserId.Should().Be(request.UserId);
			employee.IsDeleted.Should().BeFalse();

		}

		[Fact]
		public void EmployeeAggregate_DeletedTest()
		{
			//Arrange
			var request = Builder.CreateTestEmployeeCreate();
			var employee = EmployeeAgg.CreateRequest(request);

			//Act
			employee.FlagDeleted();

			//Assert
			employee.IsDeleted.Should().BeTrue();
		}

	}
}
