module Bob

open System

let isCaps (input : string) = input.ToUpper() = input && input.ToLower() <> input
let isQuestion (input : string) = input.TrimEnd().EndsWith("?")
let meansNothing (input : string) = String.IsNullOrWhiteSpace(input)

let answer input =
    match input with
    | x when meansNothing(x) -> "Fine. Be that way!"
    | x when isQuestion(x) ->
        match x with 
        | y when isCaps(y) ->"Calm down, I know what I'm doing!"
        |_ -> "Sure."
    | x when isCaps(x) -> "Whoa, chill out!"
    | _ -> "Whatever."

let response (input: string): string = input |> answer
