open System
open System.Collections.Generic

// Definiowanie rekordu do przechowywania danych konta
type Konto = {
    NumerKonta: string
    Saldo: float
}

// Funkcja do tworzenia nowego konta
let stworzKonto numerKonta saldoPoczatkowe =
    { NumerKonta = numerKonta; Saldo = saldoPoczatkowe }

// Funkcja do depozytowania środków na konto
let zdeponuj konto kwota =
    { konto with Saldo = konto.Saldo + kwota }

// Funkcja do wypłacania środków z konta
let wyplac konto kwota =
    if konto.Saldo >= kwota then
        { konto with Saldo = konto.Saldo - kwota }
    else
        printfn "Brak wystarczających środków."
        konto

// Funkcja do wyświetlania salda konta
let wyswietlSaldo konto =
    printfn "Saldo konta %s wynosi: %f" konto.NumerKonta konto.Saldo

// Funkcja główna programu
[<EntryPoint>]
let main argv =
    // Tworzenie mapy do przechowywania kont
    let konta = Dictionary<string, Konto>()

    // Menu tekstowe
    let rec menu () =
        printfn "\nWybierz operację:"
        printfn "1. Tworzenie nowego konta"
        printfn "2. Depozytowanie środków na konto"
        printfn "3. Wypłacanie środków z konta"
        printfn "4. Wyświetlanie salda konta"
        printfn "5. Wyjście"
        
        match Console.ReadLine() with
        | "1" ->
            printfn "Podaj numer konta:"
            let numerKonta = Console.ReadLine()
            printfn "Podaj saldo początkowe:"
            let saldoPoczatkowe = float (Console.ReadLine())
            let konto = stworzKonto numerKonta saldoPoczatkowe
            konta.[numerKonta] <- konto
            printfn "Konto utworzone."
            menu ()
        | "2" ->
            printfn "Podaj numer konta:"
            let numerKonta = Console.ReadLine()
            if konta.ContainsKey(numerKonta) then
                let konto = konta.[numerKonta]
                printfn "Podaj kwotę do depozytu:"
                let kwota = float (Console.ReadLine())
                let noweKonto = zdeponuj konto kwota
                konta.[numerKonta] <- noweKonto
                printfn "Depozyt zakończony."
            else
                printfn "Konto nie istnieje."
            menu ()
        | "3" ->
            printfn "Podaj numer konta:"
            let numerKonta = Console.ReadLine()
            if konta.ContainsKey(numerKonta) then
                let konto = konta.[numerKonta]
                printfn "Podaj kwotę do wypłaty:"
                let kwota = float (Console.ReadLine())
                let noweKonto = wyplac konto kwota
                konta.[numerKonta] <- noweKonto
            else
                printfn "Konto nie istnieje."
            menu ()
        | "4" ->
            printfn "Podaj numer konta:"
            let numerKonta = Console.ReadLine()
            if konta.ContainsKey(numerKonta) then
                let konto = konta.[numerKonta]
                wyswietlSaldo konto
            else
                printfn "Konto nie istnieje."
            menu ()
        | "5" -> 
            printfn "Dziękujemy za skorzystanie z banku. Do widzenia!"
            0
        | _ ->
            printfn "Nieprawidłowy wybór. Spróbuj ponownie."
            menu ()

    // Uruchomienie menu
    menu ()
