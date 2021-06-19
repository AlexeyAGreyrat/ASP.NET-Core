using System;
using System.Diagnostics.CodeAnalysis;

namespace TimeSheets.Infrastructure.Extensions
{
	public static class DateTimeExtensions
	{
		private static readonly DateTime origin =
			new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

		public static long Origin(this DateTime dateTime) => (long)(dateTime - origin).TotalSeconds;
	}
}
