using FluentAssertions;
using System;
using System.Collections.Generic;
using TimeSheets.Domain.ValueObjects;
using Xunit;

namespace TimeSheets.Tests.ValueObjectsTests
{
	public class SpentTimeValueObjectTests
	{
		
		public static IEnumerable<object[]> GoodDateTest()
		{
			yield return new object[] { new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 } };
		}

		[Theory]
		[MemberData(nameof(GoodDateTest))]
		public void CreateGoodAmount(int[] data)
		{
			for (int i = 0; i < data.Length; i++)
			{
				var spentTime = SpentTime.FromInt(data[i]);
				spentTime.Amount.Should().Be(data[i]);
			}

		}

		public static IEnumerable<object[]> BadDateTest()
		{
			yield return new object[] { new int[] { -1, 9, 20, 30 } };
		}

		[Theory]
		[MemberData(nameof(BadDateTest))]
		public void CreateWrongAmount(int[] data)
		{
			for (int i = 0; i < data.Length; i++)
			{
				Action act = () => SpentTime.FromInt(data[i]);
				act.Should().Throw<ArgumentException>();
			}

		}

	}
}
