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
    public partial class student_update : Form
    {
        
        public student_update(string student_num)
        {
            InitializeComponent();
            model.Student s =dao.studentDao.find_student(student_num);
            text11.Text = student_num;
            text12.Text = s.Student_name;
            text13.Text =s.Student_grade;
            text14.Text = s.Student_academy;
            text15.Text = s.Profession;
            text16.Text = s.Classs;
            text17.Text = s.Password;
            text18.Text = s.Id_number;
           
        }

        private void student_update_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            admin_home.stud = new Student();
            admin_home.stud.Student_num= text11.Text;
            admin_home.stud.Student_name = text12.Text;
              admin_home.stud.Student_grade=text13.Text;
              admin_home.stud.Student_academy= text14.Text;
              admin_home.stud.Profession= text15.Text;
             admin_home.stud.Classs= text16.Text;
              admin_home.stud.Password=text17.Text;
               admin_home.stud.Id_number=text18.Text;
              dao.studentDao.update( admin_home.stud); 
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void text12_TextChanged(object sender, EventArgs e)
        {

        }

        private void text11_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void text13_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void text14_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void text15_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void text16_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void text17_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void text18_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void text19_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void text20_TextChanged(object sender, EventArgs e)
        {

        }

        private void text11_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void text17_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
