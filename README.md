# Archon Time Utilities

> Time-related utility classes that will help in testing apps that rely on dates and times for logic.

## How to Use

Install via [nuget](https://www.nuget.org/packages/Archon.Time/)

```
dotnet add Archon.Time
```

The following utilities can be found in the `Archon` namespace.

### `SystemClock`

You can use the `SystemClock` interface in the same places you were previously using `System.DateTime.UtcNow`:

```cs
SystemClock clock = new RealSystemClock();

DateTime utcNow = clock.UtcNow;
DateTime now = clock.Now;
```

This is not very useful by itself, but when writing tests for components that depend on the current time, you can inject a `FrozenSystemClock` instead:

```cs
public class Component
{
	readonly SystemClock clock;

	public Component(SystemClock clock)
	{
		this.clock = clock;
	}

	public string SayHello()
	{
		if (clock.Now.Hour >= 12)
		{
			return "Good afternoon";
		}
		else
		{
			return "Good morning";
		}
	}
}

public class Tests
{
	readonly FrozenSystemClock clock;
	readonly Component component;

	public Tests()
	{
		clock = new FrozenSystemClock(); // will freeze the clock at the current time
		component = new Component(clock);
	}

	[Xunit.Fact]
	public void ShouldSayGoodMorning()
	{
		DateTime nineam = new DateTime(2017, 9, 14, 9, 00, 00, DateTimeKind.Local).ToUniversalTime();
		clock.Reset(nineam); // reset to 9am
		Assert.Equal("Good morning", component.SayHello());
	}

	[Xunit.Fact]
	public void ShouldSayGoodAfternoon()
	{
		DateTime twopm = new DateTime(2017, 9, 14, 14, 00, 00, DateTimeKind.Local).ToUniversalTime();
		clock.Reset(twopm); // reset to 2pm
		Assert.Equal("Good afternoon", component.SayHello());
	}
}

```

If you just create a new `FrozenSytemClock` using the default constructor, it will freeze the current time. You can also use the overload that takes a specific time to freeze. It has a number of convenience methods on it for adding months, days, seconds, etc. to the current frozen time to allow you to move time backwards and forwards within your tests.

### `AssumeUtc`

Given a `DateTime`, it will ensure that the `DateTimeKind` is set to `Utc` if the current kind is `Unspecified`. If it is set to `Local`, it will throw an exception.

```cs
DateTime time = new DateTime(2016, 02, 22, 13, 52, 46); //Kind is Unspecified by default

DateTime utc = time.AssumeUtc("time"); //Kind is now set to Utc
```

The single `string` parameter it takes is just to customize the exception it throws if the `Kind` is set to `Local`.
