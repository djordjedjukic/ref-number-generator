# RefNumberGenerator

This is a library for generation reference numbers.


## Usage/Examples

Using with default options

```csharp
let ref1 = generate Configuration.useDefault
let ref2 = generate Configuration.useDefault
let ref3 = generate Configuration.useDefault
```

Using with custom options

```csharp
let options = {
    UseNumbers = true
    UseSpecialCharacters = true
    Length = 10
}

let ref1 = generate options
let ref2 = generate options
let ref3 = generate options
```

Configure once

```csharp
let options = {
    UseNumbers = true
    UseSpecialCharacters = true
    Length = 10
}

let generateNext () = generate options

let ref1 = generateNext ()
let ref2 = generateNext ()
let ref3 = generateNext ()
```

