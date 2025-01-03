// Definicja typu LinkedList
type LinkedList<'T> =
    | Węzeł of 'T * LinkedList<'T>
    | Pusta

module LinkedList =
    // Funkcja tworząca listę łączoną na podstawie zwykłej listy
    let zListy lista =
        let rec pętla akumulator = function
            | [] -> akumulator
            | x::xs -> pętla (Węzeł(x, akumulator)) xs
        pętla Pusta (List.rev lista)

    // Funkcja sumująca elementy listy
    let rec suma = function
        | Pusta -> 0
        | Węzeł(x, xs) -> x + suma xs

    // Funkcja znajdująca maksymalny element w liście
    let rec maksimum = function
        | Pusta -> failwith "Lista jest pusta"
        | Węzeł(x, Pusta) -> x
        | Węzeł(x, xs) -> max x (maksimum xs)

    // Funkcja znajdująca minimalny element w liście
    let rec minimum = function
        | Pusta -> failwith "Lista jest pusta"
        | Węzeł(x, Pusta) -> x
        | Węzeł(x, xs) -> min x (minimum xs)

    // Funkcja odwracająca kolejność elementów listy
    let rec odwróć lista =
        let rec pętla akumulator = function
            | Pusta -> akumulator
            | Węzeł(x, xs) -> pętla (Węzeł(x, akumulator)) xs
        pętla Pusta lista

    // Funkcja sprawdzająca, czy dany element znajduje się w liście
    let rec zawiera element = function
        | Pusta -> false
        | Węzeł(x, xs) when x = element -> true
        | Węzeł(_, xs) -> zawiera element xs

    // Funkcja określająca indeks podanego elementu
    let rec indeks element lista =
        let rec pętla i = function
            | Pusta -> None
            | Węzeł(x, xs) when x = element -> Some(i)
            | Węzeł(_, xs) -> pętla (i + 1) xs
        pętla 0 lista

    // Funkcja zliczająca, ile razy dany element występuje w liście
    let rec licz element = function
        | Pusta -> 0
        | Węzeł(x, xs) when x = element -> 1 + licz element xs
        | Węzeł(_, xs) -> licz element xs

    // Funkcja łącząca dwie listy łączone w jedną
    let rec dołącz lista1 lista2 =
        match lista1 with
        | Pusta -> lista2
        | Węzeł(x, xs) -> Węzeł(x, dołącz xs lista2)

    // Funkcja przyjmująca dwie listy liczb całkowitych i zwracająca listę wartości logicznych
    let porównajListy lista1 lista2 =
        let rec pętla l1 l2 =
            match (l1, l2) with
            | (Pusta, Pusta) -> Pusta
            | (Pusta, _) | (_, Pusta) -> failwith "Listy mają różne długości"
            | (Węzeł(x1, xs1), Węzeł(x2, xs2)) -> Węzeł(x1 > x2, pętla xs1 xs2)
        pętla lista1 lista2

    // Funkcja zwracająca listę zawierającą tylko elementy spełniające określony warunek
    let filtr predykat lista =
        let rec pętla akumulator = function
            | Pusta -> odwróć akumulator
            | Węzeł(x, xs) when predykat x -> pętla (Węzeł(x, akumulator)) xs
            | Węzeł(_, xs) -> pętla akumulator xs
        pętla Pusta lista

    // Funkcja usuwająca duplikaty z listy
    let usuńDuplikaty lista =
        let rec pętla widziane = function
            | Pusta -> Pusta
            | Węzeł(x, xs) when zawiera x widziane -> pętla widziane xs
            | Węzeł(x, xs) -> Węzeł(x, pętla (Węzeł(x, widziane)) xs)
        pętla Pusta lista

    // Funkcja dzieląca listę na dwie części: jedną z elementami spełniającymi warunek, a drugą z pozostałymi elementami
    let podziel predykat lista =
        let rec pętla akumulator1 akumulator2 = function
            | Pusta -> (odwróć akumulator1, odwróć akumulator2)
            | Węzeł(x, xs) when predykat x -> pętla (Węzeł(x, akumulator1)) akumulator2 xs
            | Węzeł(x, xs) -> pętla akumulator1 (Węzeł(x, akumulator2)) xs
        pętla Pusta Pusta lista

// Główna część programu
// Główna część programu
// Główna część programu
open System

