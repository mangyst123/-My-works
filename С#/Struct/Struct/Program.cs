using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Объявление структуры
            /*
            Vector2 position = new Vector2(10);
            Console.WriteLine(position.X);
            position.X = 16;
            Console.WriteLine(position.X);
            */

            // Ошибки при работе
            /*
            Vector2 targetPosition = new Vector2(10, 10);
            Vector2 playerPosition = targetPosition;
            playerPosition.X += 15;

            Console.WriteLine("Позиция игрока после изменения: " + playerPosition.X);
            Console.WriteLine("Целевая позиция, после изменения позиции игрока: " + targetPosition.X);
            */

            // Ошибка при работе с классом и структурой
            /*
            GameObject bullet = new GameObject();
            // bullet.Position.X = 50; !!!Нельзя так
            Console.WriteLine(bullet.Position.X);

            // Нужно делать так
            Vector2 newPosition = bullet.Position;
            newPosition.X = 50;
            bullet.Position = newPosition;

            Console.WriteLine(bullet.Position.X);
            */
        }
    }
    /// ////////////////////
    // Структура
    struct Vector2
    {
        public int X, Y;
        public Vector2(int x, int y)
        {
            X = x;
            Y = y;
        }
        public Vector2(int x) : this()
        {
            X = x;
        }
    }
    /// ////////////////////
    // Класс для демонстрации ошибки 
    class GameObject
    {
        public Vector2 Position { get; set; }
    }
    /// ////////////////////
}
