open System

// Funkcja do przetwarzania i zmiany formatu tekstu
let zmienFormat (wpis: string) =
    let elementy = wpis.Split(';')
    if elementy.Length = 3 then
        let imie = elementy.[0].Trim()
        let nazwisko = elementy.[1].Trim()
        let wiek = elementy.[2].Trim()
        sprintf "%s, %s (%s lat)" nazwisko imie wiek
    else
        "Nieprawidłowy format"

let przetworzWpisy wpisy =
    wpisy
    |> Array.map zmienFormat
    |> Array.iter (printfn "%s")

// Główna funkcja programu
[<EntryPoint>]
let main argv =
    // Pobieranie wpisów od użytkownika
    printfn "Podaj wpisy w formacie 'imię; nazwisko; wiek' (oddzielone przecinkami):"
    let input = Console.ReadLine()
    
    // Podział wpisów po przecinku
    let wpisy = input.Split([|','|], StringSplitOptions.RemoveEmptyEntries)
    
    // Przetwarzanie i wyświetlanie wpisów
    przetworzWpisy wpisy
    
    // Zakończenie programu
    0
