module RefNumberGenerator

open System

let rand = Random()

let bigs = [| 'A' .. 'Z' |]
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
    let create useNumbers useSpecialCharacters length = {
        UseNumbers = useNumbers |> Option.defaultValue false
        UseSpecialCharacters = useSpecialCharacters |> Option.defaultValue false
        Length =
            length
            |> Option.defaultValue (rand.Next(Constants.MinimumAutoLength, Constants.MaximumAutoLength))
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
        | None -> GenerationOptions.create None None

    let pool = buildPool opt
    let output = List.init opt.Length (fun _ -> pool.[rand.Next(pool.Length)])
    String.Concat(output)
