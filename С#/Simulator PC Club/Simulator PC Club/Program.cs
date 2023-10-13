using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator_PC_Club
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ComputerClab computerClab = new ComputerClab(8);
            computerClab.Work();
        }
    }

    class ComputerClab
    {
        private int _money = 0;
        private List<Computer> _computers = new List<Computer>();
        private Queue<Client> _clients = new Queue<Client>();

        public ComputerClab(int computersCount) 
        { 
            Random random = new Random();

            for (int i = 0; i < computersCount; i++)
            {
                _computers.Add(new Computer(random.Next(5, 15)));
            }
            CreateNewClients(25, random);
        }
        public void CreateNewClients (int count, Random random)
        {
            for (int i = 0; i < count; i++)
            {
                _clients.Enqueue(new Client(random.Next(100,250),random));
            }
        }
        // Основной метод работы клуба
        public void Work()
        {
            while (_clients.Count > 0)
            {
                Client newclient = _clients.Dequeue();
                Console.WriteLine($"Баланс компьютерного клуба {_money} руб. Ждем нового клиента.");
                Console.WriteLine($"У вас новый клиентб он хочет купить {newclient.DesiredMinutes} минут.");
                ShowALlComputersStates();

                Console.Write("\nВы предлагаете ему компьютер под номером: ");
                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out int computerNumber))
                {
                    computerNumber -= 1;

                    if (computerNumber >= 0 && computerNumber < _computers.Count)
                    {
                        if (_computers[computerNumber].IsTaken)
                            Console.WriteLine("Вы пытаетесь посадить клиента за компьютер, который уже занят. Клиент разозлился и ушел.");
                        else
                        {
                            if (newclient.ChectSolvence(_computers[computerNumber]))
                            {
                                Console.WriteLine("Клиент оплатил и сел за компьютер: " + computerNumber + 1);
                                _money += newclient.Pay();
                                _computers[computerNumber].BecomeTaken(newclient);
                            }
                            else
                                Console.WriteLine("У клиента не хватило денег и он ешёл ");
                        }
                    }
                    else
                        Console.WriteLine("Вы сами не знаете за какой компьютер посадить клиента. Он разозлился и ушел.");
                }
                else
                {
                    CreateNewClients(1, new Random());
                    Console.WriteLine("Неверный ввод! Повторите снова.");
                }

                Console.WriteLine("Что бы перейти к следующему клиенту нажмите любую клавишу.");
                Console.ReadKey();
                Console.Clear();
                SpendOneMinute();
            }
            Console.WriteLine($"Все клиенты закончились, ваш итоговый баланс {_money} рублей!!!");
            Console.WriteLine("Нажмите любую клавишу, что бы выйти");
            Console.ReadKey();
        }
        private void ShowALlComputersStates()
        {
            Console.WriteLine("\nСписок всех компьютеров: ");
            for (int i = 0; i < _computers.Count; i++)
            {
                Console.Write(i + 1 +" - ");
                _computers[i].ShowState();
            }
        }
        private void SpendOneMinute()
        {
            foreach (var computer in _computers)
            {
                computer.SpendOneMinute();
            }
        }
    }
    class Computer
    {
        private Client _client;
        private int _minutesRemaining;
        public bool IsTaken 
        { 
            get
            {
                return _minutesRemaining > 0;
            }
        }
        public int PricePerMinute { get; private set;}

        public Computer(int pricePerMinute)
        {
            PricePerMinute = pricePerMinute;
        }
        // Плохой пример, лучше передавай сразу DesiredMinutes а не клиента
        public void BecomeTaken(Client client)
        {
            _client = client;
            _minutesRemaining = _client.DesiredMinutes;
        }
        public void BecomeEmpty()
        {
            _client = null;
        }

        public void SpendOneMinute ()
        {
            _minutesRemaining--;
        }
        public void ShowState()
        {
            if (IsTaken)
                Console.WriteLine($"Компьютер занят, осталось минут: {_minutesRemaining}");
            else 
                Console.WriteLine($"Компьютер свободен, цена за минуту: {PricePerMinute}");
        }
    }
    class Client
    {
        public int _money;
        private int _moneyToPay;
        public int DesiredMinutes{ get; private set; }
        public Client(int money, Random random)
        {
            _money = money;
            DesiredMinutes = random.Next(10, 30);
        }
        public bool ChectSolvence(Computer computer)
        {
            _moneyToPay = DesiredMinutes * computer.PricePerMinute;
            if (_money >= _moneyToPay)
                return true;
            else
            {
                _moneyToPay = 0;
                return false;
            }
                

        }
        public int Pay()
        {
            _money -= _moneyToPay;
            return _moneyToPay;
        }

    }
}
