using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    internal class Program
    {
        static void Main(string[] args)
        {

            IMovable car = new Car();
            IMovable man = new Human();

        }
    }
    interface IMovable
    {
        void Move();
    }
    interface IBernable
    {
        void Burn();
    }

    class Vehicle
    {

    }
    class Car : Vehicle, IMovable, IBernable
    { 
        public void Move()
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
    }

}
