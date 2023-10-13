# Двумя способами: с помощью быстрой сортировки (qsort) и встроенной сортировки Питона
# (функции sorted или метода списков sort) — расположить набор чисел в порядке

# убывания суммы цифр чисел, кроме разряда единиц

def new_sum(element: int) -> int:
    if abs(int(element)) > 10:
        return sum([int(element[x]) for x in range(len(element) - 1)])
    else:
        return 0

def sort_helper(element: int, support_element: int) -> bool:

    if abs(int(element)) > 10 and abs(int(support_element)) > 10:
        sum_1 = sum([int(element[x]) for x in range(len(element) - 1)])
        sum_2 = sum([int(support_element[x]) for x in range(len(support_element) - 1)])
        if sum_1 < sum_2:
            return True
        else:
            return False

    elif abs(int(element)) > 10 and abs(int(support_element)) < 10:
        return False

    elif abs(int(element)) < 10 and abs(int(support_element)) > 10:
        return True

    else:
        return False

def quick_sort(list_: list) -> list:

    if len(list_) <= 1:
        return list_

    support_element = list_[int(len(list_)/2)]

    left = list(x for x in list_ if not sort_helper(x, support_element) and x != support_element)
    center = [i for i in list_ if i == support_element]
    right = list(x for x in list_ if sort_helper(x, support_element) and x != support_element)

    return quick_sort(left) + center + quick_sort(right)

# %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%5
string = [x for x in input().split()]

# Моя сортировка
print('\n',*quick_sort(string))

# Встроенная функция, использующая вспомогательную функцию
print('\n',*sorted(string, key=new_sum, reverse= True))
