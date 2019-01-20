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
using 选课管理系统.util;
namespace 选课管理系统
{
    public partial class update_student : Form
    {
        public update_student()
        {
            InitializeComponent();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void update_student_Load(object sender, EventArgs e)
        {
            MySqlConnection conn = Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;

            try
            {
                command = conn.CreateCommand();
                command.CommandText = "select student_num,student_name from student where student_num=" + student_login.number;
                dataReader = command.ExecuteReader();
                Console.WriteLine();

                while (dataReader.Read())
                {
                    text11.Text = dataReader.GetString(0);
                    text12.Text = dataReader.GetString(1);


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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            MySqlConnection conn = Util.getConn();
            MySqlCommand command = null;
            try
            {
                if(text13.Text=="")
                {
                    MessageBox.Show("爱好不能为空！");
                }
                else if(text14.Text=="")
                {
                    MessageBox.Show("电话不能为空！");
                }
                else if (text15.Text == "")
                {
                    MessageBox.Show("体重不能为空！");
                }
                else if (text16.Text == "")
                {
                    MessageBox.Show("特长不能为空！");
                }
                else if (text17.Text == "")
                {
                    MessageBox.Show("宿舍号不能为空！");
                }
                else if (textBox1.Text == "")
                {
                    MessageBox.Show("身高不能为空！");
                }
                else if (text18.Text == "")
                {
                    MessageBox.Show("住址不能为空！");
                }
                else if (text19.Text == "")
                {
                    MessageBox.Show("母亲电话不能为空！");
                }
                else if (text20.Text == "")
                {
                    MessageBox.Show("父亲电话不能为空！");
                }
                else
                {
                    command = conn.CreateCommand();
                    string sql = "update student set aihao='" + text13.Text + "',telephone='" +
                        text14.Text + "',tizhong='" + text15.Text + "',techang='" +
                        text16.Text + "',sushe='" + text17.Text + "',shengao='" + textBox1.Text
                   + "',zhuzhi='" +
                    text18.Text + "',m_telephone='" + text19.Text + "',f_telephone='" + text20.Text + "' where student_num='" +
                    student_login.number + "'";


                    Console.Write("sql:" + sql);
                    command.CommandText = sql;

                    command.ExecuteNonQuery();
                    Console.WriteLine();
                    MessageBox.Show("已修改，请刷新页面！");
                    this.Close();
                }

            }
            catch (Exception)
            {
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
