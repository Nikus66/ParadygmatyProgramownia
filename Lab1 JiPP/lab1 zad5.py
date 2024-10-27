class Zadanie:
    def __init__(self, start, koniec, nagroda):
        self.start = start
        self.koniec = koniec
        self.nagroda = nagroda

def harmonogram_proceduralny(zadania):
    zadania.sort(key=lambda x: x.koniec)
    max_nagroda = 0
    aktualny_koniec = 0
    wybrane_zadania = []

    for zadanie in zadania:
        if zadanie.start >= aktualny_koniec:
            wybrane_zadania.append(zadanie)
            max_nagroda += zadanie.nagroda
            aktualny_koniec = zadanie.koniec

    return max_nagroda, wybrane_zadania

# Tworzenie listy zadań
zadania = [Zadanie(1, 4, 5), Zadanie(3, 5, 1), Zadanie(0, 6, 8), Zadanie(5, 7, 8), Zadanie(5, 9, 2), Zadanie(7, 8, 6)]

# Uruchomienie algorytmu proceduralnego
max_nagroda_proceduralna, wybrane_zadania_proceduralne = harmonogram_proceduralny(zadania)

print("Podejście proceduralne:")
print(f"Maksymalna nagroda: {max_nagroda_proceduralna}")
print(f"Wybrane zadania: {[(z.start, z.koniec, z.nagroda) for z in wybrane_zadania_proceduralne]}")
from functools import reduce

def harmonogram_funkcyjny(zadania):
    zadania = sorted(zadania, key=lambda x: x.koniec)
    wybrane_zadania = reduce(lambda acc, zad: acc + [zad] if not acc or zad.start >= acc[-1].koniec else acc, zadania, [])
    max_nagroda = sum(map(lambda x: x.nagroda, wybrane_zadania))
    return max_nagroda, wybrane_zadania

# Uruchomienie algorytmu funkcyjnego
max_nagroda_funkcyjna, wybrane_zadania_funkcyjne = harmonogram_funkcyjny(zadania)
print("\nPodejście funkcyjne:")
print(f"Maksymalna nagroda: {max_nagroda_funkcyjna}")
print(f"Wybrane zadania: {[(z.start, z.koniec, z.nagroda) for z in wybrane_zadania_funkcyjne]}")
