# Считать прямоугольную таблицу с числами. Сортировать

# побочную диагональ по возрастанию элементов от левого нижнего угла,
# ближайшие параллельные ей — по убыванию, следующие диагонали сверху и снизу — снова по возрастанию и т.д.

def sort_m(matrix):
    minimum_side_of_the_matrix = min(len(matrix), len(matrix[0])) # вычисляет размеры меньшей стороны матрицы
    # Нужен для переключения между сортировками (с низу вверх или с верху в низ)
    flag = True
    for x in range(minimum_side_of_the_matrix - 1, -minimum_side_of_the_matrix , -1):
        # Я записываю сида побочную диагональ и ближайщие параллельные ей диагонали,
        # потом их сортирую и вывожу сначала левую половину (от нее и до начала),
        # потом правую с конца и до побочной диагонали.
        diagonal_list = []

        # Условия аналогичные
        if x >= 0:
            # Записывает диагонали
            diagonal_list = [matrix[j][i] for i,j in zip(range(x, -1, -1), range(0, x+1))]

            # сортирует диагонали в зависимости от четности
            if flag:
                diagonal_list.sort()
                flag = False
            else:
                diagonal_list.sort(reverse= True)
                flag = True

            # Переписывает диагональ в матрице
            j = 0
            for i in range(x, 0, -1):
                matrix[i][j] = diagonal_list[j]
                j += 1
            matrix[i-1][j] = diagonal_list[j]

        else:
            diagonal_list = [matrix[i][j] for i,j in zip(range(x, 0, 1), range(-1, x-1, -1))]

            if flag:
                diagonal_list.sort()
                flag = False
            else:
                diagonal_list.sort(reverse= True)
                flag = True

            j = -1
            g = 0
            for i in range(x, 0, 1):
                matrix[i][j] = diagonal_list[g]
                j -= 1
                g += 1

    return matrix

# Записывает матрицу из файла f и возвращает ее
def input_(f):
    matrix = list()
    string = [int(x) for x in f.readline().split()]
    while string:
        matrix += [string]
        string = [int(x) for x in f.readline().split()]
    return matrix

# Выводит матрицу
def print_(matrix):
    for x in matrix:
        print(*x)

# Выводит матрицу через tab что бы нагляднее было видно
def print_mod(matrix):
    for x in matrix:
        for y in x:
            print(str(y) + '\t', end='')
        print()

f = open('''6 Сортировка\Матрица 6.2\Test.txt ''', 'r')

matrix = input_(f)

print('----------Старая матрица----------')
print_mod(matrix)
print('-----Отсортированная матрица------')
print_mod(sort_m(matrix))
