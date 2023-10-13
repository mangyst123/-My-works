using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace newProjectByCurse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Работа со списком
            /*
            List<int> numbers = new List<int>();
            numbers.Add(999);
            numbers.Add(541);
            numbers.Add(500);

            numbers.AddRange(new int[] { 5, 6, 7, 4, 97, 6 });

            numbers.RemoveAt(0);
            numbers.Remove(500);

            numbers.Insert(3, 9999);

            for (int i = 0; i < numbers.Count; i++)
                Console.WriteLine(numbers[i]);
            */

            // Очередь (Queue)
            /*
            Queue<string> patients = new Queue<string>();

            patients.Enqueue("Василий");
            patients.Enqueue("Пётр");

            Console.WriteLine("Сейчас на прием идет: " + patients.Dequeue());
            Console.WriteLine("Следующий в очереди: " + patients.Peek());

            foreach (var patient in patients) 
            {
                Console.WriteLine(patient);
            }
            */

            // Стек 
            /*
            Stack<int> numbers = new Stack<int>();

            numbers.Push(1);
            numbers.Push(2);
            numbers.Push(3);
            numbers.Push(4);
            numbers.Push(5);
            numbers.Push(6);

            //Console.WriteLine(numbers.Peek());

            //numbers.Pop();

            while (numbers.Count > 0) 
                Console.WriteLine("Следующее число в стеке: " + numbers.Pop());

            foreach (int number in numbers) 
                Console.WriteLine(number); 
            */

            // Dictionary (Словарь)
            /*
            Dictionary<string, string> countrieCapitals = new Dictionary<string, string>();

            countrieCapitals.Add("Австралия", "Канберра");
            countrieCapitals.Add("Турция", "Анкара");
            countrieCapitals.Add("Швейцария", "Берн");

            countrieCapitals.Remove("Турция");

            foreach (var item in countrieCapitals)
            {
                Console.WriteLine($"Страна - {item.Key} столица {item.Value}");
            }
            */

            // Концепция ООП
            /*
            Car ferarri = new Car();
            ferarri.ShowTechicalPasport();
            */

            // Стол
            /*
            Table[] tables = { new Table(1, 4), new Table(2, 5), new Table(3, 10) };
            bool isOpen = true;

            while (isOpen)
            {
                Console.WriteLine("Администрирование кафе.\n");
                for (int i = 0; i < tables.Length; i++)
                    tables[i].ShowInfo();

                Console.Write("\nВведите номер стола: ");

                int wishTable = Convert.ToInt32(Console.ReadLine()) - 1;

                Console.Write("Введите количество мест для брони: ");
                int desiredPlaces = Convert.ToInt32(Console.ReadLine());

                if (tables[wishTable].Reserve(desiredPlaces))
                    Console.WriteLine("Бронь прошла успешно!");
                else
                    Console.WriteLine("Бронь не прошла, недостаточно мест.");

                Console.ReadKey();
                Console.Clear();
            */

            // Наследование (Генерализация)
            /*
            Knight warrior1 = new Knight(110, 10);
            Barbarian warrior2 = new Barbarian(75, 7, 2);

            int hit = warrior1.TakeDamage(50);
            Console.Write($"Рыцарь получил {hit} урона, здоровья осталось: ");
            warrior1.ShowInfo();

            hit = warrior2.TakeDamage(50);
            Console.Write($"Варвар получил {hit} урона, здоровья осталось: ");
            warrior2.ShowInfo();
            */

            // Инкапсуляция (Прикольная вешь)
            /*
            Randerer randerer = new Randerer();
            Player player = new Player(55, 10);

            randerer.Drow(player.X, player.Y);
            */
            
            //
        }
    }
    ////////////////////////////////////////
    class Car
    {
        public string Name;
        public int HorsePower;
        public int Age;
        public float MaxSpeed;

        public Car(string name, int horsePower, int age, float maxSpeed)
        {
            Name = name;
            HorsePower = horsePower;
            Age = age;
            MaxSpeed = maxSpeed;
        }
        public Car()
        {
            Name = "Ford";
            HorsePower = 500;
            Age = 1;
            MaxSpeed = 300.0f;
        }

        public void ShowTechicalPasport()
        {
            Console.WriteLine($"Название авто: {Name}\nКоличество лощадиных сил: {HorsePower}\nВозраст авто: {Age}\n" +
                              $"Максимальная скорость: {MaxSpeed}");
        }
    }
    class Table
    {
        public int Number;
        public int MaxPlaces;
        public int FreePlaces;
        public Table(int number, int maxPlaces)
        {
            Number = number;
            MaxPlaces = maxPlaces;
            FreePlaces = maxPlaces;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"Стол: {Number}. Свободно: {FreePlaces} из {MaxPlaces}.");
        }
        public bool Reserve(int places)
        {
            if (FreePlaces >= places)
            {
                FreePlaces -= places;
                return true;
            }
            else
                return false;
        }
    }
    /////////////////////////////////////////
    class Warrior
    {
        protected int Health;
        protected int Armor;
        protected int Damage;

        public Warrior(int health, int armor, int damage)
        {
            Health = health;
            Armor = armor;
            Damage = damage;
        }

        public int TakeDamage(int damage)
        {
            Health -= damage - Armor;
            return damage - Armor;
        }

        public void ShowInfo()
        {
            Console.WriteLine(Health);
        }
    }
    class Knight : Warrior 
    {

        public Knight(int health, int damage) : base(health, 7, damage) { }

        public void Pray()
        {
            Armor += 2;
        }
    }
    class Barbarian : Warrior
    {
        public Barbarian(int health, int damage, int attacSpeed) : base(health, 10, damage * attacSpeed) { }

        public void Shout()
        {
            Armor -= 2;
            Health += 20;
        }
    }
    ////////////////////////////////////////
    class Randerer
    {
        public void Drow(int x, int y, char character = '@')
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(x, y);
            Console.Write(character);
            Console.ReadKey(true);
        }
    }
    class Player
    {
        // Автореализуемые свойства
        public int X { get; private set; }
        public int Y { get; private set; }
        public Player(int x, int y) 
        {
            X = x;
            Y = y;
        }
    }
    ////////////////////////////////////////
}
