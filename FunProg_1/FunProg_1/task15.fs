module task15

open System.Collections.Generic

//recurtion + pattern matching
let solution15 x y = 
    let mutable memo = Dictionary<(int * int), int64>()
    let rec latticePaths x y : int64 =
        match x, y with
        | 0, _
        | _, 0 -> 1
        | _, _ when memo.ContainsKey((x, y))
            -> memo.[(x, y)]
        | x, y -> let result = latticePaths (x - 1) y + latticePaths x (y - 1)
                  memo.Add((x, y), result)
                  result
    latticePaths x y