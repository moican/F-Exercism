module Pangram

open System


let isPangram (input: string): bool = 
    let alphabet = ['a'..'z']
    let sortedInput = input.ToLowerInvariant()
    Seq.fold (fun acc (x : char) -> if sortedInput.Contains(x) then acc else false) false alphabet

