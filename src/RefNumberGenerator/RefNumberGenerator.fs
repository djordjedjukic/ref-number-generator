module RefNumberGenerator

open System

let rand = Random()

let bigs = [| 'A' .. 'Y' |]
let smalls = [| 'a' .. 'z' |]
let numbers = [| '0' .. '9' |]
let specials = [| '_'; '-' |]
let basePool = bigs |> Array.append smalls

module Constants =
    let MinimumAutoLength = 8
    let MaximumAutoLength = 14
    let MinimumCharacterSetLength = 50

type GenerationOptions = {
    UseNumbers: bool
    UseSpecialCharacters: bool
    Length: int
}

module GenerationOptions =
    let create useNumbers useSpecialCharacters length =
        let useNumbersValue =
            match useNumbers with
            | Some value -> value
            | None -> false

        let useSpecialCharactersValue =
            match useSpecialCharacters with
            | Some value -> value
            | None -> false

        let lengthValue =
            match length with
            | Some value -> value
            | None -> rand.Next(Constants.MinimumAutoLength, Constants.MaximumAutoLength)

        {
            UseNumbers = useNumbersValue
            UseSpecialCharacters = useSpecialCharactersValue
            Length = lengthValue
        }

let private buildPool options =
    let pool =
        match (options.UseNumbers, options.UseSpecialCharacters) with
        | true, true -> basePool |> Array.append numbers |> Array.append specials
        | true, false -> basePool |> Array.append numbers
        | false, true -> basePool |> Array.append specials
        | false, false -> basePool

    pool |> String.Concat

let generate options =
    let opt =
        match options with
        | Some value -> value
        | None -> GenerationOptions.create None None None

    let pool = buildPool opt
    let output = [ for _ in 1 .. opt.Length -> pool.[rand.Next(pool.Length)] ]
    String.Concat(output)
