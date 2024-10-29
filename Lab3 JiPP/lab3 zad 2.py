import json

# Klasa reprezentująca pracownika
class Pracownik:
    def __init__(self, imie, wiek, pensja):
        self.imie = imie
        self.wiek = wiek
        self.pensja = pensja

    def __str__(self):
        return f"Imię: {self.imie}, Wiek: {self.wiek}, Pensja: {self.pensja}"

# Klasa reprezentująca system logowania
class SystemLogowania:
    def __init__(self):
        self.uzytkownik = "admin"
        self.haslo = "admin"

    def logowanie(self, uzytkownik, haslo):
        return uzytkownik == self.uzytkownik and haslo == self.haslo

# Klasa zarządzająca listą pracowników i obsługująca pliki
class ZarzadzaniePracownikami:
    def __init__(self, sciezka_pliku='pracownicy.json'):
        self.pracownicy = []
        self.sciezka_pliku = sciezka_pliku
        self.wczytaj_pracownikow()

    def dodaj_pracownika(self, pracownik):
        self.pracownicy.append(pracownik)
        self.zapisz_pracownikow()

    def wyswietl_pracownikow(self):
        for pracownik in self.pracownicy:
            print(pracownik)

    def usun_pracownikow_wg_wieku(self, min_wiek, max_wiek):
        self.pracownicy = [pracownik for pracownik in self.pracownicy if not (min_wiek <= pracownik.wiek <= max_wiek)]
        self.zapisz_pracownikow()

    def znajdz_pracownika_po_imieniu(self, imie):
        for pracownik in self.pracownicy:
            if pracownik.imie == imie:
                return pracownik
        return None

    def aktualizuj_pensje_pracownika(self, imie, nowa_pensja):
        pracownik = self.znajdz_pracownika_po_imieniu(imie)
        if pracownik:
            pracownik.pensja = nowa_pensja
            self.zapisz_pracownikow()
            return True
        return False

    def zapisz_pracownikow(self):
        with open(self.sciezka_pliku, 'w') as plik:
            json.dump([pracownik.__dict__ for pracownik in self.pracownicy], plik)

    def wczytaj_pracownikow(self):
        try:
            with open(self.sciezka_pliku, 'r') as plik:
                self.pracownicy = [Pracownik(**dane) for dane in json.load(plik)]
        except FileNotFoundError:
            self.pracownicy = []

# Klasa zapewniająca interfejs użytkownika do interakcji z ZarzadzaniePracownikami i systemem logowania
class ZarzadzanieFrontend:
    def __init__(self):
        self.system_logowania = SystemLogowania()
        self.manager = ZarzadzaniePracownikami()

    def logowanie(self):
        uzytkownik = input("Podaj nazwę użytkownika: ")
        haslo = input("Podaj hasło: ")
        if not self.system_logowania.logowanie(uzytkownik, haslo):
            print("Nieprawidłowe dane logowania. Dostęp zabroniony.")
            return False
        return True

    def uruchom(self):
        if not self.logowanie():
            return
        while True:
            print("\n1. Dodaj pracownika\n2. Wyświetl pracowników\n3. Usuń pracowników wg wieku\n4. Zaktualizuj pensję pracownika\n5. Wyjście")
            wybor = input("Wybierz opcję: ")
            if wybor == '1':
                self.dodaj_pracownika()
            elif wybor == '2':
                self.wyswietl_pracownikow()
            elif wybor == '3':
                self.usun_pracownikow_wg_wieku()
            elif wybor == '4':
                self.aktualizuj_pensje_pracownika()
            elif wybor == '5':
                break
            else:
                print("Nieprawidłowa opcja. Spróbuj ponownie.")

    def dodaj_pracownika(self):
        imie = input("Podaj imię pracownika: ")
        wiek = int(input("Podaj wiek pracownika: "))
        if wiek < 18:
            print("Wiek pracownika musi być co najmniej 18 lat.")
            return
        pensja = float(input("Podaj pensję pracownika: "))
        if pensja < 4800:
            print("Pensja pracownika musi być większa niż 4800.")
            return
        nowy_pracownik = Pracownik(imie, wiek, pensja)
        self.manager.dodaj_pracownika(nowy_pracownik)

    def wyswietl_pracownikow(self):
        self.manager.wyswietl_pracownikow()

    def usun_pracownikow_wg_wieku(self):
        min_wiek = int(input("Podaj minimalny wiek: "))
        max_wiek = int(input("Podaj maksymalny wiek: "))
        self.manager.usun_pracownikow_wg_wieku(min_wiek, max_wiek)

    def aktualizuj_pensje_pracownika(self):
        imie = input("Podaj imię pracownika: ")
        nowa_pensja = float(input("Podaj nową pensję: "))
        if nowa_pensja < 4800:
            print("Nowa pensja musi być większa niż 4800.")
            return
        if self.manager.aktualizuj_pensje_pracownika(imie, nowa_pensja):
            print(f"Zaktualizowano pensję dla {imie}.")
        else:
            print(f"Pracownik {imie} nie znaleziony.")

# Uruchomienie interfejsu użytkownika
frontend = ZarzadzanieFrontend()
frontend.uruchom()
