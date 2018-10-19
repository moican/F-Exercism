module GradeSchool

open System

type School = Map<int, string list>

let empty: School = Map.empty

let add (student: string) (grade: int) (school: School): School =
    school.Add(grade, 
        List.sort(
            match school.TryFind grade with
            | Some v -> v @ [student] 
            | None -> [student]))
   
let roster (school: School): (int * string list) list = 
    school |> Seq.map (|KeyValue|)|> List.ofSeq
       
let grade (number: int) (school: School): string list = 
    defaultArg (Map.tryFind number school) []
