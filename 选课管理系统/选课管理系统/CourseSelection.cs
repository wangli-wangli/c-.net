using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace 选课管理系统
{
    public partial class CourseSelection : Form
    {
        public CourseSelection()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewColumn column = dataGridView1.Columns[e.ColumnIndex];
                if (column is DataGridViewButtonColumn)
                {

                    string str = util.Util.sqlcon;
                    MySqlConnection conn = new MySqlConnection(str);
                    int r = this.dataGridView1.CurrentRow.Index;
                    string cNum = this.dataGridView1.Rows[r].Cells[1].Value.ToString();
                    conn.Open();
                    MySqlCommand mycmd = new MySqlCommand("select * from result where student_num='" + student_login.number + "' and course_num='" + cNum + "' ", conn);
                    MySqlDataReader mysdr = mycmd.ExecuteReader();

                    if (mysdr.HasRows)
                    {

                        MessageBox.Show("已添加过课程" + cNum);
                        conn.Close();

                    }
                    else
                    {
                        conn.Close();
                        DialogResult result = MessageBox.Show("确定添加课程" + cNum + "吗?", "添加", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            string sql = "insert into result(student_num,course_num,year,term,state) values('" + student_login.number + "','" + cNum + "','" + label8.Text + "','春','待审核')";
                            conn.Open();
                            MySqlCommand cmd = new MySqlCommand(sql, conn);
                            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                            DataSet ds = new DataSet();
                            da.Fill(ds, "course");
                            conn.Close();
                            MessageBox.Show(cNum + "添加成功");
                        }
                        else { return; }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = util.Util.sqlcon;
            MySqlConnection conn = new MySqlConnection(str);
            string sql = "select course_num,course_name,credit_hour,type,address,time_week,time_jie,academy  from course where academy=(select student_academy from student where student_num='" + student_login.number + "')";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "course");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "course";
            conn.Close();
        }
      

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void CourseSelection_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        

        private void label7_Click(object sender, EventArgs e)
        {

        }
        public string label7Text
        {
            set
            {
                this.label7.Text = value;
            }

            get { return this.label7.Text; }

        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel2_Click_1(object sender, EventArgs e)
        {
            string str = util.Util.sqlcon;
            MySqlConnection conn = new MySqlConnection(str);
            string sql = "select course_num,course_name,(select teacher_name from teacher where teacher_num=course.teacher_num) as teacher_name,credit_hour,type,address,time_week,time_jie,academy,maxcount,(select count(*) from result where course_num=course.Course_num) as number  from course where type='任选' or (type='限选' and academy='" + label2.Text + "')";
            
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "course");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "course";
            conn.Close();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            string str = util.Util.sqlcon;
            String sql = "";
            string tmp1 = toolStripComboBox1.Text;
            string tmp2 = toolStripTextBox1.Text;
            MySqlConnection conn = new MySqlConnection(str);
            if (tmp1 == "课程名称")
                sql = "select course_num,course_name,(select teacher_name from teacher where teacher_num=course.teacher_num) as teacher_name ,credit_hour,type,address,time_week,time_jie,academy,maxcount,(select count(*) from result where course_num=course.Course_num) as number from course where course_name='" + tmp2 + "' and (type='任选' or (type='限选' and academy='" + label2.Text + "') )";
            else if (tmp1 == "课程类型")
            {
                if (tmp2 == "限选")
                    sql = "select course_num,course_name,(select teacher_name from teacher where teacher_num=course.teacher_num) as teacher_name ,credit_hour,type,address,time_week,time_jie,academy,maxcount,(select count(*) from result where course_num=course.Course_num) as number from course where type='" + tmp2 + "'and academy='" + label2.Text + "'";
                else
                    sql = "select course_num,course_name,(select teacher_name from teacher where teacher_num=course.teacher_num) as teacher_name ,credit_hour,type,address,time_week,time_jie,academy,maxcount,(select count(*) from result where course_num=course.Course_num) as number from course where type='任选'";

            }
            else if (tmp1 == "学院")
            {
                if (tmp2 == label2.Text)
                    sql = "select course_num,course_name,(select teacher_name from teacher where teacher_num=course.teacher_num) as teacher_name ,credit_hour,type,address,time_week,time_jie,academy,maxcount,(select count(*) from result where course_num=course.Course_num) as number from course where academy='" + tmp2 + "' and type!='必修'";
                else
                    sql = "select course_num,course_name,(select teacher_name from teacher where teacher_num=course.teacher_num) as teacher_name ,credit_hour,type,address,time_week,time_jie,academy,maxcount,(select count(*) from result where course_num=course.Course_num) as number from course where academy='" + tmp2 + "' and type='任选' ";
            }
            else
            {
                sql = "select course_num,course_name,(select teacher_name from teacher where teacher_num=course.teacher_num) as teacher_name,credit_hour,type,address,time_week,time_jie,academy,maxcount,(select count(*) from result where course_num=course.Course_num) as number  from course where type='任选' or (type='限选' and academy='" + label2.Text + "')";
                MessageBox.Show("输入有误");
            }
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "course");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "course";
            conn.Close();
        }

        private void toolStripTextBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        public string label2Text
        {
            set
            {
                this.label2.Text = value;
            }

            get { return this.label2.Text; }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }
        public string label6Text
        {
            set
            {
                this.label6.Text = value;
            }

            get { return this.label6.Text; }

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
        public string label8Text
        {
            set
            {
                this.label8.Text = value;
            }

            get { return this.label8.Text; }

        }
      
    }
}
