using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 选课管理系统.model;
using 选课管理系统.dao;

namespace 选课管理系统
{
    public partial class course_update : Form
    {
        public course_update(string Course_num)
        {
            InitializeComponent();
            model.Course s = dao.courseDao.find_course(Course_num);
            text11.Text = s.Course_num;
            text12.Text = s.Course_name;
            text13.Text = s.Credit_hour;
            text14.Text = s.Type;
            text15.Text = s.Address;
            text16.Text = s.Academy;
            textBox1.Text = s.Time_week;
            textBox2.Text = s.Time_jie;
            button3.Text = s.Teacher_num;
            textBox4.Text = s.Maxcount.ToString() ;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            admin_home.course = new Course();
            admin_home.course.Course_num = text11.Text;
            admin_home.course.Course_name = text12.Text;
            admin_home.course.Credit_hour = text13.Text;
            admin_home.course.Type = text14.Text;
            admin_home.course.Address = text15.Text;
            admin_home.course.Academy = text16.Text;
            admin_home.course.Time_week = textBox1.Text;
            admin_home.course.Time_jie = textBox2.Text;
            admin_home.course.Teacher_num = button3.Text;
            admin_home.course.Maxcount = int.Parse(textBox4.Text);
            dao.courseDao.update(admin_home.course);
            this.Close();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && (e.KeyChar != 8) && (e.KeyChar != 46))
                e.Handled = true;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void course_update_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form s=new select_teacher();
            s.ShowDialog();
            button3.Text = select_teacher.t_num;
        }
    }
}
