using System;

namespace Archon
{
	/// <summary>
	/// Aids in unit testing by providing a mockable way to get the current time.
	/// </summary>
	public static class SystemClock
	{
		private static DateTime? _utcNow;

		public static DateTime UtcNow
		{
			get
			{
				if (_utcNow.HasValue)
					return _utcNow.Value;
				return DateTime.UtcNow;
			}
			set { _utcNow = value; }
		}

		public static DateTime Now
		{
			get { return UtcNow.ToLocalTime(); }
			set { UtcNow = value.ToUniversalTime(); }
		}

		public static void Reset()
		{
			_utcNow = null;
		}
	}
}