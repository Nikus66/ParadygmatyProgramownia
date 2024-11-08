open System

// Funkcja do liczenia liczby słów
let liczSlowa (tekst: string) =
    tekst.Split([| ' '; '\t'; '\n'; '\r' |], StringSplitOptions.RemoveEmptyEntries)
    |> Array.length

// Funkcja do liczenia liczby znaków (bez spacji)
let liczZnakiBezSpacji (tekst: string) =
    tekst.Replace(" ", "").Length

// Funkcja do znajdowania najczęściej występującego słowa
let najczestszeSlowo (tekst: string) =
    let slowa = tekst.Split([| ' '; '\t'; '\n'; '\r' |], StringSplitOptions.RemoveEmptyEntries)
    let mapaSlow = 
        slowa 
        |> Array.fold (fun acc slowo -> 
            if Map.containsKey slowo acc then 
                Map.add slowo (acc.[slowo] + 1) acc 
            else 
                Map.add slowo 1 acc) Map.empty
    mapaSlow 
    |> Map.toList 
    |> List.maxBy snd 
    |> fst

// Funkcja główna programu
[<EntryPoint>]
let main argv =
    // Pobieranie tekstu od użytkownika
    printfn "Podaj tekst do analizy:"
    let tekst = Console.ReadLine()

    // Liczenie liczby słów
    let liczbaSlow = liczSlowa tekst

    // Liczenie liczby znaków (bez spacji)
    let liczbaZnakowBezSpacji = liczZnakiBezSpacji tekst

    // Znajdowanie najczęściej występującego słowa
    let najczestsze = najczestszeSlowo tekst

    // Wyświetlanie wyników
    printfn "Liczba słów: %d" liczbaSlow
    printfn "Liczba znaków (bez spacji): %d" liczbaZnakowBezSpacji
    printfn "Najczęściej występujące słowo: %s" najczestsze

    // Zakończenie programu
    0
