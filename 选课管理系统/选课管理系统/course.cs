using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 选课管理系统.util;
using 选课管理系统.dao;
using 选课管理系统.model;
namespace 选课管理系统
{
    public partial class course : Form
    {
        public course()
        {
            InitializeComponent();
        }
        public DataGridView data = new DataGridView();
        public shenhe SH;
        private void course_Load(object sender, EventArgs e)
        {
            shenheDao s = new shenheDao();
            List<Course> ss = new List<Course>();
            ss = s.find_courses();
            Console.Write(ss);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable("Table_New");

            dt.Columns.Add("课程号", typeof(string));
            dt.Columns.Add("课程名称", typeof(string));
            dt.Columns.Add("课程类型", typeof(string));
            dt.Columns.Add("所属学院", typeof(string));

            int i = 0;
            foreach (Course s1 in ss)
            {

                dt.Rows.Add(s1.Course_num, s1.Course_name, s1.Type, s1.Academy);
                i++;
            }
            dataGridView1.DataSource = dt;
            foreach (DataGridViewColumn co in dataGridView1.Columns)
            {
                if (co.Index != 0)
                    co.ReadOnly = true;
            }
            data = dataGridView1;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = this.dataGridView1.CurrentRow.Index;
            SH.toolStripComboBox1.Text = data.Rows[r].Cells[2].Value.ToString();
            this.Close();
                   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            shenheDao s = new shenheDao();
            Course c = new Course();
            c = s.find_course(textBox1.Text);
            DataTable dt = new DataTable("Table_New");

            dt.Columns.Add("课程号", typeof(string));
            dt.Columns.Add("课程名称", typeof(string));
            dt.Columns.Add("课程类型", typeof(string));
            dt.Columns.Add("所属学院", typeof(string));
            dt.Rows.Add(c.Course_num, c.Course_name, c.Type, c.Academy);
            dataGridView1.DataSource = dt;
        }
    }
}
