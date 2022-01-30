using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.MVC.Types;
using static System.Windows.Forms.Control;

namespace WindowsFormsApp1.MVC
{
    internal class View
    {
        private ControlCollection controlCollection;
        private Image diamond;
        private Image heart;
        private Image clubs;
        private Image spades;


        public View(ControlCollection controlCollection)
        {
            this.controlCollection = controlCollection;
            diamond = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img\\Diamond.png"));
            heart = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img\\Heart.png"));
            clubs = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img\\Clubs.png"));
            spades = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img\\Spades.png"));
        }

        public void assignActions(int length, Action<int> action)
        {
            for (int i = 0; i < length; i++)
            {
                var index = i;
                var result = findByTag(index.ToString());
                Panel panel = result.Item1 as Panel;
                if (panel != null)
                {
                    panel.Click += new EventHandler((e, q) => action(index));
                }

                result.Item2.ForEach((item) =>
                {
                    item.Click += new EventHandler((e, q) => action(index));
                });
            }
        }

        public void setDarkBackgroundHandler(int index)
        {
            Panel panel = findByTag(index.ToString()).Item1 as Panel;
            if (panel != null)
            {
                panel.BackColor = panel.BackColor == Color.White ? Color.Gray : Color.White;
            }
        }

        public void update(Card[] field, int fieldLength)
        {
            for (int i = 0; i < fieldLength; i++)
            {
                Card item = i < field.Length ? field[i] : null;
                var result = findByTag(i.ToString());
                if (item != null)
                {
                    result.Item1.Visible = true;
                    result.Item2.ForEach(component =>
                    {
                        var img = component as PictureBox;
                        if (img != null)
                        {
                            img.Image = getImageBySuit(item.Suit);
                        } 
                        else {
                            component.Text = item.Value;
                            if (item.Value == "10")
                                component.Location = new Point(44, component.Location.Y);
                        }
                    });
                }
                else
                {
                    result.Item1.Visible = false;
                }
            }
        }

        private Image getImageBySuit(Suit type)
        {
            switch (type)
            {
                case Suit.Diamonds:
                    return diamond;
                case Suit.Hearts:
                    return heart;
                case Suit.Clubs:
                    return clubs;
                case Suit.Spades:
                    return spades;
                default:
                    return null;
            }

        }

        public (Control, List<Control>) findByTag(string tag)
        {
            var result = new List<Control>();
            Control parent = null;
            for (int i = 0; i < controlCollection.Count; i++)
            {
                Control root = controlCollection[i];
                if (compareByTag(root, tag))
                {
                    result.Add(root);
                }

                for (int j = 0; j < root.Controls.Count; j++)
                {
                    Control root2 = root.Controls[j];
                    if (compareByTag(root2, tag))
                    {
                        parent = root;
                        result.Add(root2);
                    }
                }
            }
            return (parent, result);
        }

        private bool compareByTag(Control root, string tag)
        {
            bool result = false;
            if (root == null)
            {
                result = false;
            }

            if (root.Tag is string && (string)root.Tag == tag)
            {
                result = true;
            }
            return result;
        }
    }
}
