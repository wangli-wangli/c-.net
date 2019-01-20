using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 选课管理系统.dao;
using 选课管理系统.model;




namespace 选课管理系统
{
    public partial class student_login : Form
    {
        string yan;
        public static string number;
        public student_login()
        {
            InitializeComponent();
            label2.Text = MakeCode();
            yan = label2.Text;
        }
        private static string MakeCode()
        {
            int codeLen = 4;
            if (codeLen < 1)
            {
                return string.Empty;
            }
            int number;
            StringBuilder sbCheckCode = new StringBuilder();
            Random random = new Random();

            for (int index = 0; index < codeLen; index++)
            {
                number = random.Next();

                if (number % 2 == 0)
                {
                    sbCheckCode.Append((char)('0' + (char)(number % 10))); //生成数字
                }
                else
                {
                    sbCheckCode.Append((char)('A' + (char)(number % 26))); //生成字母
                }
            }
            return sbCheckCode.ToString();
        }

        private void student_login_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = Name.Text;
            string password = Password.Text;
            string yan1 = Yan.Text;
            number = Name.Text;
            string password_sql = dao.studentDao.find_password(name);//调用其他类时，并且添加包名
            //password_sql从数据库中查询出来的password
            if (password != password_sql)
            {
                MessageBox.Show("密码错误！");
            }
            /**else if (yan1 != yan)
            {
                MessageBox.Show(yan+"  "+yan1);
                MessageBox.Show("验证码错误！");
            }**/
            else
            {
                Form home = new home();
                home.Show();
                this.Close();
                welcome w = new welcome();
                w.Close();

            }
        }

        private void Name_KeyPress(object sender, KeyPressEventArgs e)
        {
           if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void Yan_TextChanged(object sender, EventArgs e)
        {

        }

        private void Password_TextChanged(object sender, EventArgs e)
        {

        }

        private void Name_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            label2.Text = MakeCode();
        }
    }
}
