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
using 选课管理系统.model;
using 选课管理系统.dao;


namespace 选课管理系统
{
    public partial class home : Form
    {
        private Timer Timer;//计时器
         
        public home()
        {
            InitializeComponent();
            panel3课表.Visible = false;
            panel3选课.Visible = false;
            panel成绩查询.Visible = false;
            panel3学籍.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void home_Load(object sender, EventArgs e)
        {

            Timer = new Timer();//显示当前时间
            Timer.Interval = 1000;
            Timer.Tick += new EventHandler(Timer_Tick);
            Timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.label2.Text = DateTime.Now.ToString("HH:mm:ss");
            this.label1.Text = DateTime.Now.ToString("yyyy-MM-dd");
            this.label3传参1.Text = DateTime.Now.ToString("yyyy");
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
           
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void 学生选课_Click(object sender, EventArgs e)
        {
           
          
        }

        private void 个人成绩查询_Click(object sender, EventArgs e)
        {
           
           
        }

        private void 评估课程_Click(object sender, EventArgs e)
        {
           
           
        }

        private void 本学期课表_Click(object sender, EventArgs e)
        {
            panel成绩查询.Visible = false;
            panel3选课.Visible = false;
            panel3学籍.Visible = false;
            panel3课表.Visible = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void 个人成绩查询_Click_1(object sender, EventArgs e)
        {
            panel3课表.Visible = false;
            panel3学籍.Visible = false;
            panel3选课.Visible = false;
            panel成绩查询.Visible = true;
        }

        private void button1成绩_Click(object sender, EventArgs e)
        {
            dao.resultDao dao = new dao.resultDao();
            dao.courseDao cdao = new dao.courseDao();
            dao.teacherDao tdao = new dao.teacherDao();
            List<model.Result> rs = new List<model.Result>();
            if (checkBox2成绩.Checked == false && checkBox1成绩.Checked == false)
            {
                rs = dao.selectAll(student_login.number, comboBox1成绩.Text, comboBox2成绩.Text);

                DataSet ds = new DataSet();
                DataTable dt = new DataTable("Table_New");


                dt.Columns.Add("代码", typeof(string));
                dt.Columns.Add("课程名称", typeof(string));
                dt.Columns.Add("性质", typeof(String));
                dt.Columns.Add("教师", typeof(string));
                dt.Columns.Add("学分", typeof(String));
                dt.Columns.Add("成绩", typeof(String));
                dt.Columns.Add("类型", typeof(String));
                dt.Columns.Add("学年", typeof(String));
                dt.Columns.Add("学期", typeof(String));
                foreach (model.Result r1 in rs)
                {
                    if (r1.Score != double.NaN)
                    {
                        model.Course c = new model.Course();
                        c = cdao.selectNum(r1.Course_num);
                        model.Teacher t = new model.Teacher();
                        t = tdao.selectNum(c.Teacher_num);


                        dt.Rows.Add(r1.Result_num, c.Course_name, c.Type, t.Teacher_name, c.Credit_hour, r1.Score, r1.Type, r1.Year, r1.Term);
                    }

                }
                dataGridView1成绩.DataSource = dt;
            }
            else if (checkBox1成绩.Checked == true && checkBox2成绩.Checked == false)
            {
                rs = dao.select1(student_login.number, comboBox1成绩.Text, comboBox2成绩.Text);

                DataSet ds = new DataSet();
                DataTable dt = new DataTable("Table_New");


                dt.Columns.Add("代码", typeof(string));
                dt.Columns.Add("课程名称", typeof(string));
                dt.Columns.Add("性质", typeof(String));
                dt.Columns.Add("教师", typeof(string));
                dt.Columns.Add("学分", typeof(String));
                dt.Columns.Add("成绩", typeof(String));
                dt.Columns.Add("类型", typeof(String));
                dt.Columns.Add("学年", typeof(String));
                dt.Columns.Add("学期", typeof(String));
                foreach (model.Result r1 in rs)
                {
                    if (r1.Score != double.NaN)
                    {
                        model.Course c = new model.Course();
                        c = cdao.selectNum(r1.Course_num);
                        model.Teacher t = new model.Teacher();
                        t = tdao.selectNum(c.Teacher_num);


                        dt.Rows.Add(r1.Result_num, c.Course_name, c.Type, t.Teacher_name, c.Credit_hour, r1.Score, r1.Type, r1.Year, r1.Term);
                    }

                }
                dataGridView1成绩.DataSource = dt;
            }
            else if (checkBox1成绩.Checked == false && checkBox2成绩.Checked == true)
            {
                rs = dao.select2(student_login.number, comboBox1成绩.Text, comboBox2成绩.Text);

                DataSet ds = new DataSet();
                DataTable dt = new DataTable("Table_New");


                dt.Columns.Add("代码", typeof(string));
                dt.Columns.Add("课程名称", typeof(string));
                dt.Columns.Add("性质", typeof(String));
                dt.Columns.Add("教师", typeof(string));
                dt.Columns.Add("学分", typeof(String));
                dt.Columns.Add("成绩", typeof(String));
                dt.Columns.Add("类型", typeof(String));
                dt.Columns.Add("学年", typeof(String));
                dt.Columns.Add("学期", typeof(String));
                foreach (model.Result r1 in rs)
                {
                    if (r1.Score != double.NaN)
                    {
                        model.Course c = new model.Course();
                        c = cdao.selectNum(r1.Course_num);
                        model.Teacher t = new model.Teacher();
                        t = tdao.selectNum(c.Teacher_num);


                        dt.Rows.Add(r1.Result_num, c.Course_name, c.Type, t.Teacher_name, c.Credit_hour, r1.Score, r1.Type, r1.Year, r1.Term);
                    }

                }
                dataGridView1成绩.DataSource = dt;
            }
            else if (checkBox1成绩.Checked == true && checkBox2成绩.Checked == true)
            {
                rs = dao.select3(student_login.number, comboBox1成绩.Text, comboBox2成绩.Text);

                DataSet ds = new DataSet();
                DataTable dt = new DataTable("Table_New");


                dt.Columns.Add("代码", typeof(string));
                dt.Columns.Add("课程名称", typeof(string));
                dt.Columns.Add("性质", typeof(String));
                dt.Columns.Add("教师", typeof(string));
                dt.Columns.Add("学分", typeof(String));
                dt.Columns.Add("成绩", typeof(String));
                dt.Columns.Add("类型", typeof(String));
                dt.Columns.Add("学年", typeof(String));
                dt.Columns.Add("学期", typeof(String));
                foreach (model.Result r1 in rs)
                {
                    if (r1.Score != double.NaN)
                    {
                        model.Course c = new model.Course();
                        c = cdao.selectNum(r1.Course_num);
                        model.Teacher t = new model.Teacher();
                        t = tdao.selectNum(c.Teacher_num);


                        dt.Rows.Add(r1.Result_num, c.Course_name, c.Type, t.Teacher_name, c.Credit_hour, r1.Score, r1.Type, r1.Year, r1.Term);
                    }

                }
                dataGridView1成绩.DataSource = dt;
            }
        }

        private void 学生选课_Click_1(object sender, EventArgs e)
        {
            panel成绩查询.Visible = false;
            panel3课表.Visible = false;
            panel3学籍.Visible = false;
            panel3选课.Visible = true;
            string str = util.Util.sqlcon;

            MySqlConnection conn = new MySqlConnection(str);
            string sql = "select student_academy,student_name from student where student_num='" + student_login.number + "'";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader thisread = cmd.ExecuteReader();
            thisread.Read();
            string temp1 = thisread.GetValue(0).ToString().Trim();
            string temp2 = thisread.GetValue(1).ToString().Trim();
            conn.Close();
            CourseSelection cs = new CourseSelection();
            cs.label2Text = temp1;
            cs.label6Text = temp2;
            cs.label8Text = label3传参1.Text;
            cs.label7Text = student_login.number;
            cs.FormBorderStyle = FormBorderStyle.None;
            cs.Dock = DockStyle.Fill;
            cs.TopLevel = false;
            panel3选课.Controls.Clear();
            panel3选课.Controls.Add(cs);
            cs.Show();
        }

        private void label3传参1_Click(object sender, EventArgs e)
        {

        }

        private void panel成绩查询_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1课表_Click(object sender, EventArgs e)
        {
            dao.resultDao dao = new dao.resultDao();
            dao.courseDao cdao = new dao.courseDao();
            dao.teacherDao tdao = new dao.teacherDao();
            List<model.Result> rs = new List<model.Result>();
            rs = dao.selectAll1(student_login.number, comboBox1课表.Text, comboBox2课表.Text);
            Console.WriteLine(comboBox1课表.Text);
            Console.WriteLine(comboBox2课表.Text);
           // DataSet ds = new DataSet();
            DataTable dt = new DataTable("Table_New");
            dt.Columns.Add("代码", typeof(string));
            dt.Columns.Add("课程编号", typeof(string));
            dt.Columns.Add("课程名称", typeof(string));
            dt.Columns.Add("教师", typeof(string));
            dt.Columns.Add("学分", typeof(string));
            dt.Columns.Add("类型", typeof(string));
            dt.Columns.Add("学年", typeof(string));
            dt.Columns.Add("学期", typeof(string));
            foreach (model.Result r1 in rs)
            {
                model.Course c = new model.Course();
                c = cdao.selectNum(r1.Course_num);
                model.Teacher t = new model.Teacher();
                t = tdao.selectNum(c.Teacher_num);
                Console.WriteLine(r1.Result_num);
                Console.WriteLine(c.Type);
                Console.WriteLine(c.Course_num);
                Console.WriteLine(c.Type);
                Console.WriteLine(r1.Year);
                Console.WriteLine(r1.Term);
                dt.Rows.Add(r1.Result_num, c.Course_num, c.Course_name, t.Teacher_name, c.Credit_hour, c.Type, r1.Year, r1.Term);
                
            }
            dataGridView1课表.DataSource = dt;

        }

        private void 学籍信息_Click(object sender, EventArgs e)
        {
            panel成绩查询.Visible = false;
            panel3课表.Visible = false;
            panel3选课.Visible = false;
            panel3学籍.Visible = true;
            student_information sAllPage = new student_information();

            sAllPage.FormBorderStyle = FormBorderStyle.None;
            sAllPage.Dock = DockStyle.Fill;
            sAllPage.TopLevel = false;
            panel3学籍.Controls.Clear();
            panel3学籍.Controls.Add(sAllPage);
            sAllPage.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            update_password u = new update_password();
            u.Show();
        }
    }
}
