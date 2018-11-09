module Clock

let inline (%!) a b = (a % b + b) % b

type clock = { TotalMinutes:int } with
    override self.ToString() = sprintf "%02i:%02i" (self.TotalMinutes / 60) (self.TotalMinutes % 60)

let minutesInDay = 1440
let normalizeTo1440 x = 
   let a = x % minutesInDay
   let b = x / minutesInDay
   if x >= 0 then x % minutesInDay
   else (minutesInDay * b) + a + ((b-1) * -minutesInDay)

let create hours minutes = { TotalMinutes = normalizeTo1440 ((hours * 60) + minutes) }

let add minutes clock = { clock with TotalMinutes = normalizeTo1440 (clock.TotalMinutes + minutes)  }

let subtract minutes clock = { clock with TotalMinutes = normalizeTo1440 (clock.TotalMinutes - minutes) }

let display clock = clock.ToString()

