module RefNumberGenerator

open System

let rand = Random()

let bigs = [| 'A' .. 'Z' |]
let smalls = [| 'a' .. 'z' |]
let numbers = [| '0' .. '9' |]
let specials = [| '_'; '-' |]
let basePool = Array.append bigs smalls

module Constants =
    let MinimumAutoLength = 8
    let MaximumAutoLength = 14
    let MinimumCharacterSetLength = 50

type Configuration = {
    UseNumbers: bool
    UseSpecialCharacters: bool
    Length: int
}

module Configuration =
    let useDefault = {
        UseNumbers = false
        UseSpecialCharacters = false
        Length = rand.Next(Constants.MinimumAutoLength, Constants.MaximumAutoLength)
    }

let private buildPool options =
    let pool =
        match (options.UseNumbers, options.UseSpecialCharacters) with
        | true, true -> basePool |> Array.append numbers |> Array.append specials
        | true, false -> basePool |> Array.append numbers
        | false, true -> basePool |> Array.append specials
        | false, false -> basePool

    pool |> String.Concat

let generate (config: Configuration) =

    let pool = buildPool config
    let output = List.init config.Length (fun _ -> pool.[rand.Next(pool.Length)])
    String.Concat(output)
