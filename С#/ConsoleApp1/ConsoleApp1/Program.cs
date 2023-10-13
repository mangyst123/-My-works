using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // То как работает рандом (Просто для справки)
            /*
            Random rand = new Random();
            int a = rand.Next(0, 1654), i = 0;

            while (i++ < 100)
            {
                Console.WriteLine(rand.Next(0, 1654));
                Console.ReadKey();
            }
            */
            // Програмка простенькая (Угадай число)
            /*
            int maxNumber = 999,
                number, 
                health, armor, damage,
                lower, higher,
                triesCount = 5,
                userInput;
            Random random = new Random();

            number = random.Next(0, maxNumber);
            lower = random.Next(number - 15, number);
            higher = random.Next(number + 1, number + 15);

            Console.WriteLine($"Загаданное число в диапазоне от {lower} до {higher}");

            while (triesCount-- > 0)
            {
                Console.Write("Введите свое число: ");
                userInput = Convert.ToInt32(Console.ReadLine());
                if (userInput == number)
                {
                    Console.Write("Вы угадали число!!!");
                    break;
                }
                else
                {
                    Console.WriteLine("Пе верный ответ, у вас осталось попыток " + triesCount);
                }
            }
            if (triesCount < 0)
            {
                Console.WriteLine("Вы не угадали число: " + number);
            }
            Console.ReadKey();
            */

            // Работа с консолью
            /*
            // Редактирование консоли
            // Работа с окном
            Console.WindowWidth = 50;
            Console.WindowHeight = 10;
            // Работа с цветом
            Console.ForegroundColor = ConsoleColor.Green;
            //Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            // Просто вывод/вывод данных
            Console.WriteLine("Привет мир! Напишите, как у вас дела)");
            Console.ReadLine();
            Console.ReadKey();
            */

            // Работа с массивом одномерным
            /*
            Console.ForegroundColor = ConsoleColor.Green;
            int[] cucubers = { 1, 4, 6, 4, 9, 4 ,94 ,4 ,49 ,49, 7 ,4 };
            int len = cucubers.Length;
            int maxElement = int.MinValue;

            for(int i = 0; i < len; i++)
            {
                if (cucubers[i] > maxElement)
                {
                    maxElement = cucubers[i];
                }
            }
            Console.WriteLine(maxElement);
            Console.ReadKey();
            */

            // Работа с двумерным (многомерным массиврм)
            /*
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(10, 0);
            Console.WriteLine("    Что бы сгенирировать массив, нажмите entr. ");
            Console.SetCursorPosition(10, 1);
            Console.WriteLine("Для выхода из программы, нажмите любую другую кнопку (очистить консоль, нажмите [ C ])");

            ConsoleKeyInfo input = Console.ReadKey();
            int xConsol = 0, yConsol = 3, maxElement = 1000, fault = 0 , stringArray = 5, columnArray = 4;
            while (input.Key == ConsoleKey.Enter || input.Key ==ConsoleKey.C) 
            {
                Random random = new Random();
                int[,] arrayNew = new int[stringArray, columnArray];
                // Создание массива
                for (int i = 0; i < stringArray; i++)
                {
                    for (int j = 0; j < columnArray; j++)
                    {
                        arrayNew[i,j] = random.Next(0, maxElement); 
                    }
                }

                Console.SetCursorPosition(xConsol + fault, yConsol-1);
                Console.WriteLine("********************");
                Console.SetCursorPosition(xConsol + fault, yConsol);
                // Красивый вывод массивов
                for (int i = 0, m = 0, w = 0; i < stringArray; i++, m++)
                {
                    Console.SetCursorPosition(xConsol + fault, yConsol + w);
                    Console.Write("| ");
                    w++;
                    for (int j = 0; j < columnArray; j++)
                    {

                        Console.Write(arrayNew[i, j] + " ");
                    }
                    Console.Write("\n");
                }
                Console.SetCursorPosition(xConsol + fault, yConsol + stringArray);
                Console.WriteLine("********************");
                input = Console.ReadKey();
                yConsol += stringArray + 1;
                if (yConsol >= 27)
                {
                    yConsol = 3;
                    switch (maxElement)
                    {
                        case 10:
                            fault += columnArray + 6;
                            break;
                        case 100:
                            fault += columnArray*2 + 6;
                            break;
                        case 1000:
                            fault += columnArray * 3 + 6;
                            break;
                        case 10000:
                            fault += columnArray * 4 + 6;
                            break;
                        default:
                            break;
                    }
                }
                if (input.Key == ConsoleKey.C)
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(10, 0);
                    Console.WriteLine("    Что бы сгенирировать массив, нажмите entr. ");
                    Console.SetCursorPosition(10, 1);
                    Console.WriteLine("Для выхода из программы, нажмите любую другую кнопку (очистить консоль, нажмите [ C ])");
                    xConsol = 0;
                    yConsol = 3;
                    maxElement = 1000;
                    fault = 0;
                    stringArray = 5;
                    columnArray = 4;
                }
            }
            */

            //Функции 
            /*
            do
            {
                Console.ReadLine();
                WriteErro("Соединение с интернетом отсутствует!", symvol : '@');
            }
            while (Console.ReadKey().Key == ConsoleKey.Enter);

            int sum = 0, x = 5, y = 9;
            Add(ref sum, x, y); // Можно out, тогда не нужно инициализировать переменную 
            Console.WriteLine(sum);
            Console.ReadKey();
            

            int[] array = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            array = EditArray(array, 5, 999);
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
            Console.ReadKey();
            */

            // Все остальное
            
            Console.ReadKey();
        }
        // Функция (для теста)
        static void WriteErro(string TEXT, ConsoleColor color = ConsoleColor.Red, char symvol = '*')
        {
            ConsoleColor defalrColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(TEXT);
            Console.ForegroundColor = defalrColor;
        }
        static void Add(ref int sum, int x, int y)
        {
            sum = x + y;
        }
        static int[] EditArray(int[] array, int index, int value)
        {
            //array = new int[array.Length + 5];
            array[index] = value;
            return array;
        }
    }
}