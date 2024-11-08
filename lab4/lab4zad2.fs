open System

// Definiowanie kursów wymiany
let kursyWymiany = Map.ofList [
    ("PLN", 1.0)       // Kurs bazowy
    ("USD", 0.26)      // 1 PLN = 0.26 USD
    ("EUR", 0.22)      // 1 PLN = 0.22 EUR
    ("GBP", 0.19)      // 1 PLN = 0.19 GBP
]

// Funkcja do obliczania przeliczonej kwoty
let przeliczWalute kwota walutaZrodlowa walutaDocelowa =
    let kwotaWPLN = kwota / kursyWymiany.[walutaZrodlowa]
    kwotaWPLN * kursyWymiany.[walutaDocelowa]

// Funkcja główna programu
[<EntryPoint>]
let main argv =
    // Pobieranie danych od użytkownika
    printfn "Podaj kwotę do przeliczenia:"
    let kwotaStr = Console.ReadLine()
    printfn "Podaj walutę źródłową (np. PLN, USD, EUR, GBP):"
    let walutaZrodlowa = Console.ReadLine().ToUpper()
    printfn "Podaj walutę docelową (np. PLN, USD, EUR, GBP):"
    let walutaDocelowa = Console.ReadLine().ToUpper()

    // Przekształcanie typów
    let kwota = float kwotaStr

    // Sprawdzanie, czy waluty są obsługiwane
    if kursyWymiany.ContainsKey(walutaZrodlowa) && kursyWymiany.ContainsKey(walutaDocelowa) then
        // Obliczanie przeliczonej kwoty
        let przeliczonaKwota = przeliczWalute kwota walutaZrodlowa walutaDocelowa

        // Wyświetlanie wyników
        printfn "Przeliczona kwota: %f %s" przeliczonaKwota walutaDocelowa
    else
        printfn "Jedna z podanych walut nie jest obsługiwana."

    // Zakończenie programu
    0
