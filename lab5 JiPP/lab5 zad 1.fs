let rec fibonacci n =
    if n <= 1 then n
    else fibonacci (n - 1) + fibonacci (n - 2)

let resultFib = fibonacci 10
printfn "10-ty wyraz ciągu Fibonacciego: %d" resultFib
let fibonacciTailRec n =
    let rec aux n a b =
        if n = 0 then a
        else aux (n - 1) b (a + b)
    aux n 0 1

let resultFibTailRec = fibonacciTailRec 10
printfn "10-ty wyraz ciągu Fibonacciego (ogonowa rekurencja): %d" resultFibTailRec
