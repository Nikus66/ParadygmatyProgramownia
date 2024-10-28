import numpy as np
from functools import reduce

def polacz_macierze(macierze, operacja):
    # Funkcja pomocnicza do zastosowania operacji na dwóch macierzach
    def zastosuj_operacje(a, b):
        return eval(f'a {operacja} b')

    # Łączenie macierzy za pomocą reduce()
    wynik = reduce(zastosuj_operacje, macierze)
    return wynik

def transponuj_macierze(macierze):
    # Funkcja pomocnicza do transponowania każdej macierzy
    return list(map(np.transpose, macierze))

# Przykładowe macierze
macierz1 = np.array([[1, 2], [3, 4]])
macierz2 = np.array([[5, 6], [7, 8]])
macierz3 = np.array([[9, 10], [11, 12]])

macierze = [macierz1, macierz2, macierz3]

# Przykładowe operacje
operacja_suma = '+'
operacja_iloczyn = '*'
operacja_odejmowanie = '-'

# Sumowanie macierzy
wynik_suma = polacz_macierze(macierze, operacja_suma)
print("Suma macierzy:")
print(wynik_suma)

# Mnożenie macierzy
wynik_iloczyn = polacz_macierze(macierze, operacja_iloczyn)
print("\nIloczyn macierzy:")
print(wynik_iloczyn)

# Odejmowanie macierzy
wynik_odejmowanie = polacz_macierze(macierze, operacja_odejmowanie)
print("\nOdejmowanie macierzy:")
print(wynik_odejmowanie)

# Transponowanie macierzy
wynik_transponowanie = transponuj_macierze(macierze)
print("\nTransponowanie macierzy:")
for i, macierz in enumerate(wynik_transponowanie):
    print(f"Macierz {i+1}:\n{macierz}")
