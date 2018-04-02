using System;
using System.Collections.Generic;
using System.Text;

namespace KKB.Bank
{
    public enum CardType
    {
        Visa,
        MasterCard,
        Maestro
    }
    public class Cards
    {
        public string CardNumber {get ;private set; }
        public DateTime ExpDate { get; set; }
        public int CCV { get; set; }
        public CardType  cardType {get; set;}

        public string GetCardNumber()
        {
            string[] newCardNumber = CardNumber.Split(' ');
            newCardNumber[1] = "****";
            newCardNumber[2] = "****";
            return ($"{newCardNumber[0]} {newCardNumber[1]}  {newCardNumber[2]} {newCardNumber[3]}");
        }

    }
}
