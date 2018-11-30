module RobotSimulator

type Direction = North | East | South | West
type Position = int * int
type Robot = { direction: Direction; position: Position } 

let advance = fun robot ->
    match robot.direction with
    | East -> { robot with position = fst robot.position + 1, snd robot.position }
    | West -> { robot with position = fst robot.position - 1, snd robot.position }
    | North -> { robot with position = fst robot.position, snd robot.position + 1 }
    | South -> { robot with position = fst robot.position, snd robot.position - 1}

let turnRight = fun robot ->
    match robot.direction with
    | North -> { robot with direction = East }
    | South -> { robot with direction = West }
    | East -> { robot with direction = South }
    | West -> { robot with direction = North }

let turnLeft = fun robot ->
    match robot.direction with
    | North -> { robot with direction = West }
    | South -> { robot with direction = East }
    | East -> { robot with direction = North }
    | West -> { robot with direction = South }

let executeInstruction code = fun x ->
    x |> match code with
         | 'A' -> advance
         | 'L' -> turnLeft
         | 'R' -> turnRight
         | _ -> failwith "Not a valid instruction" 

let create direction position = { direction = direction ; position = position }

let move instructions robot =
    instructions |> Seq.fold(fun accRobot instructionCode -> executeInstruction instructionCode accRobot) robot 
