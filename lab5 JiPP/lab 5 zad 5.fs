// Rekurencyjne
let rec quicksortRecursive = function
    | [] -> []
    | x::xs -> 
        let smallerSorted = quicksortRecursive [for y in xs do if y <= x then yield y]
        let biggerSorted = quicksortRecursive [for y in xs do if y > x then yield y]
        smallerSorted @ [x] @ biggerSorted

// Iteracyjne
let quicksortIterative lst =
    let stack = System.Collections.Generic.Stack<(int list)>()
    let mutable result = []
    stack.Push(lst)
    while stack.Count > 0 do
        let lst = stack.Pop()
        match lst with
        | [] -> ()
        | [x] -> result <- x :: result
        | x::xs ->
            let smaller = [for y in xs do if y <= x then yield y]
            let bigger = [for y in xs do if y > x then yield y]
            stack.Push(bigger)
            stack.Push([x])
            stack.Push(smaller)
    result |> List.rev

// Wywołanie sortowania
let data = [3; 6; 8; 10; 1; 2; 1]
let sortedRecursive = quicksortRecursive data
let sortedIterative = quicksortIterative data

printfn "Rekurencyjnie posortowane: %A" sortedRecursive
printfn "Iteracyjnie posortowane: %A" sortedIterative
