﻿using KKB.Bank.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneratorName;

namespace Bankomat
{
    public class Service
    {
        private static Random random = new Random();
        public static void createClient(ref Client client)
        {
            Generator generator = new Generator();
            client.FullName = generator.GenerateDefault(Gender.woman);
            client.IIN = "000001111123";
            client.PhoneNumber = "87026112508";
            client.DoB = DateTime.Now;

            for (int i = 0; i <random.Next(1,8) ; i++)
            {
                client.accounts.Add(createAccounts());
            }
        }
        public static Account createAccounts()
        {
           
               Account account = new Account()
                {
                    AccountNumber = "KZ" + random.Next(11111,9999999),
                    CreateDay = DateTime.Now.AddMonths(-random.Next(1,56)),
                    Balance = double.Parse(random.Next(1000, 9999).ToString())
                };
            return account;
            

        }
    }
}
