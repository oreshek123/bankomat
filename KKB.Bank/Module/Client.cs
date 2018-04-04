using System;
using System.Collections.Generic;
using System.Text;


namespace KKB.Bank.Module
{
    public class Client
    {
        public Client()
        {
            accounts = new List<Account>();
        }
        private string fullName_;
        public string FullName { get { return fullName_; }
            set {
                fullName_ = value.Replace("<center><b><font size=7>","").Replace("</font></b></center>","");

            }
        }
        private string IIN_;
        public string IIN {
            get { return IIN_; }
            set {
                if (value.Length == 12)
                {
                    IIN_ = value;
                }
                else
                {
                    throw new Exception("Некорректно введен ИИН");
                }
                    
            }
        }
        public DateTime DoB { get; set; }
        public string PhoneNumber { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public List<Account> accounts;
        private int wrongField_ = 0;
        public bool IsBlocked { get; set; } = false;
        public int WrongField {
            get { return wrongField_; }
            set
            {
                if (value >= 3)
                IsBlocked = true;

                wrongField_ = value;
                
            }
        }

        public void PrintClientInfo()
        {
            string value = $"{FullName}\n{IIN}\n{DoB}\n{PhoneNumber}\n{Login}\n{Password}";
            Console.WriteLine(value);
        }

        public void PrintAccountInfo()
        {
            double sumBalance = 0;
            foreach (Account item in accounts)
            {
                Console.WriteLine($"Номер счета : {item.AccountNumber}\nДата создания : {item.CreateDay}\nБаланс : {item.Balance}");
                sumBalance += item.Balance;
            }
            Console.WriteLine($"Сумма баланса на всех счетах : {sumBalance}");
        }
      

    }
}
