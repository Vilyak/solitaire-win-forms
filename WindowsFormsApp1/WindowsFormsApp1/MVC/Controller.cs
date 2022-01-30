using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.MVC.Extensions;
using WindowsFormsApp1.MVC.Types;
using static System.Windows.Forms.Control;

namespace WindowsFormsApp1.MVC
{
    internal class Controller
    {
        private Model model;
        private View view;
        private List<Card[]> history;
        private int selectedCradIndex = -1;

        public Controller(ControlCollection controlCollection)
        {
            model = new Model();
            view = new View(controlCollection);
            history = new List<Card[]>();
        }

        public void initGame()
        {
            if (model != null && view != null)
            {
                updateField();
                view.assignActions(model.Field.Length, onCardClick);
            }
        }

        public void Undo()
        {
            if (history.Count > 0)
            {
                model.setField(history.Last());
                history.RemoveAt(history.Count - 1);
                updateField();
            }
        }

        private void updateField()
        {
            view.update(model.Field, model.ALL_CARDS.Count);
        }

        private void onCardClick(int index)
        {
            if (selectedCradIndex == -1)
            {
                selectedCradIndex = index;
                view.setDarkBackgroundHandler(index);
            }
            else if (selectedCradIndex == index)
            {
                selectedCradIndex = -1;
                view.setDarkBackgroundHandler(index);
            }
            else process(selectedCradIndex, index);
        }

        private void process(int start, int next)
        {
            if (Math.Abs(start - next) <= 3)
            {
                int firstCardIndex = Math.Min(start, next);
                int secondCardIndex = Math.Max(start, next);

                Card firstCard = model.Field[firstCardIndex];
                Card secondCard = model.Field[secondCardIndex];

                if (firstCard.Suit == secondCard.Suit || firstCard.Value == secondCard.Value)
                {
                    history.Add(model.Field.Clone() as Card[]);
                    Card[] cards = model.Field;
                    ArrayExtensions.swapValues(cards, firstCardIndex, secondCardIndex);
                    List<Card> newField = cards.ToList();
                    newField.RemoveAt(secondCardIndex);
                    model.setField(newField.ToArray());
                    onCardClick(selectedCradIndex);
                    updateField();
                }
            }
        }
    }
}
