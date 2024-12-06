module task16

open System
open System.Numerics

//recurtion + pattern matching
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

//tail recurtion + pattern matching
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

//sequence
let solution16_4 exp =
    let sumOfDigitsOfPowerOfTwo exp =
        let bigNumber = (pown (bigint 2) exp).ToString()
        
        Seq.initInfinite id
        |> Seq.map (fun i -> bigNumber.[i])
        |> Seq.map (fun c -> int c - int '0')
        |> Seq.take bigNumber.Length
        |> Seq.sum

    sumOfDigitsOfPowerOfTwo exp
    