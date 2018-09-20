module TwoFer

let twoFer (input: string option): string = 
    let who = match input with
               | Some i -> i
               | _ -> "you" 
    who |> sprintf "One for %s, one for me."



