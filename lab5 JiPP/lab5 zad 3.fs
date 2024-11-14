let rec permutations list =
    let rec insertAllPositions elem rest =
        match rest with
        | [] -> [[elem]]
        | x::xs -> 
            (elem::rest) :: (List.map (fun perm -> x::perm) (insertAllPositions elem xs))
    match list with
    | [] -> [[]]
    | x::xs ->
        let perms = permutations xs
        List.collect (insertAllPositions x) perms

let resultPermutations = permutations [1; 2; 3]
printfn "Permutacje listy [1; 2; 3]:"
resultPermutations |> List.iter (printfn "%A")
