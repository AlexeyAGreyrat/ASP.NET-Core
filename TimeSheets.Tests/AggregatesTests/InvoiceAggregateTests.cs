using FluentAssertions;
using System.Collections.Generic;
using TimeSheets.Domain.Aggregates;
using TimeSheets.Tests.Build;
using Xunit;

namespace TimeSheets.Tests.AggregatesTests
{
	public class InvoiceAggregateTests
	{
		[Fact]
		public void InvoiceAggregate_CreateTest()
		{
			//Arrange
			var request = Builder.CreateTestInvoiceCreate();

			//Act
			var invoice = InvoiceAgg.CreateRequest(request);

			//Assert
			invoice.ContractId.Should().Be(request.ContractId);
			invoice.DateFrom.Should().Be(request.DateFrom);
			invoice.DateTo.Should().Be(request.DateTo);
			invoice.IsDeleted.Should().BeFalse();

		}

		[Fact]
		public void InvoiceAggregate_CalculateSumTest()
		{
			//Arrange
			var request = Builder.CreateTestInvoiceCreate();
			var invoice = InvoiceAgg.CreateRequest(request);

			var sheets = new List<SheetAgg>();			
			var sheetRequest = Builder.CreateTestSheetCreate();
			sheets.Add(SheetAgg.CreateRequest(sheetRequest));

			//Act
			invoice.IncludeSheets(sheets);

			//Assert
			invoice.Sum.Amount.Should().BeGreaterThan(0);
			invoice.Sheets.Count.Should().Be(sheets.Count);
		}

		[Fact]
		public void InvoiceAggregate_DeletedTest()
		{
			//Arrange
			var request = Builder.CreateTestInvoiceCreate();
			var invoice = InvoiceAgg.CreateRequest(request);

			//Act
			invoice.FlagDeleted();

			//Assert
			invoice.IsDeleted.Should().BeTrue();
		}

	}
}
