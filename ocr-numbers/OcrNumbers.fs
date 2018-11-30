module OcrNumbers

//let hasCorrectSize (input : list<list<int>>) bool =
//    let first = input.Length % 4 <> 0 
//    let incorrect = List.filter (fun x -> x.Length % 3 <> 0) input
//    let second = incorrect.Length = 0
//    first || second

let zero =  [[0; 1; 1; 0];[2; 0; 2; 0];[0; 1; 1; 0]]
let one =   [[0; 0; 0; 0];[0; 0; 0; 0];[0; 1; 1; 0]]
let two =   [[0; 0; 1; 0];[2; 2; 2; 0];[0; 1; 0; 0]]
let three = [[0; 0; 0; 0];[2; 2; 2; 0];[0; 1; 1; 0]]
let four =  [[0; 1; 0; 0];[0; 2; 0; 0];[0; 1; 1; 0]]
let five =  [[0; 1; 0; 0];[2; 2; 2; 0];[0; 0; 1; 0]]
let six =   [[0; 1; 1; 0];[2; 2; 2; 0];[0; 0; 1; 0]]
let seven = [[0; 0; 0; 0];[2; 0; 0; 0];[0; 1; 1; 0]]
let eight = [[0; 1; 1; 0];[2; 2; 2; 0];[0; 1; 1; 0]]
let nine =  [[0; 1; 0; 0];[2; 2; 2; 0];[0; 1; 1; 0]]

let matchNumber array =
    if array = zero then "0"
    elif array = one then "1"
    elif array = two then "2"
    elif array = three then "3"
    elif array = four then "4"
    elif array = five then "5"
    elif array = six then "6"
    elif array = seven then "7"
    elif array = eight then "8"
    elif array = nine then "9"
    else "?"

let charToNumber = fun x -> 
    match x with
    |' ' -> 0
    |'_' -> 2
    |'|' -> 1
    | _ -> 4

let charArrayToNumber = fun x -> List.map (fun c -> charToNumber(c)) x

let rec transpose = function
| [] -> failwith "empty"
| []::xs -> [] 
| xs -> List.map List.head xs :: transpose (List.map List.tail xs)

let toCharList input = List.map (fun x -> x |> Seq.toList) input
let toIntList input = List.map (fun x -> charArrayToNumber x) input

let toFontLang input = input |> toCharList |> toIntList |> transpose

let hasCorrectSize (input : string list) =
    if input.Length % 4 <> 0 then false
    else List.exists (fun x -> (x |> String.length) % 3 <> 0) input |> not
        
let convertNumber input =
    input |> toFontLang |> List.chunkBySize 3 |> List.fold (fun acc x -> acc + matchNumber(x)) ""
    
let convert (input : string list) = 
    if hasCorrectSize input |> not then None
    else
        let strValue = input |> List.chunkBySize 4 |> List.fold (fun acc x -> acc + convertNumber(x) + "," ) "" 
        strValue.Substring(0, strValue.Length - 1) |> Some



