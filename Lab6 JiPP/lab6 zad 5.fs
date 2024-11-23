open System

// Funkcja do znajdowania najdłuższego słowa
let najdluzszeSlowo (tekst: string) =
    tekst.Split([| ' '; '\n'; '\t' |], StringSplitOptions.RemoveEmptyEntries)
    |> Array.maxBy (fun slowo -> slowo.Length)

// Główna funkcja programu
[<EntryPoint>]
let main argv =
    // Pobieranie tekstu od użytkownika
    printfn "Podaj tekst:"
    let tekst = Console.ReadLine()

    // Znajdowanie najdłuższego słowa
    let slowo = najdluzszeSlowo tekst
    let dlugosc = slowo.Length

    // Wyświetlanie wyników
    printfn "Najdłuższe słowo: %s" slowo
    printfn "Długość najdłuższego słowa: %d" dlugosc

    // Zakończenie programu
    0
