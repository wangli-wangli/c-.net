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
    public partial class teacher_update : Form
    {
        public teacher_update()
        {
            InitializeComponent();
        }
         public teacher_update(string teacher_num)
        {
            InitializeComponent();
            model.Teacher s =dao.teacherDao.find_teacher(teacher_num);
            text11.Text = teacher_num;
            text12.Text = s.Teacher_name;
            text14.Text = s.Teacher_academy;
            text15.Text = s.Profession;
            text17.Text = s.Password;
            text18.Text = s.Id_number;
           
            

           
        }
        private void teacher_update_Load(object sender, EventArgs e)
        {
            
        }

        private void text15_TextChanged(object sender, EventArgs e)
        {

        }

        private void text17_TextChanged(object sender, EventArgs e)
        {

        }

        private void text18_TextChanged(object sender, EventArgs e)
        {

        }

        private void text19_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            admin_home.tea = new Teacher();
            admin_home.tea.Teacher_num = text11.Text;
            admin_home.tea.Teacher_name = text12.Text;
            admin_home.tea.Teacher_academy = text14.Text;
            admin_home.tea.Profession = text15.Text;
            admin_home.tea.Password = text17.Text;
            admin_home.tea.Id_number = text18.Text;
            dao.teacherDao.update(admin_home.tea);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void text18_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
