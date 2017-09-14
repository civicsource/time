using System;

namespace Archon
{
	/// <summary>
	/// Provides utility extension methods to DateTime
	/// </summary>
	public static class DateTimeExtensions
	{
		/// <summary>
		/// Assume the DateTime is UTC. If the kind is unspecified, it will be coerced to UTC. If the kind is Local, an ArgumentException will be thrown.
		/// </summary>
		/// <param name="date">The datetime to check</param>
		/// <param name="name">The name of the parameter being checked (to be used when throwing an exception)</param>
		/// <returns>The specified DateTime but with a kind of UTC</returns>
		public static DateTime AssumeUtc(this DateTime date, string name)
		{
			if (date.Kind == DateTimeKind.Unspecified)
				return DateTime.SpecifyKind(date, DateTimeKind.Utc);

			if (date.Kind == DateTimeKind.Local)
				throw new ArgumentException(name, "Value must be a UTC datetime.");

			return date;
		}

		/// <summary>
		/// Assume the DateTime is UTC. If the kind is unspecified, it will be coerced to UTC. If the kind is Local, an ArgumentException will be thrown.
		/// </summary>
		/// <param name="date">The datetime to check</param>
		/// <param name="name">The name of the parameter being checked (to be used when throwing an exception)</param>
		/// <returns>The specified DateTime but with a kind of UTC</returns>
		public static DateTime? AssumeUtc(this DateTime? date, string name)
		{
			if (!date.HasValue)
				return null;
			return AssumeUtc(date.Value, name);
		}
	}
}