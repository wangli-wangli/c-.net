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
    public partial class teacher_home : Form
    {
        private Timer Timer;//计时器
        public teacher_home()
        {
            InitializeComponent();
            panel7选课.Visible = false;
            panel7.Visible = false;
            panel7成绩.Visible = false;
            panel3课表.Visible = false;
            panel7个人.Visible = false;
        }

        private void 个人信息_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }
        private void teacher_home_Load(object sender, EventArgs e)
        {
            Timer = new Timer();//显示当前时间
            Timer.Interval = 1000;
            Timer.Tick += new EventHandler(Timer_Tick);
            Timer.Start();
            panel7成绩.Visible = false;
            dao.resultDao rdao = new dao.resultDao();
            dao.courseDao cdao = new dao.courseDao();
            List<model.Course> cs = new List<model.Course>();
            cs = cdao.selecttc(teacher_login.tnumber);
            foreach (model.Course r1 in cs)
            {
                model.Course c = new model.Course();
                c = cdao.selectNum(r1.Course_num);
                //Console.WriteLine(c.Course_num + " " + c.Course_name + c.Time_week + c.Time_jie);
                comboBox1成绩.Items.Add(c.Course_num + " " + c.Course_name + c.Time_week + c.Time_jie);
            }
            
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            this.label2.Text = DateTime.Now.ToString("HH:mm:ss");
            this.label1.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void 评估课程_Click(object sender, EventArgs e)
        {
            panel7选课.Visible = false;
            panel7成绩.Visible = false;
            panel3课表.Visible = false;
            panel课表.Visible = false;
            panel7个人.Visible = false;
            panel7.Visible = true;
        }

        private void 个人成绩查询_Click(object sender, EventArgs e)
        {
            panel7选课.Visible = false;
            panel7.Visible = false;
            panel3课表.Visible = false;
            panel课表.Visible = false;
            panel7个人.Visible = false;
            panel7成绩.Visible = true;
        }

        private void 学生选课_Click(object sender, EventArgs e)
        {
            panel7.Visible = false;
            panel7成绩.Visible = false;
            panel3课表.Visible = false;
            panel课表.Visible = false;
            panel7个人.Visible = false;
            panel7选课.Visible = true;
            string str = util.Util.sqlcon;

            MySqlConnection conn = new MySqlConnection(str);
            string sql = "select teacher_name,teacher_academy from teacher where teacher_num='" + teacher_login.tnumber + "'";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader thisread = cmd.ExecuteReader();
            Console.WriteLine("sql:" + sql);
            thisread.Read();
            string temp1 = thisread.GetValue(0).ToString().Trim();
            string temp2 = thisread.GetValue(1).ToString().Trim();
            conn.Close();
            TeacherSelection ts = new TeacherSelection();
            ts.label6Text = temp1;
            ts.label2Text = temp2;
            ts.label9Text = label3.Text;
            ts.label7Text = teacher_login.tnumber;
            ts.FormBorderStyle = FormBorderStyle.None;
            ts.Dock = DockStyle.Fill;
            ts.TopLevel = false;
            panel7选课.Controls.Clear();
            panel7选课.Controls.Add(ts);
            ts.Show();
        }

        private void 本学期课表_Click(object sender, EventArgs e)
        {
            panel7.Visible = false;
            panel7成绩.Visible = false;
            panel7选课.Visible = false;
            panel3课表.Visible = false;
                 panel7个人.Visible = false;
            panel课表.Visible = true;
        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void 学籍信息_Click(object sender, EventArgs e)
        {
            panel7.Visible = false;
            panel7成绩.Visible = false;
            panel7选课.Visible = false;
            panel3课表.Visible = false;
            panel课表.Visible = false;
            panel7个人.Visible = true;
            teacher_information sAllPage = new teacher_information();
            sAllPage.FormBorderStyle = FormBorderStyle.None;
            sAllPage.Dock = DockStyle.Fill;
            sAllPage.TopLevel = false;
            panel7个人.Controls.Clear();
            panel7个人.Controls.Add(sAllPage);
            sAllPage.Show();
        }

        private void search_Click(object sender, EventArgs e)
        {
            dao.resultDao dao = new dao.resultDao();
            dao.studentDao sdao = new dao.studentDao();
            List<model.Result> rs = new List<model.Result>();

            rs = dao.selectStudent(textBox1.Text, comboBox1.Text, comboBox2.Text);//学生编号s
            List<model.Student> s = new List<model.Student>();


            s = sdao.selectStudent(rs);//根据学生编号s查询出所有的学生信息

            DataSet ds = new DataSet();
            DataTable dt = new DataTable("Table_New");
            dt.Columns.Add("姓名", typeof(string));
            dt.Columns.Add("学号", typeof(string));
            dt.Columns.Add("性别", typeof(String));
            dt.Columns.Add("学院", typeof(string));
            dt.Columns.Add("专业", typeof(String));
            dt.Columns.Add("年级", typeof(String));
            dt.Columns.Add("班级", typeof(String));
            foreach (model.Student a in s)
            {

                dt.Rows.Add(a.Student_name, a.Id_number, a.Sex, a.Student_academy, a.Profession, a.Student_grade, a.Classs);

            }
            dataGridView1.DataSource = dt;
            
        }

        //录入成绩
        private void button1成绩_Click(object sender, EventArgs e)
        {
            string course = comboBox1成绩.Text;
            if (course == "")
            {
                MessageBox.Show("请选择需要录入的课程！");
            }
            else
            {
                dataGridView1成绩.Rows.Clear();
                //coursedao cdao = new coursedao();
                string[] c = course.Split(' ');
                string cour = c[0];
                dao.resultDao rdao = new dao.resultDao();
                List<model.Result> rs = new List<model.Result>();
               
                rs = rdao.selectResult(cour);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable("Table_New");
                dao.studentDao sdao = new dao.studentDao();
                Console.WriteLine("姚雅丽");
                dt.Columns.Add("学号", typeof(string));
                dt.Columns.Add("姓名", typeof(string));
                dt.Columns.Add("性别", typeof(string));

                dt.Columns.Add("类型", typeof(string));
                dt.Columns.Add("成绩", typeof(string));
                foreach (DataGridViewColumn co in dataGridView1成绩.Columns)
                {
                    if (co.Index != 4 && co.Index != 3)
                        co.ReadOnly = true;
                }
                foreach (model.Result r in rs)
                {
                        model.Student s = new model.Student();
                        s = sdao.selectNum(r.Student_num);
                        dataGridView1成绩.Rows.Add(r.Student_num, s.Student_name, s.Sex, "", "");
                   
                }
            }
        }

        private void button2成绩_Click(object sender, EventArgs e)
        {

        }

        private void button3成绩_Click(object sender, EventArgs e)
        {
            MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show("是否确认提交？", "提交", messButton);
            if (dr == DialogResult.OK)
            {
                string course = comboBox1成绩.Text;
                dao.resultDao rdao = new dao.resultDao();
                string[] c = course.Split(' ');
                string cour = c[0];
                bool b = true;
                for (int i = 0; i < dataGridView1成绩.Rows.Count ; i++)
                {
                    try
                    {
                        rdao.updateScore(dataGridView1成绩.Rows[i].Cells[0].Value.ToString(), cour, dataGridView1成绩.Rows[i].Cells[3].Value.ToString(), Convert.ToDouble(dataGridView1成绩.Rows[i].Cells[4].Value));

                    }
                    catch (SystemException)
                    {
                        MessageBox.Show("格式错误！");
                        b = false;
                    }
                }
                if (b == true)
                {
                    MessageBox.Show("提交成功");
                }
                
            }
            else
            {

            }
            
        }

        private void button1课表_Click(object sender, EventArgs e)
        {
            //dao.resultDao dao = new dao.resultDao();
            //dao.courseDao cdao = new dao.courseDao();
            //dao.teacherDao tdao = new dao.teacherDao();
            //List<model.Result> rs = new List<model.Result>();
            //rs = dao.selectAll2(comboBox1课表.Text, comboBox2课表.Text);
            //Console.WriteLine(comboBox1课表.Text);
            //Console.WriteLine(comboBox2课表.Text);
            //DataSet ds = new DataSet();
            //DataTable dt = new DataTable("Table_New");
            //dt.Columns.Add("代码", typeof(string));
            //dt.Columns.Add("课程编号", typeof(string));
            //dt.Columns.Add("课程名称", typeof(string));
           
            //dt.Columns.Add("教师", typeof(string));
            //dt.Columns.Add("学分", typeof(string));
            //dt.Columns.Add("类型", typeof(string));
            //dt.Columns.Add("学年", typeof(string));
            //dt.Columns.Add("学期", typeof(string));
            //foreach (model.Result r1 in rs)
            //{
              //  model.Course c = new model.Course();
                //c = cdao.selectNum(r1.Course_num);
                //model.Teacher t = new model.Teacher();
               // t = tdao.selectNum(r1.Teacher_num);
                /**Console.WriteLine("1:" + r1.Result_num);
                Console.WriteLine("2:" + c.Course_num);
                Console.WriteLine("3:" +  c.Course_name);
                Console.WriteLine("4:" + c.Type);
                Console.WriteLine("5:" + t.Teacher_name);
                Console.WriteLine("6:" + c.Credit_hour);
                Console.WriteLine("7:" + r1.Type);**/
                //dt.Rows.Add(r1.Result_num, c.Course_num, c.Course_name,  t.Teacher_name, c.Credit_hour, c.Type, r1.Year, r1.Term);
            //}
            //dataGridView1课表.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dao.resultDao dao = new dao.resultDao();
            dao.courseDao cdao = new dao.courseDao();
            dao.teacherDao tdao = new dao.teacherDao();
            List<model.Course> rs = new List<model.Course>();
            rs = cdao.selectNum1(teacher_login.tnumber);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable("Table_New");
            dt.Columns.Add("课程编号", typeof(string));
            dt.Columns.Add("课程名称", typeof(string));
            dt.Columns.Add("教师", typeof(string));
            dt.Columns.Add("上课地点", typeof(string));
            dt.Columns.Add("时间", typeof(string));
            dt.Columns.Add("课时", typeof(string));
            dt.Columns.Add("学分", typeof(string));
            dt.Columns.Add("类型", typeof(string));
            foreach (model.Course r1 in rs)
            {
                model.Teacher t = new model.Teacher();
                t = tdao.selectNum2(teacher_login.tnumber);
                Console.WriteLine("2:" + r1.Course_num);
                Console.WriteLine("3:" + r1.Course_name);
                Console.WriteLine("4:" + r1.Type);
                Console.WriteLine("5:" + t.Teacher_name);
                Console.WriteLine("6:" + r1.Credit_hour);
                Console.WriteLine("7:" + r1.Type);
                dt.Rows.Add(r1.Course_num, r1.Course_name, t.Teacher_name,r1.Address,r1.Time_week,r1.Time_jie, r1.Credit_hour, r1.Type);
            }
            dataGridView2.DataSource = dt;
        }

        private void button1修改密码_Click(object sender, EventArgs e)
        {
            panel7选课.Visible = false;
            panel7.Visible = false;
            panel7成绩.Visible = false;
            panel3课表.Visible = false;
            panel7个人.Visible = false;
            update_password_teacher t = new update_password_teacher();
            t.Show();
        }

        private void panel7成绩_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
