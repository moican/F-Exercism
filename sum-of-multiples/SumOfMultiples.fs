module SumOfMultiples

let rec isMultipleOfAny (numbers: int list) (number: int) : bool = 
    match numbers with
        | head :: tail -> number % head = 0 || isMultipleOfAny tail number
        | _ -> false
let sum (numbers: int list) (upperBound: int): int = 
    Seq.fold (fun acc x -> if isMultipleOfAny numbers x then x + acc else acc) 0 [1 .. upperBound - 1]
