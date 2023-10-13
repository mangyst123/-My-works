using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Virtual_metods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Виртуальные методы
            /*
            NonePlayerCharacter[] characters = {
                new NonePlayerCharacter(),
                new Farmer(),
                new Knight(),
                new Child()

            };

            foreach (var character in characters)
            {
                character.ShowDiscription();
                Console.WriteLine(new string('-',45));
            }
            */

            // Шаблон (цикл обновления)
            /*
            Behavior[] behaviors =
            {
                new Walker(),
                new Jamper()
            };

            while (true)
            {
                foreach (Behavior behavior in behaviors) 
                { 
                    behavior.Update();
                    System.Threading.Thread.Sleep(1000);
                }
            }
            */

            // Интерфейсы
            // IMovable car = new Car();

            // Абстрактные классы
            /*
            Vehicle[] vehicles = {
                new Car1(),
                new Train()
            };
            */
        }
    }
    // Ad hoc Полиморфизм 
    /// ///////////////////
    class NonePlayerCharacter
    {
        public virtual void ShowDiscription()
        {
            Console.WriteLine("Я простой нпс, умею только гулять");   
        }
    }
    class Farmer : NonePlayerCharacter
    {
        public override void ShowDiscription() 
        { 
             base.ShowDiscription();
            Console.WriteLine("А ещё работаю на поле.");
        }
    }
    class Knight : NonePlayerCharacter
    {
        public override void ShowDiscription()
        {
            Console.WriteLine("Я умею только срааться");
        }
    }
    class Child : NonePlayerCharacter
    {
        public override void ShowDiscription()
        {
            base.ShowDiscription();
        }
    }
    /// ////////////////////
    // Шаблон (цикл обновления)
    class Behavior
    {
        public virtual void Update() 
        { 
            
        }
    }
    class Walker : Behavior 
    {
        public override void Update()
        {
            Console.WriteLine("Иду");
        }
    }
    class Jamper : Behavior
    {
        public override void Update()
        {
            Console.WriteLine("Прыгаю");
        }
    }
    /// ////////////////////
    // Интерфейсы
    interface IMovable
    {
        void Move();
        void ShowMoveSpeed();
    }
    interface IBerneble
    {
        void Burn();
    }
    class Vhicle1
    {

    }
    class Car : Vhicle1, IMovable, IBerneble
    { 
        public void Move()
        {

        }
        public void ShowMoveSpeed()
        {

        }
        public void Burn()
        {

        }
    }
    class Human : IMovable
    {
        public void Move()
        {

        }
        public void ShowMoveSpeed()
        {

        }
    }
    /// ////////////////////
    // Абстрактные классы
    abstract class Vehicle
    {
        protected float Speed;

        public abstract void Move();

        public float GetCurrentSpeed()
        {
            return Speed;
        }

    }
    class Car1 : Vehicle
    {
        public override void Move()
        {
            Console.WriteLine("Машина едет по асфальту.");
        }
    }
    class Train : Vehicle
    {
        public override void Move()
        {
            Console.WriteLine("Поезд едет по рельсам.");
        }
    }
    /// ////////////////////
}
