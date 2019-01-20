using System;
using System.Collections.Generic;
using System.ComponentModel;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 选课管理系统.util;
namespace 选课管理系统
{
    public partial class student_information : Form
    {
        public student_information()
        {
            InitializeComponent();
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        public string label1Textdis
        {
            set
            {
                this.label1.Text = value;
            }

            get { return label1.Text; }

        }

        private void student_information_Load(object sender, EventArgs e)
        {
           
          
            MySqlConnection conn = Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
        
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "select student_num,student_name,student_academy,student_grade,sex,profession,id_number,classs,telephone,sushe,zhuzhi,shengao,tizhong,aihao,techang,m_telephone,f_telephone from student where student_num=" + student_login.number;
                dataReader = command.ExecuteReader();
                Console.WriteLine();

                while (dataReader.Read())
                {
                    textBox2.Text= dataReader.GetString(0);
                    textBox5.Text = dataReader.GetString(1);
                    textBox12.Text = dataReader.GetString(2);
                    textBox10.Text = dataReader.GetString(3);
                    textBox16.Text = dataReader.GetString(4);
                    textBox14.Text = dataReader.GetString(5);
                    textBox18.Text = dataReader.GetString(6);
                    textBox8.Text = dataReader.GetString(7);
                    textBox20.Text = dataReader.GetString(8);
                    textBox22.Text = dataReader.GetString(9);
                    textBox24.Text = dataReader.GetString(10);
                    textBox26.Text = dataReader.GetString(11);
                    textBox28.Text = dataReader.GetString(12);
                    textBox30.Text = dataReader.GetString(13);
                    textBox32.Text = dataReader.GetString(14);
                    textBox34.Text = dataReader.GetString(15);
                    textBox36.Text = dataReader.GetString(16);
                    label3.Text = dataReader.GetString(1);
            
            

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

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
           

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox43_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }
      

        private void label3_Click(object sender, EventArgs e)
        {
           
           
        }
       

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.Text = this.label1Textdis;
            label1.Visible = false;
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            update_student u = new update_student();
            u.Show();
            
        }


    }
}
