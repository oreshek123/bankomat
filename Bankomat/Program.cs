using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneratorName;
using KKB.Bank.Module;

namespace Bankomat
{
    class Program
    {
        static void Main(string[] args)
        {
            string login = "";
            string password = "";
            try
            {
                Client client1 = new Client()
                {
                    Login = "Nastya",
                    Password = "123"
                };
                Service.createClient(ref client1);
                int i = 0;
                while (!client1.IsBlocked)
                {
                    Console.Clear();
                    Console.WriteLine("Введите логин");
                    login = Console.ReadLine();
                    Console.WriteLine("Введите пароль");
                    password = Console.ReadLine();


                    if (login != client1.Login || password != client1.Password)
                        client1.WrongField++;
                    else break;
                    if (client1.IsBlocked)
                        Console.WriteLine("Заблокировано");
                }
                

                if (login == client1.Login && password == client1.Password)
                {
                    if (client1.IsBlocked)
                    {
                        throw new Exception("Аккаунт заблокирован");
                    }
                    else
                    {
                        int choice = 0;
                        Console.Clear();
                        while (true)
                        {
                           
                            Console.WriteLine("1) список счетов\n2) создать счет");
                           
                            Int32.TryParse(Console.ReadLine(), out choice);
                            Console.Clear();
                            switch (choice)
                            {
                                case 1:
                                    {
                                        if (client1.accounts != null)
                                        {
                                            Console.Clear();
                                            client1.PrintAccountInfo();
                                        }
                                    }
                                    break;
                                case 2:
                                    {
                                        client1.accounts.Add(Service.createAccounts());
                                        Console.WriteLine("Счет добавлен успешно");
                                    }
                                    break;
                                case 3:
                                    {
                                        Console.WriteLine("Введите номер счета :");
                                        string accountNumber = Console.ReadLine();
                                        Console.WriteLine("Введите сумму");
                                        string accountSum = Console.ReadLine();

                                    }
                                    break;
                                default:
                                    return;
                            }
                            Console.ReadLine();
                            Console.Clear();
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            #region hlam
            //List<Client> clients = new List<Client>();
            //Generator generator = new Generator();

            //Client client = new Client()
            //{
            //    DoB = DateTime.Now.AddYears(-60),
            //    FullName = generator.GenerateDefault(Gender.woman),
            //    IIN = "123456789123",
            //    Login = "Nastya",
            //    Password = "123",
            //    PhoneNumber = "87026112508"
            //};
            //clients.Add(client);
            //client.PrintClientInfo();
            #endregion
            Console.ReadLine();
        }
    }
}
