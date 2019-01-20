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
using 选课管理系统.util;
using 选课管理系统.model;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
namespace 选课管理系统
{
    public partial class shenhe : Form
    {
        public shenhe()
        {
            InitializeComponent();
        }
        public int num = 0;
        private void shenhe_Load(object sender, EventArgs e)
        {

        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

          

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

            Console.Write("!!!!!!!!!!!!!!!!!!!!!!!!!");
            string tmp1 = toolStripComboBox1.Text;
           
            dao.shenheDao s = new shenheDao();
            model.Course c = new Course();
            c = s.find_course(tmp1);
            Console.Write("lalalal"+c.Course_num);
           
            List<model.Result> l = new List<model.Result>();
            num= s.selectAll2(c.Course_num);
            
            Console.Write(num + "555555555555555555555");
            List<model.Result> rs = new List<model.Result>();
            rs = s.selectAll1(c.Course_num);
            Console.WriteLine(c.Course_num+"33333333333333333333333333");
           
            DataTable dt = new DataTable("Table_New");
            dt.Columns.Add("审核编码", typeof(string));
            dt.Columns.Add("课程编号", typeof(string));
            dt.Columns.Add("课程名称", typeof(string));
            dt.Columns.Add("学生学号", typeof(string));
            dt.Columns.Add("学生姓名", typeof(string));
            dt.Columns.Add("最大人数", typeof(int));
            dt.Columns.Add("状态", typeof(string));
            foreach (model.Result r1 in rs)
            {
                model.Student d = new model.Student();
                Console.Write(r1.Student_num + "111111111111111111");
                d=s.find_student(r1.Student_num);
                Console.Write("1111111111111111111");
               
                
                    dt.Rows.Add(r1.Result_num,r1.Course_num,tmp1, d.Student_num, d.Student_name,c.Maxcount,r1.State);
                
               
               

            }
            dataGridView1.DataSource = dt;
        }

        private void toolStrip1_ItemClicked(object sender, System.Windows.Forms.ToolStripItemClickedEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                int i = e.RowIndex;
                MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
                String number=Convert.ToString(dataGridView1.Rows[i].Cells[1].Value);
                int n = Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value);
                Console.Write(number);
                DialogResult dr = MessageBox.Show("审核是否通过？", "提交", messButton);
                if (dr == DialogResult.OK)
                {
                    if(num<n)
                    {
                        dataGridView1.Rows[i].Cells[7].Value = "审核已通过";
                        shenheDao.update(number, "审核已通过");
                        num++;
                    }
                    else
                    {
                        MessageBox.Show("通过人数已达上限！");
                    }
                   
                
                }
                else
                {
                    dataGridView1.Rows[i].Cells[7].Value = "审核未通过";
                    shenheDao.update(number,"审核未通过");
                }
                
            }
        }

        private void dtjwddkkehd(object sender, System.Windows.Forms.DataGridViewCellCancelEventArgs e)
        {
            Console.Write("!!!!!!!!!!!!!!!!!!!!!!!!!");
            string tmp1 = toolStripComboBox1.Text;

            dao.shenheDao s = new shenheDao();
            model.Course c = new Course();
            c = s.find_course(tmp1);
            Console.Write("lalalal" + c.Course_num);

            List<model.Result> l = new List<model.Result>();
            num = s.selectAll2(c.Course_num);

            Console.Write(num + "555555555555555555555");
            List<model.Result> rs = new List<model.Result>();
            rs = s.selectAll1(c.Course_num);
            Console.WriteLine(c.Course_num + "33333333333333333333333333");

            DataTable dt = new DataTable("Table_New");
            dt.Columns.Add("审核编码", typeof(string));
            dt.Columns.Add("课程编号", typeof(string));
            dt.Columns.Add("课程名称", typeof(string));
            dt.Columns.Add("学生学号", typeof(string));
            dt.Columns.Add("学生姓名", typeof(string));
            dt.Columns.Add("最大人数", typeof(int));
            dt.Columns.Add("状态", typeof(string));
            foreach (model.Result r1 in rs)
            {
                model.Student d = new model.Student();
                Console.Write(r1.Student_num + "111111111111111111");
                d = s.find_student(r1.Student_num);
                Console.Write("1111111111111111111");


                dt.Rows.Add(r1.Result_num, r1.Course_num, tmp1, d.Student_num, d.Student_name, c.Maxcount, r1.State);




            }
            dataGridView1.DataSource = dt;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            course su = new course();
            su.SH = this;
            su.ShowDialog();
        }
    }
}
