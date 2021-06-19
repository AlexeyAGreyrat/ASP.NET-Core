using FluentAssertions;
using System;
using TimeSheets.Domain.ValueObjects;
using Xunit;

namespace TimeSheets.Tests.ValueObjectsTests
{
	public class MoneyValueObjectTests
	{
		[Fact]
		public void CreateGoodAmountTest()
		{
			//Arrange
			var amount = (decimal)(new Random().NextDouble());

			//Act
			var money = Money.FromDecimal(amount);

			//Assert
			money.Amount.Should().Be(amount);
		}

		[Fact]
		public void CreateNegativeAmountTest()
		{
			//Arrange
			var amount = -1.0;

			//Act
			Action act = () => Money.FromDecimal((decimal)amount);

			//Assert
			act.Should().Throw<ArgumentException>();
			
		}

	}
}
