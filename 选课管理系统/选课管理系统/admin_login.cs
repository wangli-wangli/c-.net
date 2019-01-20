using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 选课管理系统
{
    public partial class admin_login : Form
    {
        string yan;
        public admin_login()
        {
            InitializeComponent();
            label2.Text = MakeCode();
            yan = label2.Text;
        }
        /// 生成验证码字符串
        /// </summary>
        /// <param name="codeLen">验证码字符长度</param>
        /// <returns>返回验证码字符串</returns>
        private static string MakeCode()
        {
            int codeLen = 5;
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

        private void button1_Click(object sender, EventArgs e)
        {
            string name = admin_Name.Text;
            string password = admin_Password.Text;
            string yan1 = admin_Yan.Text;

            string password_sql = dao.teacherDao.find_password2(name);//调用其他类时，并且添加包名
            //password_sql从数据库中查询出来的password
            if (password != password_sql)
            {
                MessageBox.Show("密码错误！");
            }
            /**else if (yan1 != yan)
            {
                MessageBox.Show(yan1+"  "+yan);
                MessageBox.Show("验证码错误！");
            }**/
            else
            {
                Form home = new admin_home();
                home.Show();
                this.Close();
                welcome w = new welcome();
                w.Close();

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            label2.Text = MakeCode();

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void admin_login_Load(object sender, EventArgs e)
        {

        }
    }
}
