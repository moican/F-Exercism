module Hamming

let distance (strand1: string) (strand2: string): int option = 
    if strand1.Length <> strand2.Length then None
    else Seq.fold2 (fun acc x y -> if x <> y then acc+1 else acc) 0 strand1 strand2 |> Some


