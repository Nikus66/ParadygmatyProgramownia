class Zadanie:
    def __init__(self, czas, nagroda):
        self.czas = czas
        self.nagroda = nagroda

# Proceduralne podejście
def optymalizuj_zadania_proceduralne(zadania):
    zadania.sort(key=lambda x: x.czas)
    czas_oczekiwania = 0
    calkowity_czas = 0
    for zadanie in zadania:
        calkowity_czas += czas_oczekiwania + zadanie.czas
        czas_oczekiwania += zadanie.czas
    return zadania, calkowity_czas

# Funkcyjne podejście
from functools import reduce

def optymalizuj_zadania_funkcyjne(zadania):
    zadania = sorted(zadania, key=lambda x: x.czas)
    calkowity_czas = reduce(lambda acc, zadanie: acc + zadanie.czas, zadania, 0)
    czas_oczekiwania = sum(acc + zadanie.czas for i, zadanie in enumerate(zadania) for acc in (sum(z.czas for z in zadania[:i]),))
    return zadania, czas_oczekiwania

# Tworzenie listy zadań
zadania = [Zadanie(4, 100), Zadanie(2, 200), Zadanie(1, 150)]

# Uruchomienie procedur
optymalne_zadania_proceduralne, calkowity_czas_proceduralne = optymalizuj_zadania_proceduralne(zadania)
optymalne_zadania_funkcyjne, calkowity_czas_funkcyjne = optymalizuj_zadania_funkcyjne(zadania)

# Wyniki
print("Podejście proceduralne:")
print(f"Optymalna kolejność zadań: {[(z.czas, z.nagroda) for z in optymalne_zadania_proceduralne]}")
print(f"Całkowity czas oczekiwania: {calkowity_czas_proceduralne}")

print("\nPodejście funkcyjne:")
print(f"Optymalna kolejność zadań: {[(z.czas, z.nagroda) for z in optymalne_zadania_funkcyjne]}")
print(f"Całkowity czas oczekiwania: {calkowity_czas_funkcyjne}")
