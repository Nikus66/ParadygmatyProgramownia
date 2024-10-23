class Przedmiot:
    def __init__(self, waga, wartosc):
        self.waga = waga
        self.wartosc = wartosc

# Proceduralne podejście
def knapsack_proceduralny(przedmioty, pojemnosc):
    n = len(przedmioty)
    dp = [[0 for _ in range(pojemnosc + 1)] for _ in range(n + 1)]

    for i in range(n + 1):
        for w in range(pojemnosc + 1):
            if i == 0 or w == 0:
                dp[i][w] = 0
            elif przedmioty[i-1].waga <= w:
                dp[i][w] = max(przedmioty[i-1].wartosc + dp[i-1][w-przedmioty[i-1].waga], dp[i-1][w])
            else:
                dp[i][w] = dp[i-1][w]

    max_wartosc = dp[n][pojemnosc]
    w = pojemnosc
    wybrane_przedmioty = []

    for i in range(n, 0, -1):
        if max_wartosc <= 0:
            break
        if max_wartosc == dp[i-1][w]:
            continue
        else:
            wybrane_przedmioty.append(przedmioty[i-1])
            max_wartosc -= przedmioty[i-1].wartosc
            w -= przedmioty[i-1].waga

    return dp[n][pojemnosc], wybrane_przedmioty

# Funkcyjne podejście
from functools import lru_cache

def knapsack_funkcyjny(przedmioty, pojemnosc):
    @lru_cache(maxsize=None)
    def best_value(n, w):
        if n == 0 or w == 0:
            return 0
        elif przedmioty[n-1].waga > w:
            return best_value(n-1, w)
        else:
            return max(best_value(n-1, w), przedmioty[n-1].wartosc + best_value(n-1, w-przedmioty[n-1].waga))

    n = len(przedmioty)
    max_wartosc = best_value(n, pojemnosc)
    
    # Rekonstrukcja wybranych przedmiotów
    w = pojemnosc
    wybrane_przedmioty = []
    for i in range(n, 0, -1):
        if best_value(i, w) != best_value(i-1, w):
            wybrane_przedmioty.append(przedmioty[i-1])
            w -= przedmioty[i-1].waga
    
    return max_wartosc, wybrane_przedmioty

# Tworzenie listy przedmiotów
przedmioty = [Przedmiot(2, 3), Przedmiot(3, 4), Przedmiot(4, 5), Przedmiot(5, 6)]
pojemnosc = 5

# Uruchomienie proceduralne
max_wartosc_proceduralne, wybrane_przedmioty_proceduralne = knapsack_proceduralny(przedmioty, pojemnosc)
print("Podejście proceduralne:")
print(f"Maksymalna wartość: {max_wartosc_proceduralne}")
print(f"Wybrane przedmioty: {[(p.waga, p.wartosc) for p in wybrane_przedmioty_proceduralne]}")

# Uruchomienie funkcyjne
max_wartosc_funkcyjne, wybrane_przedmioty_funkcyjne = knapsack_funkcyjny(tuple(przedmioty), pojemnosc)
print("\nPodejście funkcyjne:")
print(f"Maksymalna wartość: {max_wartosc_funkcyjne}")
print(f"Wybrane przedmioty: {[(p.waga, p.wartosc) for p in wybrane_przedmioty_funkcyjne]}")
