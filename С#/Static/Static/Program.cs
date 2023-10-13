using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Static
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Работа со статическими методами
            /*
            User.Identifications = 10;
            User user1 = new User();
            User user2 = new User();
            user1.ShowInfo();
            user2.ShowInfo();
            */

            // Статический констурктор 
            Console.WriteLine("Привет мир!");
            MyClass instans = new MyClass();
            Console.WriteLine(MyClass.StaticFild);
        }
    }
    /// ////////////////////
    // Класс со статическим полем
    class User
    {
        public static int Identifications;
        public int Identification;
        public int MenHourPrice;

        public User()
        {
            Identification = ++Identifications;
        }
        public void ShowInfo()
        {
            Console.WriteLine(Identification);
        }
        public int GetSelaryDay(int workedHours)
        {
            return MenHourPrice * workedHours;
        }
        // Ошибка!!!
        /* 
        public static int GetSalaryPerMonth(int workedDays) 
        {
            return GetSelaryDay(8) * workedDays;
        }
        */

        // Надо так
        public int GetSalaryPerMonth(int workedDays)
        {
            return GetSelaryDay(8) * workedDays;
        }
    }
    /// ////////////////////
    // Статический констурктор 
    class MyClass 
    {
        public static float StaticFild;
        static MyClass() 
        {
            StaticFild = 10.0f;
            Console.WriteLine("Статисекций конструктор.");
        }
        public MyClass() 
        {
            Console.WriteLine("Обычные конструктор");
        }
    }

}
