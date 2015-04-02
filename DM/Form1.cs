using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void добавитьДиетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddDiet f2 = new AddDiet();
            f2.Show();
        }

        private void добавитьРаскладкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddDish f2 = new AddDish();
            f2.Show();
        }
    }
}
