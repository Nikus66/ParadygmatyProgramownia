import numpy as np

def waliduj_i_wykonaj(operacja, A, B=None):
    try:
        if B is not None:
            if 'dodaj' in operacja or 'mnoz' in operacja:
                # Sprawdzanie wymiarów
                if A.shape != B.shape and 'dodaj' in operacja:
                    raise ValueError("Wymiary macierzy nie pasują do dodawania.")
                if A.shape[1] != B.shape[0] and 'mnoz' in operacja:
                    raise ValueError("Wymiary macierzy nie pasują do mnożenia.")

        kod = f"""
wynik = None
if 'transponuj' in '{operacja}':
    wynik = np.transpose(A)
elif 'dodaj' in '{operacja}':
    wynik = A + B
elif 'mnoz' in '{operacja}':
    wynik = A @ B
"""
        exec(kod)
        return eval("wynik")

    except Exception as e:
        return f"Błąd: {e}"

# Przykładowe użycie
A = np.array([[1, 2], [3, 4]])
B = np.array([[5, 6], [7, 8]])

print(waliduj_i_wykonaj('dodaj', A, B))       # Dodawanie macierzy
print(waliduj_i_wykonaj('mnoz', A, B))        # Mnożenie macierzy
print(waliduj_i_wykonaj('transponuj', A))     # Transponowanie macierzy