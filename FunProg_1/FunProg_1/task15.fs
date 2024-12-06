module task15

open System.Collections.Generic

//recurtion + pattern matching
let solution15 x y =
    let rec latticePaths x y memo =
        match x, y with
        | 0, _ 
        | _, 0 -> 1L, memo
        | _ when Map.containsKey (x, y) memo ->
            memo.[(x, y)], memo
        | _ ->
            let leftPaths, memo' = latticePaths (x - 1) y memo
            let downPaths, memo'' = latticePaths x (y - 1) memo'
            let result = leftPaths + downPaths
            result, Map.add (x, y) result memo''
    fst (latticePaths x y Map.empty)
