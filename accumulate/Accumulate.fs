module Accumulate

let accumulate<'a, 'b> (func: 'a -> 'b) (input: 'a list): 'b list = 
    let rec accumulateImp func acc = function
        |head :: tail -> accumulateImp func (acc @ [func head]) tail
        |[] -> acc

    accumulateImp func [] input