using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.MVC.Types;

namespace WindowsFormsApp1.MVC
{
    internal class Model
    {
        private string[] allValues = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
        private List<Card> allCards;
        private Card[] field;

        public Card[] Field
        {
            get { return field; }
            set { field = value; }
        }

        public List<Card> ALL_CARDS
        {
            get { return allCards; }
        }

        public Model()
        {
            allCards = new List<Card>();
            field = new Card[52];


            Suit[] suits = (Suit[])Enum.GetValues(typeof(Suit));
            allValues.ToList().ForEach(value =>
            {
                suits.ToList().ForEach(suit =>
                {
                    allCards.Add(new Card(suit, value));
                });
            });

            field = allCards.ToArray().Clone() as Card[];

            shuffleField();
            shuffleField();
            shuffleField();
            shuffleField();
        }

        private void shuffleField()
        {
            Random rnd = new Random();
            field = field.OrderBy(x => rnd.Next()).ToArray();
        }

        public void setField(Card[] newField)
        {
            this.field = newField;
        }
    }
}
