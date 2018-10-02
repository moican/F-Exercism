module Raindrops

let IsAFactor factor number = number % factor = 0

let rainDropSound = dict[3,"Pling";5,"Plang";7,"Plong"]

let convert (number: int): string =
    let sound = Seq.fold (fun acc x -> if IsAFactor x number then acc + rainDropSound.Item(x) else acc) "" rainDropSound.Keys
    if sound = "" then number |> string
    else sound

