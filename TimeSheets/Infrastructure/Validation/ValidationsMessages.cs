namespace TimeSheets.Infrastructure.Validation
{
	public class ValidationsMessages
	{
		public const string SheetAmountError = "Hour should be between 1 and 8.";
		public const string InvalidValue = "Incorrect value";
		public const string RequestDateStartError = "Start date should be less or equal than end date";
		public const string RequestDateEndError = "End date should be greater or equal than end date";
	}
}
