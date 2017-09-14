using System;

namespace Archon
{
	/// <summary>
	/// Aids in unit testing by providing a mockable way to get the current time.
	/// </summary>
	public interface SystemClock
	{
		/// <summary>
		/// Gets the current time in UTC
		/// </summary>
		DateTime UtcNow { get; }

		/// <summary>
		/// Gets the current local time
		/// </summary>
		DateTime Now { get; }
	}
}