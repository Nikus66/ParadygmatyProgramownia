open System

// Funkcja do usuwania duplikatów z listy słów
let usunDuplikaty (slowa: string list) =
    slowa |> List.distinct

// Główna funkcja programu
[<EntryPoint>]
let main argv =
    // Pobieranie tekstu od użytkownika
    printfn "Podaj słowa oddzielone spacjami:"
    let tekst = Console.ReadLine()

    // Rozdzielenie tekstu na listę słów
    let slowa = tekst.Split([|' '; '\n'; '\t'|], StringSplitOptions.RemoveEmptyEntries) |> List.ofArray

    // Usuwanie duplikatów
    let unikalneSlowa = usunDuplikaty slowa

    // Wyświetlanie unikalnych słów
    printfn "Lista unikalnych słów:"
    unikalneSlowa |> List.iter (printfn "%s")

    // Zakończenie programu
    0