let rec głównaPętla () =
    printfn "Menu:"
    printfn "1. Tworzenie listy łączonej"
    printfn "2. Sumowanie elementów listy"
    printfn "3. Znajdowanie maksymalnego i minimalnego elementu"
    printfn "4. Odwracanie kolejności elementów listy"
    printfn "5. Sprawdzanie obecności elementu"
    printfn "6. Określanie indeksu elementu"
    printfn "7. Zliczanie wystąpień elementu"
    printfn "8. Łączenie dwóch list"
    printfn "9. Porównywanie dwóch list"
    printfn "10. Filtrowanie listy"
    printfn "11. Usuwanie duplikatów"
    printfn "12. Dzielenie listy na dwie części"
    printfn "0. Wyjście"
    printf "Wybierz opcję: "
    match Console.ReadLine() with
    | "0" -> printfn "Koniec programu."
    | "1" -> 
        printf "Podaj elementy listy oddzielone spacją: "
        let input = Console.ReadLine().Split(' ') |> Array.toList |> List.map int
        let listaŁączona = LinkedList.zListy input
        printfn "Lista łączona utworzona: %A" listaŁączona
        głównaPętla()
    | "2" -> 
        printf "Podaj elementy listy oddzielone spacją: "
        let input = Console.ReadLine().Split(' ') |> Array.toList |> List.map int
        let listaŁączona = LinkedList.zListy input
        printfn "Suma elementów listy: %d" (LinkedList.suma listaŁączona)
        głównaPętla()
    | "3" -> 
        printf "Podaj elementy listy oddzielone spacją: "
        let input = Console.ReadLine().Split(' ') |> Array.toList |> List.map int
        let listaŁączona = LinkedList.zListy input
        printfn "Maksymalny element: %A" (LinkedList.maksimum listaŁączona)
        printfn "Minimalny element: %A" (LinkedList.minimum listaŁączona)
        głównaPętla()
    | "4" -> 
        printf "Podaj elementy listy oddzielone spacją: "
        let input = Console.ReadLine().Split(' ') |> Array.toList |> List.map int
        let listaŁączona = LinkedList.zListy input
        printfn "Odwrócona lista: %A" (LinkedList.odwróć listaŁączona)
        głównaPętla()
    | "5" -> 
        printf "Podaj elementy listy oddzielone spacją: "
        let input = Console.ReadLine().Split(' ') |> Array.toList |> List.map int
        printf "Podaj element do sprawdzenia: "
        let element = int(Console.ReadLine())
        let listaŁączona = LinkedList.zListy input
        printfn "Czy element jest w liście: %b" (LinkedList.zawiera element listaŁączona)
        głównaPętla()
    | "6" -> 
        printf "Podaj elementy listy oddzielone spacją: "
        let input = Console.ReadLine().Split(' ') |> Array.toList |> List.map int
        printf "Podaj element do znalezienia indeksu: "
        let element = int(Console.ReadLine())
        let listaŁączona = LinkedList.zListy input
        match LinkedList.indeks element listaŁączona with
        | Some i -> printfn "Indeks elementu: %d" i
        | None -> printfn "Element nie znajduje się na liście"
        głównaPętla()
    | "7" -> 
        printf "Podaj elementy listy oddzielone spacją: "
        let input = Console.ReadLine().Split(' ') |> Array.toList |> List.map int
        printf "Podaj element do zliczenia: "
        let element = int(Console.ReadLine())
        let listaŁączona = LinkedList.zListy input
        printfn "Liczba wystąpień elementu: %d" (LinkedList.licz element listaŁączona)
        głównaPętla()
    | "8" -> 
        printf "Podaj elementy pierwszej listy oddzielone spacją: "
        let input1 = Console.ReadLine().Split(' ') |> Array.toList |> List.map int
        printf "Podaj elementy drugiej listy oddzielone spacją: "
        let input2 = Console.ReadLine().Split(' ') |> Array.toList |> List.map int
        let listaŁączona1 = LinkedList.zListy input1
        let listaŁączona2 = LinkedList.zListy input2
        printfn "Połączone listy: %A" (LinkedList.dołącz listaŁączona1 listaŁączona2)
        głównaPętla()
    | "9" -> 
        printf "Podaj elementy pierwszej listy oddzielone spacją: "
        let input1 = Console.ReadLine().Split(' ') |> Array.toList |> List.map int
        printf "Podaj elementy drugiej listy oddzielone spacją: "
        let input2 = Console.ReadLine().Split(' ') |> Array.toList |> List.map int
        let listaŁączona1 = LinkedList.zListy input1
        let listaŁączona2 = LinkedList.zListy input2
        try
            printfn "Porównanie list: %A" (LinkedList.porównajListy listaŁączona1 listaŁączona2)
        with
        | ex -> printfn "Błąd: %s" ex.Message
        głównaPętla()
    | "10" -> 
        printf "Podaj elementy listy oddzielone spacją: "
        let input = Console.ReadLine().Split(' ') |> Array.toList |> List.map int
        printf "Podaj wartość progową do filtrowania: "
        let próg = int(Console.ReadLine())
        let listaŁączona = LinkedList.zListy input
        printfn "Przefiltrowana lista: %A" (LinkedList.filtr (fun x -> x > próg) listaŁączona)
        głównaPętla()
    | "11" -> 
        printf "Podaj elementy listy oddzielone spacją: "
        let input = Console.ReadLine().Split(' ') |> Array.toList |> List.map int
        let listaŁączona = LinkedList.zListy input
        printfn "Lista bez duplikatów: %A" (LinkedList.usuńDuplikaty listaŁączona)
        głównaPętla()
    | "12" -> 
        printf "Podaj elementy listy oddzielone spacją: "
        let input = Console.ReadLine().Split(' ') |> Array.toList |> List.map int
        printf "Podaj wartość progową do podziału: "
        let próg = int(Console.ReadLine())
        let listaŁączona = LinkedList.zListy input
        let (listaSpełniającaWarunek, listaPozostałe) = LinkedList.podziel (fun x -> x > próg) listaŁączona
        printfn "Lista spełniająca warunek: %A" listaSpełniającaWarunek
        printfn "Pozostałe elementy: %A" listaPozostałe
        głównaPętla()
    | _ -> 
        printfn "Niepoprawna opcja, spróbuj ponownie."
        głównaPętla()

głównaPętla()
