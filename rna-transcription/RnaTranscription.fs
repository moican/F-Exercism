module RnaTranscription

open System

let toRna (dna: string): string = 
    dna |> Seq.map (fun c ->
        match c with
        | 'G' -> 'C'
        | 'C' -> 'G'
        | 'T' -> 'A'
        | 'A' -> 'U'
        | _ -> failwith "invalid nucletoid"
        ) |> Array.ofSeq |> String