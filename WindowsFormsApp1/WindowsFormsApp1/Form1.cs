using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.MVC;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        Controller controller;
        public Form1()
        {
            InitializeComponent();
            controller = new Controller(this.Controls);
            controller.initGame();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            controller.Undo();
        }
    }
}
