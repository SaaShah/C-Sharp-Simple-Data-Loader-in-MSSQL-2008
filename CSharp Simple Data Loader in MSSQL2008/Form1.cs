using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CSharp_Simple_Data_Loader_in_MSSQL2008
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            read_file("YOUR_PATH\\data.txt");

        }

        private void read_file(String path)
        {
            int counter = 0;
            string line;

            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {
                statusStrip1.Text = "Loading Data...";
                insert_data("TABLE NAME HERE", "COLUMN NAME 1", "COLUMN_NAME 2", line);//-----------------------CHANGE

                counter++;
            }
            statusStrip1.Text = "Number of Records inserted: " + Convert.ToInt32(counter-1).ToString();
            label1.Text = "Number of Records inserted: " + Convert.ToInt32(counter).ToString(); 
            file.Close();
            
        }

        #region Insert Operation
        private int insert_data(String table_name, String c1, String c2, String data)
        {

            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection._getcon();
                //command.CommandText = "INSERT INTO "+table_name+" ("+c1+", "+c2+") VALUES (@p1,@p2);";
                command.CommandText = "INSERT INTO " + table_name + " (" + c2 + ") VALUES (@p2);";
                //command.Parameters.AddWithValue("@p1", "7"); // column value 1 here --------------------------------------CHANGE
                command.Parameters.AddWithValue("@p2", data); // column value 2 here

                int _flag = command.ExecuteNonQuery();
                command.Connection.Close();
                return _flag;

            }
            catch (SqlException e)
            {
                return 0;
            }

        }
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


    }
}
