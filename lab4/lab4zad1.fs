open System

// Definiowanie rekordu do przechowywania danych użytkownika
type Uzytkownik = {
    Waga: float
    Wzrost: float
}

// Funkcja obliczająca BMI
let obliczBMI waga wzrost =
    waga / (wzrost / 100.0) ** 2.0

// Funkcja określająca kategorię BMI
let okreslKategorieBMI bmi =
    if bmi < 18.5 then "Niedowaga"
    elif bmi < 24.9 then "Waga prawidłowa"
    elif bmi < 29.9 then "Nadwaga"
    else "Otyłość"

// Funkcja główna programu
[<EntryPoint>]
let main argv =
    // Komunikacja z użytkownikiem
    printfn "Podaj swoją wagę w kg:"
    let wagaStr = Console.ReadLine()
    printfn "Podaj swój wzrost w cm:"
    let wzrostStr = Console.ReadLine()

    // Przekształcanie typów
    let waga = float wagaStr
    let wzrost = float wzrostStr

    // Tworzenie rekordu użytkownika
    let uzytkownik = { Waga = waga; Wzrost = wzrost }

    // Obliczanie BMI
    let bmi = obliczBMI uzytkownik.Waga uzytkownik.Wzrost

    // Określenie kategorii BMI
    let kategoria = okreslKategorieBMI bmi

    // Wyświetlanie wyników
    printfn "Twoje BMI wynosi: %f" bmi
    printfn "Kategoria BMI: %s" kategoria

    // Zakończenie programu
    0
