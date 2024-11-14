type BinaryTree<'T> =
    | Empty
    | Node of 'T * BinaryTree<'T> * BinaryTree<'T>

let rec searchTree element tree =
    match tree with
    | Empty -> false
    | Node(value, left, right) ->
        if element = value then true
        else searchTree element left || searchTree element right

let tree = Node(10, Node(5, Empty, Empty), Node(15, Empty, Node(20, Empty, Empty)))
let resultSearch = searchTree 15 tree
printfn "Czy 15 jest w drzewie? %b" resultSearch
let searchTreeIterative element tree =
    let rec loop stack =
        match stack with
        | [] -> false
        | Empty :: rest -> loop rest
        | Node(value, left, right) :: rest ->
            if element = value then true
            else loop (left :: right :: rest)
    loop [tree]

let resultSearchIter = searchTreeIterative 15 tree
printfn "Czy 15 jest w drzewie (iteracyjnie)? %b" resultSearchIter
