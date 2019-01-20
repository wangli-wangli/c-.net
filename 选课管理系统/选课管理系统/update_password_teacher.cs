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
    public partial class update_password_teacher : Form
    {
        public update_password_teacher()
        {
            InitializeComponent();
        }

        private void update_password_teacher_Load(object sender, EventArgs e)
        {
            label7.Hide();
            label9.Hide();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label7.Hide();
            label9.Hide();
            MySqlConnection conn = Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;

            try
            {
                command = conn.CreateCommand();
                command.CommandText = "select answer,password from teacher where teacher_num=" + teacher_login.tnumber;
                dataReader = command.ExecuteReader();
                Console.WriteLine();

                while (dataReader.Read())
                {
                    label7.Text = dataReader.GetString(0);
                    label9.Text = dataReader.GetString(1);
                    if(text15.Text=="")
                    {
                        MessageBox.Show("请输入原始密码！");
                    }
                    else if (text17.Text == "")
                    {
                        MessageBox.Show("请输入新密码！");
                    }
                    else if (textBox1.Text == "")
                    {
                        MessageBox.Show("请再次输入新密码！");
                    }
         
                    else if(text15.Text!=label9.Text)
                    {
                        MessageBox.Show("原始密码不正确！");
                    }
                    else if(text17.Text!=textBox1.Text)
                    {
                        MessageBox.Show("两次密码不一致！");
                    }
                    else
                    {

                        dataReader.Close();
                        string sql1 = "update teacher set password='" + text17.Text +  "' where teacher_num='" +
                        student_login.number + "'";
                        Console.Write("已修改!");
                        command.CommandText = sql1;
                        command.ExecuteNonQuery();
                        Console.WriteLine();
                        MessageBox.Show("已修改密码！");
                        this.Close();

                    }


                }
            }
            catch (Exception)
            {
                Console.WriteLine("操作错误！");
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
