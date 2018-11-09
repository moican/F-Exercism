module KindergartenGarden

type Plant = Clover|Grass|Radishes|Violets

let StringToPlant str =
    match str with
    | 'C' -> Clover
    | 'G' -> Grass
    | 'R' -> Radishes
    | 'V' -> Violets
    | _ -> failwith "Invalid string"

let students = ["Alice"; "Bob"; "Charlie"; "David"; "Eve"; "Fred"; "Ginny"; "Harriet"; "Ileana"; "Joseph"; "Kincaid"; "Larry"]

let plants (diagram : string) student = 
    let index = List.findIndex (fun elem -> elem = student) students
    let rows = diagram.Split '\n'
    
    seq {
        yield StringToPlant(rows.[0].[index * 2])
        yield StringToPlant(rows.[0].[(index * 2) + 1])
        yield StringToPlant(rows.[1].[index * 2])
        yield StringToPlant(rows.[1].[(index * 2) + 1])
    } |> Seq.toList
