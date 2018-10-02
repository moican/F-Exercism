module Raindrops2

let IsAFactor factor number = number % factor = 0

let convert (number: int): string =
    match (IsAFactor 3 number,IsAFactor 5 number,IsAFactor 7 number) with
    | true, true, true -> "PlingPlangPlong"
    | true, true, false -> "PlingPlang"
    | true, false, true -> "PlingPlong"
    | true, false, false -> "Pling"
    | false, true, true -> "PlangPlong"
    | false, true, false -> "Plang"
    | false, false, true -> "Plong"
    | false, false, false -> number |> string