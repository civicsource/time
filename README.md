# Archon Time Utilities

> Time-related utility classes that will help in testing apps that rely on dates and times for logic.

## How to Use

Install via [nuget](https://www.nuget.org/packages/Archon.Time/)

```
dotnet add Archon.Time
```

The following utilities can be found in the `Archon` namespace.

### `SystemClock`

You can use `SystemClock` the same way you would use `System.DateTime`:

```cs
DateTime utcNow = SystemClock.UtcNow;
DateTime now = SystemClock.Now;
```

You can freeze the current time by setting one of the properties:

```cs
SystemClock.UtcNow = new DateTime(2016, 02, 22, 13, 52, 46); //freeze the current time

DateTime utcNow = SystemClock.UtcNow; //will equal the frozen Time
DateTime now = SystemClock.Now; //will equal the frozen time offset by the current timezone

SystemClock.Reset(); //SystemClock.UtcNow & Now will return the current time once again
```

This allows you to mock the current time for test cases when testing logic that requires date/time manipulations.

### `AssumeUtc`

Given a `DateTime`, it will ensure that the `DateTimeKind` is set to `Utc` if the current kind is `Unspecified`. If it is set to `Local`, it will throw an exception.

```cs
DateTime time = new DateTime(2016, 02, 22, 13, 52, 46); //Kind is Unspecified by default

DateTime utc = time.AssumeUtc("time"); //Kind is now set to Utc
```

The single `string` parameter it takes is just to customize the exception it throws if the `Kind` is set to `Local`.
