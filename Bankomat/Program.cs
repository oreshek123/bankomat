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
            List<Client> clients = new List<Client>();

            Generator generator = new Generator();

            clients.Add(new Client()
            {
                DoB = DateTime.Now.AddYears(-60),
                FullName = generator.GenerateDefault(Gender.woman),
                IIN = "123456789123",
                Login = "Nastya",
                Password = "123",
                PhoneNumber = "87026112508"
            });
          
        
        }
    }
}
