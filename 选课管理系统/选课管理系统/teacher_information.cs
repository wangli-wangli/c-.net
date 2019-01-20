using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;
using 选课管理系统.util;
using 选课管理系统.model;
using 选课管理系统.dao;
namespace 选课管理系统
{
    public partial class teacher_information : Form
    {
        public teacher_information()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox30_TextChanged(object sender, EventArgs e)
        {

        }

        private void teacher_information_Load(object sender, EventArgs e)
        {
            MySqlConnection conn = Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;

            try
            {
                command = conn.CreateCommand();
                command.CommandText = "select teacher_num,teacher_name,teacher_academy,profession,sex,office,id_number,zhuzhi,aihao,telephone from teacher where teacher_num=" + teacher_login.tnumber;
                dataReader = command.ExecuteReader();
                Console.WriteLine();

                while (dataReader.Read())
                {
                    textBox2.Text = dataReader.GetString(0);
                    textBox5.Text = dataReader.GetString(1);
                    textBox8.Text = dataReader.GetString(2);
                    textBox10.Text = dataReader.GetString(3);
                    textBox12.Text = dataReader.GetString(4);
                    textBox14.Text = dataReader.GetString(5);
                    textBox16.Text = dataReader.GetString(6);
                    textBox18.Text = dataReader.GetString(7);
                    textBox20.Text = dataReader.GetString(8);
                    textBox22.Text = dataReader.GetString(9);
       
                    label2.Text = dataReader.GetString(1);



                }
            }
            catch (Exception)
            {
            }
            finally
            {
                if (!dataReader.IsClosed)
                {
                    dataReader.Close();
                }
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            update_teacher t = new update_teacher();
            t.Show();

        }
    }
}
