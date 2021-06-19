using FluentAssertions;
using System;
using TimeSheets.Domain.Aggregates;
using Xunit;
using TimeSheets.Tests.Build;

namespace TimeSheets.Tests.AggregatesTests
{
	public class SheetAggregateTests
	{

		[Fact]
		public void SheetAggregate_CreateTest()
		{
			//Arrange
			var request = Builder.CreateTestSheetCreate();

			//Act
			var sheet = SheetAgg.CreateRequest(request);

			// Assert
			sheet.Amount.Amount.Should().Be(request.Hour);
			sheet.ContractId.Should().Be(request.ContractId);
			sheet.EmployeeId.Should().Be(request.EmployeeId);
			sheet.ServiceId.Should().Be(request.ServiceId);
			sheet.Date.Should().Be(request.Date);

		}

		[Fact]
		public void SheetAggregate_ApprovedTest()
		{
			//Arrange
			var request = Builder.CreateTestSheetCreate();
			var sheet = SheetAgg.CreateRequest(request);

			//Act
			sheet.ApproveSheet();

			//Assert
			sheet.IsApproved.Should().BeTrue();
			sheet.ApprovedDate.Should().BeCloseTo(DateTime.Now);
		}

		[Fact]
		public void SheetAggregate_DeletedTest()
		{
			//Arrange
			var request = Builder.CreateTestSheetCreate();
			var sheet = SheetAgg.CreateRequest(request);

			//Act
			sheet.FlagDeleted();

			//Assert
			sheet.IsDeleted.Should().BeTrue();
		}

	}
}
