# Лабораторная работа №1  
## Задачи  
  1. Задача 15: Начиная в левом верхнем углу сетки 2×2 и имея возможность двигаться только вниз или вправо, существует ровно 6 маршрутов до правого нижнего угла сетки.
  2. Задача 16: Какова сумма цифр числа 2^1000?

## Решение задачи 15  
Рекурсивно проходимся по парам значений, которые характеризуют позицию на сетке, и складываем полученные значения
```
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
```

