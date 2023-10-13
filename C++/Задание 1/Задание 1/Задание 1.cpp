#include "Main_class.h"
using namespace std;
using namespace tinyxml2; // Пространство имен, для библиотеки tinyxml2

int main() // Главная функция вызывающаяся при старте проекта
{
    Main_class start; // Создаю объект класса Main_class

    // Возвращает список водителей
    General<Drivers> dr = start.return_the_Drivers_list();

    // Записывает новый путь в файл
    start.new_route("Krasnoyarsk-Kurs", 4338, 12, 777);
}