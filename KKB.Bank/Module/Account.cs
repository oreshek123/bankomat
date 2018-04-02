using System;
using System.Collections.Generic;
using System.Text;

namespace KKB.Bank.Module
{
    public class Account
    {
        public Account()
        {
            ListCards = new List<Cards>();
        }
        public DateTime CreateDay { get; set; }
        public DateTime CloseDate { get; set; }
        public string AccountNumber { get; set; }
        public double Balance { get; set; } = 0;
        public List<Cards> ListCards;

        public void PrintCardInfo()
        {
            foreach (Cards item in ListCards)
            {
                Console.WriteLine($"{item.GetCardNumber()}\n{item.cardType}\n{item.CCV}");
            }
        }
    }
}
