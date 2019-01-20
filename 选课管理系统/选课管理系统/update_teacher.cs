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
    public partial class update_teacher : Form
    {
        public update_teacher()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void update_teacher_Load(object sender, EventArgs e)
        {
            MySqlConnection conn = Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;

            try
            {
                command = conn.CreateCommand();
                command.CommandText = "select teacher_num,teacher_name,teacher_academy,profession,sex from teacher where teacher_num=" + teacher_login.tnumber;
                dataReader = command.ExecuteReader();
                Console.WriteLine();

                while (dataReader.Read())
                {
                    text11.Text = dataReader.GetString(0);
                    text12.Text = dataReader.GetString(1);
                    text13.Text = dataReader.GetString(2);
                    text14.Text = dataReader.GetString(3);
                    text15.Text = dataReader.GetString(4);


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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = Util.getConn();
            MySqlCommand command = null;
            try
            {
                if (text16.Text == "")
                {
                    MessageBox.Show("办公室不能为空！");
                }
                else if (text17.Text == "")
                {
                    MessageBox.Show("电话不能为空！");
                }
                else if (textBox1.Text == "")
                {
                    MessageBox.Show("爱好不能为空！");
                }
                else if (text18.Text == "")
                {
                    MessageBox.Show("家庭住址不能为空！");
                }
      
                else
                {
                    command = conn.CreateCommand();
                    string sql = "update teacher set aihao='" + textBox1.Text + "',telephone='" +
                        text17.Text + "',office='" + text16.Text + "',zhuzhi='" +
                        text18.Text +  "' where teacher_num='" +
                    teacher_login.tnumber + "'";


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
    }
}
