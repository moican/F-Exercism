module QueenAttack

let create (row, column) = 
    let insideRange inclusiveRangeStart exclusiveRangeEnd number =
        number >= inclusiveRangeStart && number < exclusiveRangeEnd

    insideRange 0 8 row && insideRange 0 8 column

let canAttack (row1, column1) (row2, column2) = 
    row1 = row2 || column1 = column2 || abs (column1 - column2) = abs (row1 - row2)



