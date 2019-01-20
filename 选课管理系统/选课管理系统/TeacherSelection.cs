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

namespace 选课管理系统
{
    public partial class TeacherSelection : Form
    {
        public TeacherSelection()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
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

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            string str = util.Util.sqlcon;
            String sql = "";
            string tmp1 = toolStripComboBox1.Text;
            string tmp2 = toolStripTextBox1.Text;
            MySqlConnection conn = new MySqlConnection(str);
            if (tmp1 == "课程名称")
                sql = "select course_num,course_name,credit_hour,type,address,time_week,time_jie,academy from course where course_name='" + tmp2 + "' and academy='" + label2.Text + "' ";
            if (tmp1 == "课程类型")
                sql = "select course_num,course_name,credit_hour,type,address,time_week,time_jie,academy from course where type='" + tmp2 + "'and academy='" + label2.Text + "'  ";
            if ((tmp1 != "商品名称") && (tmp1 != "课程类型"))
                MessageBox.Show("输入有误");
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "course");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "course";
            conn.Close();
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            string str = util.Util.sqlcon;
            MySqlConnection conn = new MySqlConnection(str);
            string sql = "select course_num,course_name,credit_hour,type,address,time_week,time_jie,academy  from course where academy='" + label2.Text + "'";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "course");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "course";
            conn.Close();
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
                    string sql = "update result set teacher_num='" + teacher_login.tnumber + "' where course_num='" + cNum + "'";
                    //string sql = "insert into result(teacher_num,course_num) values('" + teacher_login.tnumber + "','" + cNum + "')";
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "course");
                    conn.Close();
                    MessageBox.Show(cNum + "添加成功");
                }
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
        public string label9Text
        {
            set
            {
                this.label9.Text = value;
            }

            get { return this.label9.Text; }

        }
    }
}
