open System

// Reprezentacja planszy jako tablica
let plansza = Array.create 9 ' '

// Funkcja do wyświetlania planszy
let wyswietlPlansze () =
    printfn " %c | %c | %c " plansza.[0] plansza.[1] plansza.[2]
    printfn "---+---+---"
    printfn " %c | %c | %c " plansza.[3] plansza.[4] plansza.[5]
    printfn "---+---+---"
    printfn " %c | %c | %c " plansza.[6] plansza.[7] plansza.[8]

// Funkcja do sprawdzania, czy jest zwycięzca
let sprawdzZwyciezce () =
    let linie = [
        [0; 1; 2]; [3; 4; 5]; [6; 7; 8] // Wiersze
        [0; 3; 6]; [1; 4; 7]; [2; 5; 8] // Kolumny
        [0; 4; 8]; [2; 4; 6]           // Przekątne
    ]
    linie |> List.exists (fun linia ->
        let [a; b; c] = linia
        plansza.[a] <> ' ' && plansza.[a] = plansza.[b] && plansza.[b] = plansza.[c]
    )

// Funkcja do sprawdzania, czy plansza jest pełna (remis)
let czyPlanszaPelna () =
    not (Array.exists (fun pole -> pole = ' ') plansza)

// Funkcja do wykonywania ruchu komputera (losowy ruch)
let ruchKomputera () =
    let los = Random()
    let pustePola = [0..8] |> List.filter (fun i -> plansza.[i] = ' ')
    let indeks = pustePola.[los.Next(pustePola.Length)]
    plansza.[indeks] <- 'O'

// Funkcja główna gry
let rec gra () =
    wyswietlPlansze ()

    if sprawdzZwyciezce () then
        printfn "Zwycięstwo! Gracz wygrał!"
    elif czyPlanszaPelna () then
        printfn "Remis!"
    else
        // Ruch gracza
        printfn "Podaj numer pola (1-9):"
        let pozycja = int (Console.ReadLine()) - 1
        if plansza.[pozycja] = ' ' then
            plansza.[pozycja] <- 'X'
        else
            printfn "Pole jest już zajęte. Wybierz inne."
            gra()

        if sprawdzZwyciezce () then
            wyswietlPlansze ()
            printfn "Zwycięstwo! Gracz wygrał!"
        elif czyPlanszaPelna () then
            wyswietlPlansze ()
            printfn "Remis!"
        else
            // Ruch komputera
            ruchKomputera ()
            gra()

// Start gry
gra ()
