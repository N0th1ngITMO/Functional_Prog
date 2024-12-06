# Лабораторная работа №1  
## Задачи  
  1. Задача 15: Начиная в левом верхнем углу сетки 2×2 и имея возможность двигаться только вниз или вправо, существует ровно 6 маршрутов до правого нижнего угла сетки.
  2. Задача 16: Какова сумма цифр числа 2^1000?

## Решение задачи 15 
1. Рекурсия + pattern matching
Рекурсивно проходимся по парам значений, которые характеризуют позицию на сетке, и складываем полученные значения
```
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
```
2. Решение на языке C++
```
#include <stdio.h>

int main(void){
  unsigned long long a[22] = {0};
  a[1] = 1;

  for (int i = 1; row < 22; row++){
    for(int j = 1; column < 22; column++){
      a[column] += a[column - 1];
    }
  }

  unsigned long long answ = a[21];
  printf("%llu", answ);
  return 0;
}
```
## Решение задачи 16
1. Рекурсия + pattern matching  
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
2. Хвостовая рекурсия + pattern maatching
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
3. Sequence + Seq.map
```
let solution16_4 exp =
    let sumOfDigitsOfPowerOfTwo exp =
        let bigNumber = bigint 2 ** exp
        bigNumber.ToString()
        |> Seq.map (fun c -> int (c - '0'))
        |> Seq.sum
    
    sumOfDigitsOfPowerOfTwo exp
```
4. Решение на языке C++
```
#include <stdio.h>

#define LEN_ARR 350

int main(void){
  char arr[LEN_ARR] = {2};
  int count = 1;
  int num;
  int dex_num;
  int sum_num = 0;

  while(count < 1000){
    dex_num = 0;
    for(int i = 0; i < LEN_ARR; i++){
      num = arr[i];
      num *= 2;
      num += dex_num;
      arr[i] = num % 10;
      dex_num = num / 10;
    }
    count++;
  }

  for(int i = 0; i < LEN_ARR; i++){
    sum_num += arr[i];
  }
  printf("%d", sum_num);
  return 0;
}
```

## Вывод  
В ходе первой лабораторной работы я познакомился с основами языка F# и функциональных подходов к программированию, такими как неизменяемость данных, функции могут рассматриваться как данные, сопоставление с образцом и т.п.  
Использование рекурсий немного ломает головую, ибо данный подход пока не привычен, но он явно стоит того, чтобы разобраться в нем. Также очень понравились агрегатные операторы, такие как светка и отображения, в ходе решения моих задач было не очень просто применить их, но потенциал "на лицо".
