def dynamiczne_ekstrema(dane):
    # Selektowanie odpowiednich typów danych za pomocą filter() i mapowanie na ich wartości
    liczby = list(filter(lambda x: isinstance(x, (int, float)), dane))
    napisy = list(filter(lambda x: isinstance(x, str), dane))
    krotki = list(filter(lambda x: isinstance(x, tuple), dane))

    # Wyznaczanie największej liczby
    najwieksza_liczba = max(map(float, liczby)) if liczby else None

    # Wyznaczanie najdłuższego napisu
    najdluzszy_napis = max(map(str, napisy), key=len) if napisy else None

    # Wyznaczanie krotki o największej liczbie elementów
    najdluzsza_krotka = max(map(tuple, krotki), key=len) if krotki else None

    return najwieksza_liczba, najdluzszy_napis, najdluzsza_krotka

# Przykładowe dane
dane = [123, "krótkie", (1, 2), {"klucz": "wartość"}, 3.14, "najdłuższy napis w kolekcji", (1, 2, 3, 4), 42]

najwieksza_liczba, najdluzszy_napis, najdluzsza_krotka = dynamiczne_ekstrema(dane)
print(f"Największa liczba: {najwieksza_liczba}")
print(f"Najdłuższy napis: {najdluzszy_napis}")
print(f"Najdłuższa krotka: {najdluzsza_krotka}")
