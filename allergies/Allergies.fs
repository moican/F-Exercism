module Allergies

open System

[<Flags>]
type Allergen =
    | Eggs = 1
    | Peanuts = 2
    | Shellfish = 4
    | Strawberries = 8
    | Tomatoes = 16
    | Chocolate = 32
    | Pollen = 64
    | Cats = 128

let allergenValues : Allergen seq = unbox (Enum.GetValues(typeof<Allergen>))

let allergicTo (codedAllergies: int) (allergen: Allergen) = codedAllergies &&& int allergen <> 0

let list codedAllergies = allergenValues |> Seq.filter (fun x -> allergicTo codedAllergies x) |> Seq.toList