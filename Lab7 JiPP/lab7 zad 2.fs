open System
open System.Collections.Generic

// Klasa KontoBankowe
type KontoBankowe(numerKonta: string, poczatkoweSaldo: decimal) =
    let mutable saldo = poczatkoweSaldo

    member this.NumerKonta = numerKonta
    member this.Saldo = saldo

    member this.Wplata(kwota: decimal) =
        if kwota <= 0m then
            printfn "Kwota wpłaty musi być większa niż zero."
        else
            saldo <- saldo + kwota
            printfn "Wpłacono: %A. Nowe saldo: %A." kwota saldo

    member this.Wyplata(kwota: decimal) =
        if kwota <= 0m then
            printfn "Kwota wypłaty musi być większa niż zero."
        elif kwota > saldo then
            printfn "Niewystarczające środki na koncie."
        else
            saldo <- saldo - kwota
            printfn "Wypłacono: %A. Nowe saldo: %A." kwota saldo

// Klasa Bank
type Bank() =
    let konta = Dictionary<string, KontoBankowe>()

    member this.StworzKonto(numerKonta: string, poczatkoweSaldo: decimal) =
        if konta.ContainsKey(numerKonta) then
            printfn "Konto o tym numerze już istnieje."
        else
            let konto = new KontoBankowe(numerKonta, poczatkoweSaldo)
            konta.Add(numerKonta, konto)
            printfn "Utworzono konto: %s z saldem początkowym %A." numerKonta poczatkoweSaldo

    member this.PobierzKonto(numerKonta: string) =
        if konta.ContainsKey(numerKonta) then
            konta.[numerKonta]
        else
            failwith "Konto o tym numerze nie istnieje."

    member this.AktualizujKonto(numerKonta: string, noweSaldo: decimal) =
        if konta.ContainsKey(numerKonta) then
            let konto = konta.[numerKonta]
            konto.Wplata(noweSaldo - konto.Saldo)
            printfn "Zaktualizowano saldo konta %s. Nowe saldo: %A." numerKonta noweSaldo
        else
            printfn "Konto o tym numerze nie istnieje."

    member this.UsunKonto(numerKonta: string) =
        if konta.ContainsKey(numerKonta) then
            konta.Remove(numerKonta) |> ignore
            printfn "Usunięto konto: %s." numerKonta
        else
            printfn "Konto o tym numerze nie istnieje."

// Program główny
[<EntryPoint>]
let main argv =
    let bank = new Bank()

    let menu() =
        printfn "\n=== Menu ==="
        printfn "1. Utwórz konto"
        printfn "2. Wpłata na konto"
        printfn "3. Wypłata z konta"
        printfn "4. Sprawdź saldo"
        printfn "5. Aktualizuj saldo"
        printfn "6. Usuń konto"
        printfn "7. Wyjście"
        printf "Wybierz opcję: "

    let rec loop() =
        menu()
        match Console.ReadLine() with
        | "1" ->
            try
                printf "Podaj numer konta: "
                let numerKonta = Console.ReadLine()
                printf "Podaj początkowe saldo: "
                let poczatkoweSaldo = Decimal.Parse(Console.ReadLine())
                bank.StworzKonto(numerKonta, poczatkoweSaldo)
            with
            | ex -> printfn "Błąd: %s" ex.Message
            loop()
        | "2" ->
            try
                printf "Podaj numer konta: "
                let numerKonta = Console.ReadLine()
                printf "Podaj kwotę wpłaty: "
                let kwota = Decimal.Parse(Console.ReadLine())
                let konto = bank.PobierzKonto(numerKonta)
                konto.Wplata(kwota)
            with
            | ex -> printfn "Błąd: %s" ex.Message
            loop()
        | "3" ->
            try
                printf "Podaj numer konta: "
                let numerKonta = Console.ReadLine()
                printf "Podaj kwotę wypłaty: "
                let kwota = Decimal.Parse(Console.ReadLine())
                let konto = bank.PobierzKonto(numerKonta)
                konto.Wyplata(kwota)
            with
            | ex -> printfn "Błąd: %s" ex.Message
            loop()
        | "4" ->
            try
                printf "Podaj numer konta: "
                let numerKonta = Console.ReadLine()
                let konto = bank.PobierzKonto(numerKonta)
                printfn "Saldo konta %s: %A" numerKonta konto.Saldo
            with
            | ex -> printfn "Błąd: %s" ex.Message
            loop()
        | "5" ->
            try
                printf "Podaj numer konta: "
                let numerKonta = Console.ReadLine()
                printf "Podaj nowe saldo: "
                let noweSaldo = Decimal.Parse(Console.ReadLine())
                bank.AktualizujKonto(numerKonta, noweSaldo)
            with
            | ex -> printfn "Błąd: %s" ex.Message
            loop()
        | "6" ->
            try
                printf "Podaj numer konta: "
                let numerKonta = Console.ReadLine()
                bank.UsunKonto(numerKonta)
            with
            | ex -> printfn "Błąd: %s" ex.Message
            loop()
        | "7" ->
            printfn "Wyjście z programu."
        | _ ->
            printfn "Nieznana opcja. Spróbuj ponownie."
            loop()

    loop()
    0 // Kod zakończenia programu
