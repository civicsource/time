using System;

namespace Archon
{
	/// <summary>
	/// Implementation of SystemClock which just uses the current DateTime.UtcNow
	/// </summary>
	public class RealSystemClock : SystemClock
	{
		/// <summary>
		/// The current time in UTC
		/// </summary>
		public DateTime UtcNow => DateTime.UtcNow;

		/// <summary>
		/// The current time in local time
		/// </summary>
		public DateTime Now => DateTime.Now;
	}
}