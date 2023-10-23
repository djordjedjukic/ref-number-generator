# RefNumberGenerator

This is a library for generation reference numbers.


## Usage/Examples

Using with default options

```csharp
let resultWithoutOptions = generate None
```

Using with custom options

```csharp
let options = { UseNumbers = true; UseSpecialCharacters = false; Length = 10 }
let resultWithOptions = generate (Some options)

```

