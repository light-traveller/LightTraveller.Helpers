# LightTraveller.Helpers
This library is a collection of methods frequently used in everyday work of a .NET programmer. These methods are implemented as extension methods for ease of use.

However, some of the provided methods may not be common ones and have limited use cases, e.g., `ToBase32String` and `FromBase32String`. 
I am keeping them in this library for my own reference and also because they are rarely implemented.

More complete test coverage as well as XML documentation for IntelliSense assistance will be added later.

## Some Examples

### Checking for Null-or-Empty strings
```csharp
if (string.IsNullOrWhiteSpace(str))
    DoSomething();

// can be changed to

if (str.Empty())
    DoSomething();
```
### Case-insensitive String Comparison
```csharp
firstString.Equals(second, StringComparison.OrdinalIgnoreCase)

// can be changed to

firstString.EasyEquals(second)
```

### Cancellation of a Task
```csharp
if (cancellationToken.IsCancellationRequested)
    cancellationToken.ThrowIfCancellationRequested();

// can be changed to

cancellationToken.CheckThrow();
```

## Installation
You can add the Nuget package of **LightTraveller.Helpers** by running the following command in the .NET CLI

`dotnet add package LightTraveller.Helpers --version <VERSION NUMBER>`

For more information please go to the [nuget.org page of this library](https://www.nuget.org/packages/LightTraveller.Helpers).