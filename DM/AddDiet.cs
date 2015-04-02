using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql;
using MySql.Data.MySqlClient;
using System.Data.Odbc;

namespace DM
{
    public partial class AddDiet : Form
    {
        public AddDiet()
        {
            InitializeComponent();
        }

        private void AddDiet_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection mycon;
            const string MyConString =
            "server=localhost;" +
            "port=3306;" +
            "Database=diningroom;" +
            "Uid=root;" +
            "Pwd=2015;" +
            "CharSet = utf8; ";

            try
            {
                mycon = new MySqlConnection(MyConString);
                mycon.Open();
                string name = textBox1.Text;
                int minProteins = (int)numericUpDown1.Value;
                int minFats = (int)numericUpDown2.Value;
                int minCarbohydrates = (int)numericUpDown3.Value;
                int minCalorificValue = (int)numericUpDown4.Value;
                int maxProteins = (int)numericUpDown5.Value;
                int maxFats = (int)numericUpDown6.Value;
                int maxCarbohydrates = (int)numericUpDown7.Value;
                int maxCalorificValue = (int)numericUpDown8.Value;
                string description = textBox2.Text;
                string sql =
                    "INSERT INTO `diets` (`name`,`minProteins`,`maxProteins`,`minFats`,`maxFats`,`minCarbohydrates`,`maxCarbohydrates`,`minCalorificValue`,`maxCalorificValue`,`description`)" +
                    "VALUE (" +
                    '"' + name + "\"," +
                    minProteins + ',' +
                    maxProteins + ',' +
                    minFats + ',' +
                    maxFats + ',' +
                    minCarbohydrates + ',' +
                    maxCarbohydrates + ',' +
                    minCalorificValue + ',' +
                    maxCalorificValue + ',' +
                    '"'+ description + '"' +
                    ")";
                MySqlCommand mycom = new MySqlCommand(sql, mycon);
                mycom.ExecuteNonQuery();
                mycon.Close();
                

            }
            catch (InvalidCastException er)
            {


                MessageBox.Show("Нед подключения к серверу" + er.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
