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
    public partial class select_teacher : Form
    {
        public DataGridView data = new DataGridView();
        public static string t_num;//老师工号
        public select_teacher()
        {
            InitializeComponent();
        }

        private void select_teacher_Load(object sender, EventArgs e)
        {
            
            List<model.Teacher> ts = dao.teacherDao.find_teachers();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable("Table_New");

            dt.Columns.Add("工号", typeof(string));
            dt.Columns.Add("姓名", typeof(string));
            dt.Columns.Add("学院", typeof(string));
            dt.Columns.Add("专业", typeof(string));
           
            int i = 0;
            foreach (model.Teacher s1 in ts)
            {

                dt.Rows.Add(s1.Teacher_num, s1.Teacher_name, s1.Teacher_academy, s1.Profession);
                t_num = s1.Teacher_num + " " + s1.Teacher_name;
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

        private void button1_Click(object sender, EventArgs e)
        {
            model.Teacher t1 = new model.Teacher();
            t1.Teacher_num = textBox2.Text;
            t1.Teacher_name = textBox1.Text;
            t1.Teacher_academy = textBox3.Text;
            t1.Profession = textBox4.Text;
            List<model.Teacher> rs;
            if (t1.Teacher_num != "" || t1.Teacher_name != "" || t1.Teacher_academy != "" || t1.Profession != "")
            {
                 rs = dao.teacherDao.find_teachers2(t1);
            }
            else
            {
               rs = dao.teacherDao.find_teachers();
            }
           
            Console.Write(rs);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable("Table_New");
            dt.Columns.Add("工号", typeof(string));
            dt.Columns.Add("姓名", typeof(string));
            dt.Columns.Add("学院", typeof(string));
            dt.Columns.Add("专业", typeof(string));
           
            int i = 0;
            foreach (model.Teacher s1 in rs)
            {

                dt.Rows.Add(s1.Teacher_num, s1.Teacher_name, s1.Teacher_academy, s1.Profession);
                i++;
            }
            dataGridView1.DataSource = dt;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x = 0;
            int xuanzhong = 0;//选中的个数
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                x++;

                if (Convert.ToBoolean(this.dataGridView1.Rows[i].Cells[0].Value) == true)
                {
                    xuanzhong++;

                    {
                        admin_home.teacher_num = dataGridView1.Rows[i].Cells[1].Value.ToString();
                        t_num = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    }
                }

                
            }
            if (xuanzhong > 1)
            {
                MessageBox.Show("只能选择一个老师！");
            }else  if (xuanzhong == 1)
            {
                if (x == dataGridView1.Rows.Count)
                {
                    this.Close();
                }
            }
        }
    }
}
