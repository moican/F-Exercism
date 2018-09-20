module DifferenceOfSquares

let squareOfSum (number: int): int = 
    let sum = Seq.sumBy (fun x -> x) [1..number]
    sum * sum

let sumOfSquares (number: int): int = Seq.sumBy (fun x -> x * x) [1..number]

let differenceOfSquares (number: int): int = squareOfSum number - sumOfSquares number
