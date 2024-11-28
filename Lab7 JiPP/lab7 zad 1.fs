open System
open System.Collections.Generic

// Klasa Książka
type Książka(tytuł: string, autor: string, strony: int) =
    member this.Tytuł = tytuł
    member this.Autor = autor
    member this.Strony = strony
    member this.GetInfo() =
        sprintf "Tytuł: %s, Autor: %s, Strony: %d" this.Tytuł this.Autor this.Strony

// Klasa Użytkownik
type Użytkownik(imie: string) =
    let mutable wypożyczoneKsiążki : Książka list = []

    member this.Imie = imie
    member this.WypożyczoneKsiążki = wypożyczoneKsiążki
    member this.WypożyczKsiążkę(książka: Książka, biblioteka: Biblioteka) =
        if List.contains książka biblioteka.Książki then
            wypożyczoneKsiążki <- książka :: wypożyczoneKsiążki
            biblioteka.UsuńKsiążkę(książka)
            printfn "%s wypożyczył(a) %s" this.Imie książka.Tytuł
        else
            printfn "Książka %s nie jest dostępna w bibliotece" książka.Tytuł

    member this.ZwróćKsiążkę(książka: Książka, biblioteka: Biblioteka) =
        if List.contains książka wypożyczoneKsiążki then
            wypożyczoneKsiążki <- List.filter ((<>) książka) wypożyczoneKsiążki
            biblioteka.DodajKsiążkę(książka)
            printfn "%s zwrócił(a) %s" this.Imie książka.Tytuł
        else
            printfn "%s nie posiada książki %s" this.Imie książka.Tytuł

    member this.WyświetlWypożyczoneKsiążki() =
        wypożyczoneKsiążki |> List.iter (fun książka -> printfn "%s" (książka.GetInfo()))

// Klasa Biblioteka
and Biblioteka() =
    let mutable książki : Książka list = []

    member this.Książki = książki

    member this.DodajKsiążkę(książka: Książka) =
        książki <- książka :: książki
        printfn "Dodano %s do biblioteki" książka.Tytuł

    member this.UsuńKsiążkę(książka: Książka) =
        książki <- List.filter ((<>) książka) książki
        printfn "Usunięto %s z biblioteki" książka.Tytuł

    member this.WyświetlKsiążki() =
        książki |> List.iter (fun książka -> printfn "%s" (książka.GetInfo()))

// Program główny
[<EntryPoint>]
let main argv =
    let biblioteka = new Biblioteka()
    let użytkownik = new Użytkownik("Jan Kowalski")

    let menu() =
        printfn "\n=== Menu ==="
        printfn "1. Dodaj książkę"
        printfn "2. Usuń książkę"
        printfn "3. Wyświetl dostępne książki"
        printfn "4. Wypożycz książkę"
        printfn "5. Zwróć książkę"
        printfn "6. Wyświetl wypożyczone książki"
        printfn "7. Wyjście"
        printf "Wybierz opcję: "

    let rec loop() =
        menu()
        match Console.ReadLine() with
        | "1" ->
            try
                printf "Podaj tytuł książki: "
                let tytuł = Console.ReadLine()
                printf "Podaj autora książki: "
                let autor = Console.ReadLine()
                printf "Podaj liczbę stron: "
                let strony = Int32.Parse(Console.ReadLine())
                let książka = new Książka(tytuł, autor, strony)
                biblioteka.DodajKsiążkę(książka)
            with
            | ex -> printfn "Błąd: %s" ex.Message
            loop()
        | "2" ->
            try
                printf "Podaj tytuł książki do usunięcia: "
                let tytuł = Console.ReadLine()
                let książka = List.find (fun (k: Książka) -> k.Tytuł = tytuł) biblioteka.Książki
                biblioteka.UsuńKsiążkę(książka)
            with
            | ex -> printfn "Błąd: %s" ex.Message
            loop()
        | "3" ->
            try
                printfn "\nKsiążki dostępne w bibliotece:"
                biblioteka.WyświetlKsiążki()
            with
            | ex -> printfn "Błąd: %s" ex.Message
            loop()
        | "4" ->
            try
                printf "Podaj tytuł książki do wypożyczenia: "
                let tytuł = Console.ReadLine()
                let książka = List.find (fun (k: Książka) -> k.Tytuł = tytuł) biblioteka.Książki
                użytkownik.WypożyczKsiążkę(książka, biblioteka)
            with
            | ex -> printfn "Błąd: %s" ex.Message
            loop()
        | "5" ->
            try
                printf "Podaj tytuł książki do zwrócenia: "
                let tytuł = Console.ReadLine()
                let książka = List.find (fun (k: Książka) -> k.Tytuł = tytuł) użytkownik.WypożyczoneKsiążki
                użytkownik.ZwróćKsiążkę(książka, biblioteka)
            with
            | ex -> printfn "Błąd: %s" ex.Message
            loop()
        | "6" ->
            try
                printfn "\nKsiążki wypożyczone przez %s:" użytkownik.Imie
                użytkownik.WyświetlWypożyczoneKsiążki()
            with
            | ex -> printfn "Błąd: %s" ex.Message
            loop()
        | "7" ->
            printfn "Wyjście z programu."
        | _ ->
            printfn "Nieznana opcja. Spróbuj ponownie."
            loop()

    loop()
    0 
