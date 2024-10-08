open System
open task15
open task16


[<EntryPoint>]
let main (argv: string array) =

    printf "Пути через таблицу. Задача 15:"
    printfn "Recurtion + pattern matching  = %d" (solution15 20 20)

    printfn "Сумма цифр степени. Задача 16:"
    printfn "recurtion loop + Array.reduce = %d" (solution16_1)
    printfn "recurtion + pattern matching = %d" (solution16_2 2I 1000)
    printfn "tail recurtion + pattern matching = %d" (solution16_3 2I 1000)
    printfn "sequence + List.map = %d" (solution16_4 1000)
    0