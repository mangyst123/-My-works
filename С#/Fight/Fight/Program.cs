using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Fighter[] fitghters =
            {
                new Fighter("Джон", 500, 50, 1),
                new Fighter("Марк", 250 , 25, 2),
                new Fighter("Валера", 150, 75, 3),
                new Fighter("Антон", 140, 100, 2),
            };

            int fighterNumber;

            for (int i = 0; i < fitghters.Length; i++)
            {
                Console.Write(((i+1) + " "));
                fitghters[i].ShowStats();
            }
            Console.WriteLine("\n** " + new string('-', 25) + " **");

            Console.Write("\nВыберете номер первого бойца: ");
            fighterNumber = Convert.ToInt32(Console.ReadLine()) - 1;
            Fighter firstFither = fitghters[fighterNumber];  
            
            Console.Write("\nВыберете номер второго бойца: ");
            fighterNumber = Convert.ToInt32(Console.ReadLine()) - 1;
            Fighter secondFither = fitghters[fighterNumber];

            Console.WriteLine("\n** " + new string('-', 25) + " **");

            while (firstFither.Health > 0 && secondFither.Health > 0)
            {
                firstFither.TakeDamage(secondFither.Damage);
                secondFither.TakeDamage(firstFither.Damage);

                firstFither.ShowCarrentHealth();
                secondFither.ShowCarrentHealth();
            }

            if (firstFither.Health < 0 && secondFither.Health < 0)
            {
                Console.WriteLine("Оба бойца убиты одновременно.");
            }
            else if (firstFither.Health < 0)
            {
                Console.WriteLine($"Победил боец: {secondFither.Name}.");
            }
            else if (secondFither.Health < 0)
            {
                Console.WriteLine($"Победил боец: {firstFither.Name}.");
            }
        }
    }
    class Fighter
    {
        private string _name;
        private int _health;
        private int _damage;
        private int _armor;
        private int _armorScale = 10;

        public int Health
        {
            get
            {
                return _health;
            }
        }
        public int Damage
        {
            get 
            { 
                return _damage;
            }
        }
        public string Name
        {
            get 
            { 
                return _name; 
            }
        }

        public Fighter(string name, int health, int damage, int armor)
        {
            _name = name;
            _health = health;
            _damage = damage;
            _armor = armor;
        }

        public void ShowStats()
        {
            Console.WriteLine($"Боец - {_name}, здоровье: {_health}, броня: {_armor} урон: {_damage}");
        }
        public void ShowCarrentHealth()
        {
            Console.WriteLine($"{_name} здоровье: {_health}");
        }
        public void TakeDamage(int damage) 
        { 
            _health -= damage - _armor*_armorScale;
        }
    }

}
