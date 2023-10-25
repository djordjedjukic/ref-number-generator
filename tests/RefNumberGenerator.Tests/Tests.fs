module Tests

open System
open System.Text.RegularExpressions
open Xunit
open RefNumberGenerator

[<Fact>]
let ``Default configuration`` () =
    let ref1 = generate Configuration.useDefault
    let onlyLetters = Regex.IsMatch(ref1, @"^[a-zA-Z]+$")
    let properLength = ref1.Length < Constants.MaximumAutoLength && ref1.Length > Constants.MinimumAutoLength 
    Assert.True(onlyLetters)
    Assert.True(properLength)
    
[<Fact>]
let ``Custom configuration`` () =
    let options = {
        UseNumbers = true
        UseSpecialCharacters = true
        Length = 10
    }    
    let ref1 = generate options
    
    let lettersNumbersSpecial = Regex.IsMatch(ref1, @"^[a-zA-Z0-9_-]+$");
    let properLength = ref1.Length = 10 
    Assert.True(lettersNumbersSpecial)
    Assert.True(properLength)