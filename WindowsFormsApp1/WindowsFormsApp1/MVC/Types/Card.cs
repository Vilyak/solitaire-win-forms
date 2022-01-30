using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.MVC.Types
{

    public enum Suit
    {
        Diamonds, 
        Hearts, 
        Clubs, 
        Spades
    }

    internal class Card
    {
        private Suit suit;
        private string value;

        public Suit Suit
        {
            get { return suit; }
        }

        public string Value
        {
            get { return value; }
        }


        public Card(Suit suit, string value)
        {
            this.suit = suit;
            this.value = value;
        }
    }
}
