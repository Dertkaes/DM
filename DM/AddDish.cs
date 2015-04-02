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

namespace DM
{
    public partial class AddDish : Form
    {
        public AddDish()
        {
            InitializeComponent();
        }
        private int[] items;

        private void AddDish_Load(object sender, EventArgs e)
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
                string sql = "SELECT `iddiets`, `name` FROM `diets`";
                MySqlCommand mycom = new MySqlCommand(sql, mycon);
                mycom.ExecuteNonQuery();
                MySqlDataReader reader = mycom.ExecuteReader();
                if (reader.HasRows)
                {
                    int count = 0;
                    while (reader.Read())
                    {
                        int b = reader.GetInt32(0);
                        string buffer = reader.GetString(1);
                        comboBox1.Items.Add(buffer);
                        count++;
                    }
                    items = new int [count];
                    for (int i = 0; i < count; i++)
                    {
                        items[i] = reader.GetInt32(0);
                    }
                }
                reader.Close();
                mycon.Close();
            }
            catch (InvalidCastException er)
            {
                MessageBox.Show("Нед подключения к серверу" + er.Message);
            }
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
                int proteins = (int)numericUpDown1.Value;
                int fats = (int)numericUpDown2.Value;
                int carbohydrates = (int)numericUpDown3.Value;
                int calorificValue = (int)numericUpDown4.Value;
                int weight = (int)numericUpDown5.Value;
                int iddiets = items[comboBox1.SelectedIndex];
                string description = textBox2.Text;
                string sql = "INSERT INTO `layout` (`name`,`proteins`,`fats`,`carbohydrates`,`calorificValue`, `weight`, `description`)" +
                    "VALUE (" + 
                    '"' + name + "\"," +
                    proteins + ',' +
                    fats + ',' +
                    carbohydrates + ',' +
                    calorificValue + ',' +
                    weight + ',' +
                    '"' + description + '"' +
                    ")";
                MySqlCommand mycom = new MySqlCommand(sql, mycon);
                mycom.ExecuteNonQuery();
                sql = "SELECT MAX(`idlayout`) FROM `layout`";
                mycom = new MySqlCommand(sql, mycon);
                mycom.ExecuteNonQuery();   
                int idLayout = 0;
                MySqlDataReader reader = mycom.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        idLayout = reader.GetInt32(0);
                    }
                }
                reader.Close();
                sql = "INSERT INTO `diets_layout`  (`idLayout` ,`iddiets`)" +
                "VALUE (" +
                    idLayout + ',' +
                    iddiets +
                    ")";
                mycom = new MySqlCommand(sql, mycon);
                mycom.ExecuteNonQuery();
                for (int counter = 0; counter < (dataGridView1.Rows.Count)-1; counter++)
                {
                    string nameProduct = dataGridView1.Rows[counter].Cells["Column1"].Value.ToString();
                    int c = int.Parse(dataGridView1.Rows[counter].Cells["Column2"].Value.ToString());
                    sql = "INSERT INTO `products`  (`idLayout` ,`name`, `weight`)" +
                    "VALUE (" +
                    idLayout + ',' +
                    '"' + nameProduct + "\"," +
                    c + 
                    ")";
                    mycom = new MySqlCommand(sql, mycon);
                    mycom.ExecuteNonQuery();
                }

                mycon.Close();
                this.Refresh();
            }
            catch (InvalidCastException er)
            {
                MessageBox.Show("Нед подключения к серверу" + er.Message);
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

    }
}
