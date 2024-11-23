open System

// Funkcja do zamiany słowa w tekście
let zamienSlowo (tekst: string) (doZamiany: string) (noweSlowo: string) =
    tekst.Replace(doZamiany, noweSlowo)

// Główna funkcja programu
[<EntryPoint>]
let main argv =
    // Pobieranie tekstu od użytkownika
    printfn "Podaj tekst:"
    let tekst = Console.ReadLine()

    // Pobieranie słowa do zamiany
    printfn "Podaj słowo do zamiany:"
    let doZamiany = Console.ReadLine()

    // Pobieranie nowego słowa
    printfn "Podaj nowe słowo:"
    let noweSlowo = Console.ReadLine()

    // Zamiana słowa
    let zmodyfikowanyTekst = zamienSlowo tekst doZamiany noweSlowo

    // Wyświetlanie zmodyfikowanego tekstu
    printfn "Zmodyfikowany tekst:"
    printfn "%s" zmodyfikowanyTekst

    // Zakończenie programu
    0
