# Лабораторная работа №1  
## Задачи  
  1. Задача 15: Начиная в левом верхнем углу сетки 2×2 и имея возможность двигаться только вниз или вправо, существует ровно 6 маршрутов до правого нижнего угла сетки.
  2. Задача 16: Какова сумма цифр числа 2^1000?

## Решение задачи 15 
1. Рекурсия + pattern matching
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
## Решение задачи 16
1. Рекурсия + Array.reduce
```
let solution16_1 =
    let arr = Array.zeroCreate 350
    arr.[0] <- 2
    let mutable num = 0
    let mutable dexNum = 0
    let rec forLoop (arr : int array) times =
        if times = 1 then ()
        else 
            dexNum <- 0
            for i in 0..349 do
                num <- arr.[i] * 2 + dexNum
                arr.[i] <- num % 10
                dexNum <- num / 10
            forLoop arr (times - 1)
    
    forLoop arr 1000

    let sum (acc : int) item = acc + item
    Array.reduce sum arr
```
2. Рекурсия + pattern matching
Делаем рекурсивное умножение с использованием типа BigInt
```
let solution16_2 b exp =
    let rec recursivePower b exp =
        match exp with
        | 0 -> BigInteger.One
        | _ when exp % 2 = 0 ->
            let halfPow = recursivePower b (exp / 2)
            halfPow * halfPow
        | _ ->
            b * recursivePower b (exp - 1)

    let rec sumOfDigits n =
        if n = BigInteger.Zero then
            0
        else
            let digit = int (n % 10I)
            digit + sumOfDigits (n / 10I)

    let result2 = recursivePower b exp
    sumOfDigits result2
```
3. Хвостовая рекурсия + pattern maatching
```
  let solution16_3 b exp =
    let tailRecursivePower b exp =
        let rec loop acc b exp =
            match exp with
            | 0 -> acc
            | _ when exp % 2 = 0 ->
                loop acc (b * b) (exp / 2)
            | _ ->
                loop (acc * b) b (exp - 1)
        loop BigInteger.One b exp

    let rec sumOfDigits n =
        if n = BigInteger.Zero then
            0
        else
            let digit = int (n % 10I)
            digit + sumOfDigits (n / 10I)

    let result = tailRecursivePower b exp
    sumOfDigits result
```
4. Sequence + Seq.map
```
let solution16_4 exp =
    let sumOfDigitsOfPowerOfTwo exp =
        let bigNumber = bigint 2 ** exp
        bigNumber.ToString()
        |> Seq.map (fun c -> int (c - '0'))
        |> Seq.sum
    
    sumOfDigitsOfPowerOfTwo exp
```
