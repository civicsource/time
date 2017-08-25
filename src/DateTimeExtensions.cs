using System;

namespace Archon
{
	public static class DateTimeExtensions
	{
		public static DateTime AssumeUtc(this DateTime date, string name)
		{
			if (date.Kind == DateTimeKind.Unspecified)
				return DateTime.SpecifyKind(date, DateTimeKind.Utc);

			if (date.Kind == DateTimeKind.Local)
				throw new ArgumentException(name, "Value must be a UTC datetime.");

			return date;
		}

		public static DateTime? AssumeUtc(this DateTime? date, string name)
		{
			if (!date.HasValue)
				return null;
			return AssumeUtc(date.Value, name);
		}
	}
}