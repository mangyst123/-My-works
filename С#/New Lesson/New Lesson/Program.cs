using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_Lesson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Полиморфизм для методов класса
            /*
            NonPlayerCharacter[] characters =
            {
                new NonPlayerCharacter(),
                new Farmer(),
                new Knight(),
                new Chaild()
            };
            foreach (var character in characters)
            {
                character.ShowDescription();
                Console.WriteLine(new string('*', 40));
            }
            */

            // Полиморфизм для обновления состояний объекта
            /*
            Behavior[] behaviors =
            {
                new Walker(),
                new Jumper()
            };

            while (true)
            {
                foreach (var behavior in behaviors)
                {
                    behavior.Update();
                    System.Threading.Thread.Sleep(1000);
                }
            */
        }
    }

    /////////////////////////////
    class NonPlayerCharacter
    {
        public virtual void ShowDescription()
        {
            Console.WriteLine("Я просто NPC умею только гулять");
        }
    }
    class Farmer : NonPlayerCharacter
    {
        public override void ShowDescription() 
        {
            base.ShowDescription();
            Console.WriteLine("А ещё я фермер и умею работать на поле.");
        }
    }
    class Knight : NonPlayerCharacter
    {
        public override void ShowDescription()
        {
            Console.WriteLine("Я умею только сражатся");
        }
    }
    class Chaild : NonPlayerCharacter
    {
        public override void ShowDescription()
        {
            Console.WriteLine("Я умею только ничего не делать");
        }
    }
    /////////////////////////////
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
    class Jumper : Behavior
    {
        public override void Update()
        {
            Console.WriteLine("Прыгаю");
        }
    }
    /////////////////////////////
}
