open System

// Funkcja do liczenia słów w tekście
let liczSlowa (tekst: string) =
    tekst.Split([| ' '; '\n'; '\t' |], StringSplitOptions.RemoveEmptyEntries)
    |> Array.length

// Funkcja do liczenia znaków (bez spacji) w tekście
let liczZnakiBezSpacji (tekst: string) =
    tekst.Replace(" ", "").Length

// Główna funkcja programu
[<EntryPoint>]
let main argv =
    // Pobieranie tekstu od użytkownika
    printfn "Podaj tekst:"
    let tekst = Console.ReadLine()

    // Obliczanie liczby słów i liczby znaków (bez spacji)
    let liczbaSlow = liczSlowa tekst
    let liczbaZnakowBezSpacji = liczZnakiBezSpacji tekst

    // Wyświetlanie wyników
    printfn "Liczba słów w podanym tekście: %d" liczbaSlow
    printfn "Liczba znaków (bez spacji) w podanym tekście: %d" liczbaZnakowBezSpacji

    // Zakończenie programu
    0
