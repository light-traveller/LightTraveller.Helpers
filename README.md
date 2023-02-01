# LightTraveller.Helpers
This library is a collection of methods frequently used in everyday work of a .NET programmer. These methods are implemented as extension methods for ease of use.

However, some of the provided methods may not be common ones and have limited use cases, e.g., `ToBase32String` and `FromBase32String`. 
I am keeping them in this library for my own reference and also because they are rarely implemented.

## Some Examples

### Checking for Null-or-Empty strings
```csharp
// Instead of
string.IsNullOrWhiteSpace(value)
// You can write
value.Empty()
```
### Case-insensitive String Comparison
```csharp
// Instead of
string1.Equals(string2, StringComparison.OrdinalIgnoreCase)
// You can write
string1.EasyEquals(string2)

// or

// Instead of
string1.StartsWith(string2, StringComparison.OrdinalIgnoreCase)
// You can write
string1.EasyStartsWith(string2)
```
## Installation
You can add the Nuget package of **LightTraveller.Helpers** by running the following command in the .NET CLI

`dotnet add package LightTraveller.Helpers --version <VERSION NUMBER>`

For more information please go to the [nuget.org page of this library](https://www.nuget.org/packages/LightTraveller.Helpers).

## To Do
- [x] XML documentation
- [ ] Full test coverage