let rec hanoi n source target auxiliary =
    if n > 0 then
        hanoi (n - 1) source auxiliary target
        printfn "Move disk from %A to %A" source target
        hanoi (n - 1) auxiliary target source

hanoi 3 "A" "C" "B"
let hanoiIterative n source target auxiliary =
    let move = ref []
    let totalMoves = (1 <<< n) - 1  // 2^n - 1
    for i in 1..totalMoves do
        let fromPeg, toPeg =
            match i % 3 with
            | 1 -> source, target
            | 2 -> source, auxiliary
            | 0 -> auxiliary, target
            | _ -> failwith "Invalid state" // Tej linii nigdy nie powinno się osiągnąć
        move := (fromPeg, toPeg) :: !move
        printfn "Move disk from %A to %A" fromPeg toPeg
    !move

hanoiIterative 3 "A" "C" "B"
