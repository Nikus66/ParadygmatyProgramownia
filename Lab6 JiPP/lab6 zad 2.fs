open System

// Funkcja do sprawdzania, czy ciąg znaków jest palindromem
let czyPalindrom (tekst: string) =
    let czystyTekst = tekst.Replace(" ", "").ToLower()
    czystyTekst = String(czystyTekst.ToCharArray() |> Array.rev)

// Główna funkcja programu
[<EntryPoint>]
let main argv =
    // Pobieranie tekstu od użytkownika
    printfn "Podaj tekst:"
    let tekst = Console.ReadLine()

    // Sprawdzenie, czy tekst jest palindromem
    if czyPalindrom tekst then
        printfn "Podany tekst jest palindromem."
    else
        printfn "Podany tekst nie jest palindromem."

    // Zakończenie programu
    0
