# RefNumberGenerator

This is a library for generation reference numbers.


## Usage/Examples

Using with default options

```csharp
generate None
```

Using with custom options

```csharp
let options = GenerationOptions.create (Some true) None (Some 10)
generate (Some options)
```

