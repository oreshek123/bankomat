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
                        Console.Clear();
                        do
                        {

                            Console.WriteLine("1) список счетов\n2) создать счет\n3) пополнение счета\n4) снять деньги со счёта\n5) выход");

                            Int32.TryParse(Console.ReadLine(), out var choice);
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
                                    Console.WriteLine("\n\nдля выхода в меню нажмите Enter \t2) выход");
                                    Int32.TryParse(Console.ReadLine(), out int result);
                                    if (result == 2)
                                    {
                                        return;
                                    } 
                                    break;
                                case 2:
                                {
                                    client1.accounts?.Add(Service.createAccounts());
                                    Console.WriteLine("Счет добавлен успешно");
                                    Console.WriteLine("\n\nдля выхода в меню нажмите Enter\t2) выход");
                                    Int32.TryParse(Console.ReadLine(), out result);
                                     if (result == 2)
                                    {
                                        return;
                                    }
                                    }
                                    break;
                                case 3:
                                    {
                                        Console.WriteLine("Введите номер счета :");
                                        string accountNumber = Console.ReadLine();
                                        Console.WriteLine("Введите сумму");
                                        string accountSum = Console.ReadLine();
                                        Service.AddMoneyToAccount(accountNumber,accountSum,ref client1);
                                        Console.WriteLine($"Счет {accountNumber} пополнен на сумму {accountSum} успешно");
                                        Console.WriteLine("\n\nдля выхода в меню нажмите Enter\t2) выход");
                                        Int32.TryParse(Console.ReadLine(), out result);
                                        if (result == 2)
                                        {
                                            return;
                                        }
                                    }
                                    break;
                                case 4:
                                {
                                        Console.WriteLine("Введите номер счета :");
                                        string accountNumber = Console.ReadLine();
                                        Console.WriteLine("Введите сумму");
                                        string accountSum = Console.ReadLine();
                                        bool isValid = Service.RemoveMoneyFromAccount(accountNumber, accountSum, ref client1);

                                    Console.WriteLine(isValid == false
                                        ? "Сумма на счете не достаточна для списания"
                                        : $"Сумма {accountSum} успешно снята со счета {accountNumber}");

                                    Console.WriteLine("\n\nдля выхода в меню нажмите Enter\t2) выход");
                                    Int32.TryParse(Console.ReadLine(), out result);
                                    if (result == 2)
                                    {
                                        return;
                                    }
                                    }
                                    break;
                                case 5:
                                {
                                    return;
                                }
                                
                                default:
                                    return;
                            }
                            //Console.ReadLine();
                            Console.Clear();
                        }
                        while (true);
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
