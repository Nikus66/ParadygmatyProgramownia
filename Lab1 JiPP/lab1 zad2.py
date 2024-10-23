from collections import deque

def bfsPath(graph, start, end):
    #kolekcja do wierzcholkow
    queue = deque([start])
    #zbior odwiedzonych wierzcholkow
    visited = set()

    #dopoki mamy sciezki
    while queue:
        #pobierz pierwszy wierzcholek
        path = queue.popleft()
        node = path[-1]

        if node == end:
            return path

        if node not in visited:
            for neighbour in graph.get(node,[]):
                new_path = list(path)
                new_path.append(neighbour)
                queue.append(new_path)
            visited.add(node)

    return None

graph = {
    'A' : {'B', 'C'},
    'B' : {'A', 'D', 'E'},
    'C' : {'A', 'F'},
    'D' : {'B'},
    'E' : {'B', 'F'},
    'F' : {'C', 'E'}
}

print(bfsPath(graph,'A','F'))
