using System;

namespace Archon
{
	/// <summary>
	/// Frozen implementation of SystemClock
	/// </summary>
	public class FrozenSystemClock : SystemClock
	{
		DateTime frozen;

		/// <summary>
		/// Gets the current frozen time in UTC
		/// </summary>
		public DateTime UtcNow => frozen;

		/// <summary>
		/// Gets the current frozen time in local time
		/// </summary>
		public DateTime Now => frozen.ToLocalTime();

		/// <summary>
		/// Creates a new instance using the current UTC time as the frozen time
		/// </summary>
		public FrozenSystemClock()
			: this(DateTime.UtcNow) { }

		/// <summary>
		/// Creates a new instance using the specified UTC frozen time
		/// </summary>
		/// <param name="frozenTimeUtc">The UTC time to freeze</param>
		public FrozenSystemClock(DateTime frozenTimeUtc)
		{
			Reset(frozenTimeUtc);
		}

		/// <summary>
		/// Reset the current frozen time to DateTime.UtcNow
		/// </summary>
		public DateTime Reset()
		{
			return Reset(DateTime.UtcNow);
		}

		/// <summary>
		/// Reset the current frozen time to the specified UTC time
		/// </summary>
		/// <param name="frozenTimeUtc">The UTC time to freeze</param>
		public DateTime Reset(DateTime frozenTimeUtc)
		{
			frozen = frozenTimeUtc.AssumeUtc(nameof(frozenTimeUtc));
			return frozen;
		}

		/// <summary>
		/// Add years to the current frozen time
		/// </summary>
		/// <param name="value">The number of years</param>
		public DateTime AddYears(int value)
		{
			frozen = frozen.AddYears(value);
			return frozen;
		}

		/// <summary>
		/// Add months to the current frozen time
		/// </summary>
		/// <param name="value">The number of months</param>
		public DateTime AddMonths(int value)
		{
			frozen = frozen.AddMonths(value);
			return frozen;
		}

		/// <summary>
		/// Add days to the current frozen time
		/// </summary>
		/// <param name="value">The number of days</param>
		public DateTime AddDays(double value)
		{
			frozen = frozen.AddDays(value);
			return frozen;
		}

		/// <summary>
		/// Add hours to the current frozen time
		/// </summary>
		/// <param name="value">The number of hours</param>
		public DateTime AddHours(double value)
		{
			frozen = frozen.AddHours(value);
			return frozen;
		}

		/// <summary>
		/// Add minutes to the current frozen time
		/// </summary>
		/// <param name="value">The number of minutes</param>
		public DateTime AddMinutes(double value)
		{
			frozen = frozen.AddMinutes(value);
			return frozen;
		}

		/// <summary>
		/// Add seconds to the current frozen time
		/// </summary>
		/// <param name="value">The number of seconds</param>
		public DateTime AddSeconds(double value)
		{
			frozen = frozen.AddSeconds(value);
			return frozen;
		}

		/// <summary>
		/// Returns a value indicating whether this instance is equal to a specified object.
		/// </summary>
		/// <param name="obj">The object to compare to this instance.</param>
		/// <returns>true if value is an instance of System.DateTime or FrozenSystemClock and equals the value of this instance's frozen time; otherwise, false.</returns>
		public override bool Equals(object obj)
		{
			if (obj is FrozenSystemClock fro)
				return frozen.Equals(fro.frozen);

			return frozen.Equals(obj);
		}

		/// <summary>
		/// Gets the hash code of the current frozen time
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return frozen.GetHashCode();
		}

		/// <summary>
		/// Returns the current frozen time as a string
		/// </summary>
		/// <returns>The current frozen time as a string</returns>
		public override string ToString()
		{
			return frozen.ToString();
		}
	}
}