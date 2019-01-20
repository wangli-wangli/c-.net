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
    public partial class admin_home : Form
    {
        
       public  static new Student stud;//当前窗口和修改信息窗口用来传递修改的学生信息；
       public  static new Course course;//当前窗口和修改信息窗口用来传递修改的课程信息；
       public static new Teacher tea;//当前窗口和修改信息窗口用来传递修改的老师信息；
       public int s_count=0;//添加第几行学生信息
       public int c_count = 0;//添加第几行课程信息
       public int t_count = 0;//调加第几行教师
       public static string teacher_num;
        public List<string> teacher_nums=new List<string>();//管理员添加课程时选择的老师工号;
        public admin_home()
        {
            InitializeComponent();
            teacher_num = dao.teacherDao.find_num();
            panel4.Visible = false;
            panel2.Visible = false;
            panel7.Visible = false;
            panel5.Visible = false;
            panel9.Visible = false;
            panel添加教师页面.Visible = false;
            查看教师页面.Visible = false;
            panel审核.Visible = false;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                    }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
              
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool wanzheng = true; ;//用户是否输入完整
            int i = dataGridView1.RowCount;
        
            dao.studentDao Sdao = new studentDao();
            for (int j = 0; j < i-1; j++)//检查时候有未填的空
            {

               
                string Student_num = Convert.ToString(dataGridView1.Rows[j].Cells[0].Value);//学号
                string Student_name = Convert.ToString(dataGridView1.Rows[j].Cells[1].Value);//学号
                string Sex = Convert.ToString(dataGridView1.Rows[j].Cells[2].Value);//性别
                string Student_grade = Convert.ToString(dataGridView1.Rows[j].Cells[3].Value);//年纪
                string Student_academy = Convert.ToString(dataGridView1.Rows[j].Cells[4].Value);//学院
                string Profession = Convert.ToString(dataGridView1.Rows[j].Cells[5].Value);//专业
                string Id_number = Convert.ToString(dataGridView1.Rows[j].Cells[7].Value);//身份证号
                string Classs = Convert.ToString(dataGridView1.Rows[j].Cells[6].Value);//身份证号
                if (Id_number.Length !=18)
                {
                    MessageBox.Show("请输入" + Student_name + "的正确身份证号！");
                    wanzheng = false;
                }
                else if(Student_num==""||Student_name==""||Sex==""||Student_grade==""||Student_grade==""||
                    Student_academy == "" || Profession == "" || Id_number == "" || Classs == "")
                {
                    MessageBox.Show("请输入完整信息！");
                    wanzheng = false;
                }
                

            }
            if (wanzheng == true)
            {
                for (int j = 0; j < i-1; j++)
                {

                    model.Student student = new Student();
                    student.Student_num = Convert.ToString(dataGridView1.Rows[j].Cells[0].Value);//学号
                    student.Student_name = Convert.ToString(dataGridView1.Rows[j].Cells[1].Value);//学号
                    student.Sex = Convert.ToString(dataGridView1.Rows[j].Cells[2].Value);//性别
                    student.Student_grade = Convert.ToString(dataGridView1.Rows[j].Cells[3].Value);//年纪
                    student.Student_academy = Convert.ToString(dataGridView1.Rows[j].Cells[4].Value);//学院
                    student.Profession = Convert.ToString(dataGridView1.Rows[j].Cells[5].Value);//专业
                    student.Id_number = Convert.ToString(dataGridView1.Rows[j].Cells[7].Value);//身份证号
                    student.Classs = Convert.ToString(dataGridView1.Rows[j].Cells[6].Value);//身份证号
                    student.Password = student.Id_number.Substring(student.Id_number.Length- 6, 6);
                    bool isd = dao.studentDao.add_student(student);
                    if (isd == false)
                    {
                        MessageBox.Show("提交失败！");
                        break;
                    }

                }

                MessageBox.Show("提交成功！");
                dataGridView1.Rows.Clear();
                s_count = 0;
            }
        
    }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)   
        {          
            base.ProcessCmdKey(ref msg, keyData);   
            int WM_KEYDOWN = 256;       
            int WM_SYSKEYDOWN = 260;    
            bool _disable = false;     
            if (msg.Msg == WM_KEYDOWN || msg.Msg == WM_SYSKEYDOWN)    
            {              
                switch (keyData)           
                {          
                    case Keys.Enter:              
                        SendKeys.Send("{Tab}");          
                        _disable = true;                
                        break;            
                }   
            }         
            return _disable;   
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 || e.ColumnIndex == -1)
            {
                string num = dao.studentDao.find_num();
                int num2 = int.Parse(num)+s_count;
                num2 = num2 + 1;
                dataGridView1.CurrentRow.Cells[0].Value = num2;
                s_count++;
            }
        }
        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            s_count = 0;
         }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            panel7.Visible = false;
            panel4.Visible = false;
            panel9.Visible = false;
            panel5.Visible = false;
            panel添加教师页面.Visible = false;
            查看教师页面.Visible = false;
            panel审核.Visible = false;
            panel2.Visible = true;
            List<Student> students = new List<Student>();

            dataGridView2.Rows.Clear();
            students = dao.studentDao.find_students();
           
            int i = 0;
           
            if (students!= null)
            {
                
                foreach (Student s in students)
                {
                    dataGridView2.Rows.Add();
                    dataGridView2.Rows[i].Cells[0].Value =s.Student_num;
                    dataGridView2.Rows[i].Cells[1].Value = s.Student_name;
                    dataGridView2.Rows[i].Cells[2].Value = s.Sex;
                    dataGridView2.Rows[i].Cells[3].Value = s.Student_grade;
                    dataGridView2.Rows[i].Cells[4].Value = s.Student_academy;
                    dataGridView2.Rows[i].Cells[5].Value = s.Profession;
                    dataGridView2.Rows[i].Cells[6].Value = s.Classs;
                    dataGridView2.Rows[i].Cells[7].Value = s.Id_number;
                    
                    i++;
                }
            }
            dataGridView2.ReadOnly = true;
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel4.Visible = false;
            panel9.Visible = false;
            panel5.Visible = false;
            panel添加教师页面.Visible = false;
            查看教师页面.Visible = false;
            panel审核.Visible = false;
            panel7.Visible = true;
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "  ";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Student ss = new Student();
                ss.Student_num = textBox3.Text;
                ss.Student_name = textBox4.Text;
                ss.Student_grade = comboBox1.Text;
                ss.Student_academy = comboBox2.Text;
                ss.Classs = textBox2.Text;
                ss.Profession = textBox1.Text;
                List<Student> students = new List<Student>();
                if (ss.Student_num == "" && ss.Student_name == "" && ss.Student_grade == "" && ss.Student_academy == ""
                && ss.Classs == "" && ss.Profession == "")//如果输入为空，则显示全部学生信息
            {
               

                students = dao.studentDao.find_students();

              
            }
            else//如果输入查询条件则更具条件查询
            {
                students = dao.studentDao.find_students2(ss);
            }

            dataGridView2.Rows.Clear();
            int i = 0;

            if (students != null)
            {

                foreach (Student s in students)
                {
                    dataGridView2.Rows.Add();
                    dataGridView2.Rows[i].Cells[0].Value = s.Student_num;
                    dataGridView2.Rows[i].Cells[1].Value = s.Student_name;
                    dataGridView2.Rows[i].Cells[2].Value = s.Sex;
                    dataGridView2.Rows[i].Cells[3].Value = s.Student_grade;
                    dataGridView2.Rows[i].Cells[4].Value = s.Student_academy;
                    dataGridView2.Rows[i].Cells[5].Value = s.Profession;
                    dataGridView2.Rows[i].Cells[6].Value = s.Classs;
                    dataGridView2.Rows[i].Cells[7].Value = s.Id_number;
                    
                    i++;
                }
            }
            //清空原来输入的查询条件
            textBox3.Text="";
            textBox4.Text="";
            comboBox1.Text="";
             comboBox2.Text="";
            textBox2.Text="";
            textBox1.Text="";
        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                int i = e.RowIndex;
                string student_num = Convert.ToString(dataGridView2.Rows[i].Cells[0].Value);
                MessageBox.Show("" + student_num);
                studentDao.delete(student_num);
                dataGridView2.Rows.Remove(dataGridView2.Rows[i]);
            }
            else if(e.ColumnIndex == 9)//查询
            {
                int i = e.RowIndex;
               
                Student s = new Student();
                string student_num = Convert.ToString(dataGridView2.Rows[i].Cells[0].Value);
                Form f1= new student_update(student_num);
                f1.ShowDialog();
                if (stud != null)//用户修改了信息
                {
                    dataGridView2.Rows[i].Cells[0].Value = stud.Student_num;
                    dataGridView2.Rows[i].Cells[1].Value = stud.Student_name;//性别不能修改
                    dataGridView2.Rows[i].Cells[3].Value = stud.Student_grade;
                    dataGridView2.Rows[i].Cells[4].Value = stud.Student_academy;
                    dataGridView2.Rows[i].Cells[5].Value = stud.Profession;
                    dataGridView2.Rows[i].Cells[6].Value = stud.Classs;
                    dataGridView2.Rows[i].Cells[7].Value = stud.Id_number;
                }

            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel7.Visible = false;
            panel5.Visible = false;
            panel9.Visible = false;
            panel添加教师页面.Visible = false;
            查看教师页面.Visible = false;
            panel审核.Visible = false;
            panel4.Visible = true;
           
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex ==9 )//添加课程时选择老师
            {
                Form g = new select_teacher();
                g.ShowDialog();
                dataGridView3.CurrentRow.Cells[9].Value = teacher_num;
                teacher_nums.Add(teacher_num);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            bool wanzheng = true;//用户是否输入完整
            int i = dataGridView3.RowCount;
          
            dao.courseDao Sdao = new courseDao();
            for (int j = 0; j < i - 1; j++)//检查时候有未填的空
            {
                string Course_num = Convert.ToString(dataGridView3.Rows[j].Cells[0].Value);//课程号
                string Course_name = Convert.ToString(dataGridView3.Rows[j].Cells[1].Value);//课程名
                string Credit_hour = Convert.ToString(dataGridView3.Rows[j].Cells[2].Value);//学分
                string Type = Convert.ToString(dataGridView3.Rows[j].Cells[3].Value);//类别
                string Address = Convert.ToString(dataGridView3.Rows[j].Cells[4].Value);//地点
                string Time_week = Convert.ToString(dataGridView3.Rows[j].Cells[5].Value);//上课时间
                string time_jie = Convert.ToString(dataGridView3.Rows[j].Cells[6].Value);//上课时间
                string Academy = Convert.ToString(dataGridView3.Rows[j].Cells[7].Value);//学院
                string maxcount = Convert.ToString(dataGridView3.Rows[j].Cells[8].Value);//最大容量
                string teacher_num = teacher_nums[j];//老师工号
                if (Course_num == "" || Course_name == "" || Credit_hour == "" || Type == "" || Address == "" ||
                    Time_week == "" || time_jie == "" || Academy == ""||maxcount==""||teacher_num=="" )
                {
                    MessageBox.Show("请输入完整信息！");
                    wanzheng = false;
                }


            }
            if (wanzheng == true)
            {
                for (int j = 0; j < i-1; j++)
                {

                    model.Course course = new Course();
                    course .Course_num= Convert.ToString(dataGridView3.Rows[j].Cells[0].Value);//课程号
                    course.Course_name = Convert.ToString(dataGridView3.Rows[j].Cells[1].Value);//课程名
                    course.Credit_hour = Convert.ToString(dataGridView3.Rows[j].Cells[2].Value);//学分
                    course.Type = Convert.ToString(dataGridView3.Rows[j].Cells[3].Value);//类别
                    course.Address = Convert.ToString(dataGridView3.Rows[j].Cells[4].Value);//地点
                    course.Time_week = Convert.ToString(dataGridView3.Rows[j].Cells[5].Value);//上课时间
                    course.Time_jie = Convert.ToString(dataGridView3.Rows[j].Cells[6].Value);//上课时间
                    course.Academy = Convert.ToString(dataGridView3.Rows[j].Cells[7].Value);//学院
                    course.Maxcount = Convert.ToInt32(dataGridView3.Rows[j].Cells[8].Value);//最大容量
                   
                    course.Teacher_num = teacher_nums[j];//老师工号
                
                    bool isd = dao.courseDao.add_course(course);
                    if (isd == false)
                    {
                        MessageBox.Show("提交失败！");
                        break;
                    }

                }

                MessageBox.Show("提交成功！");
                dataGridView3.Rows.Clear();
                teacher_nums.Clear();
                c_count = 0;
            }
        

        }

        private void dataGridView3_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dataGridView3_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 || e.ColumnIndex == -1)
            {
                int num2 ;
                string num = dao.courseDao.find_num();
                num2 = int.Parse(num)+c_count;
                num2 = num2 + 1;
                dataGridView3.CurrentRow.Cells[0].Value = num2;
                c_count++;
            }
           

        }

        private void button7_Click(object sender, EventArgs e)
        {
            dataGridView3.Rows.Clear();
            teacher_nums.Clear();
            c_count = 0;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Course ss = new Course();
            ss.Type = comboBox4.Text;
            ss.Academy = comboBox3.Text;
            ss.Time_week = comboBox5.Text;
            ss.Time_jie = comboBox6.Text;
            ss.Course_num = textBox6.Text;
            ss.Course_name = textBox5.Text;
            List<Course> courses = new List<Course>();
            if (ss.Type == "" && ss.Academy == "" && ss.Time_week == "" && ss.Time_jie == ""
            && ss.Course_num== "" && ss.Course_name == "")//如果输入为空，则显示全部学生信息
            {
                courses = dao.courseDao.find_courses();

            }
            else//如果输入查询条件则更具条件查询
            {
                courses = dao.courseDao.find_courses2(ss);
            }

            dataGridView4.Rows.Clear();
            int i = 0;
           if (courses != null)
            {

                foreach (Course s in courses)
                {
                    dataGridView4.Rows.Add();
                    dataGridView4.Rows[i].Cells[0].Value = s.Course_num;
                    dataGridView4.Rows[i].Cells[1].Value = s.Course_name;
                    dataGridView4.Rows[i].Cells[2].Value = s.Credit_hour;
                    dataGridView4.Rows[i].Cells[3].Value = s.Type;
                    dataGridView4.Rows[i].Cells[4].Value = s.Address;
                    dataGridView4.Rows[i].Cells[5].Value = s.Time_week;
                    dataGridView4.Rows[i].Cells[6].Value = s.Time_jie;
                    dataGridView4.Rows[i].Cells[7].Value = s.Academy;
                    dataGridView4.Rows[i].Cells[8].Value = s.Maxcount;
                    dataGridView4.Rows[i].Cells[9].Value = s.Teacher_num;
                    i++;
                }
            }
            //清空原来输入的查询条件
            comboBox4.Text="";
            comboBox3.Text="";
            comboBox5.Text="";
            comboBox6.Text="";
            textBox6.Text="";
            textBox5.Text="";
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            panel7.Visible = false;
            panel4.Visible = false;
            panel2.Visible = false;
            panel9.Visible = false;
            panel添加教师页面.Visible = false;
            查看教师页面.Visible = false;
            panel审核.Visible = false;
            panel5.Visible = true;
            List<Course> courses = new List<Course>();
            dataGridView4.Rows.Clear();
            courses = dao.courseDao.find_courses();

            int i = 0;

            if (courses != null)
            {

                foreach (Course s in courses)
                {
                    dataGridView4.Rows.Add();
                    dataGridView4.Rows[i].Cells[0].Value = s.Course_num;
                    dataGridView4.Rows[i].Cells[1].Value = s.Course_name;
                    dataGridView4.Rows[i].Cells[2].Value = s.Credit_hour;
                    dataGridView4.Rows[i].Cells[3].Value = s.Type;
                    dataGridView4.Rows[i].Cells[4].Value = s.Address;
                    dataGridView4.Rows[i].Cells[5].Value = s.Time_week;
                    dataGridView4.Rows[i].Cells[6].Value = s.Time_jie;
                    dataGridView4.Rows[i].Cells[7].Value = s.Academy;
                    dataGridView4.Rows[i].Cells[8].Value = s.Maxcount;
                    dataGridView4.Rows[i].Cells[9].Value = s.Teacher_num;
                    i++;
                }
            }
            //dataGridView4.ReadOnly = true;

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 10)
            {
                int i = e.RowIndex;
                string Course_num = Convert.ToString(dataGridView4.Rows[i].Cells[0].Value);
                MessageBox.Show( Course_num+"学生已删除!");
                courseDao.delete(Course_num);
                dataGridView4.Rows.Remove(dataGridView4.Rows[i]);
            }
            else if (e.ColumnIndex == 11)//查询
            {
                int i = e.RowIndex;
                Course s = new Course();
                string Course_num = Convert.ToString(dataGridView4.Rows[i].Cells[0].Value);
                Form f1 = new course_update(Course_num);
                f1.ShowDialog();
                if (course != null)//用户修改了信息
                {
                    dataGridView4.Rows[i].Cells[0].Value = course.Course_num;
                    dataGridView4.Rows[i].Cells[1].Value = course.Course_name;
                    dataGridView4.Rows[i].Cells[2].Value = course.Credit_hour;
                    dataGridView4.Rows[i].Cells[3].Value = course.Type;
                    dataGridView4.Rows[i].Cells[4].Value = course.Address;
                    dataGridView4.Rows[i].Cells[5].Value = course.Time_week;
                    dataGridView4.Rows[i].Cells[6].Value = course.Time_jie;
                    dataGridView4.Rows[i].Cells[7].Value = course.Academy;
                    dataGridView4.Rows[i].Cells[8].Value = course.Maxcount;
                    dataGridView4.Rows[i].Cells[9].Value = course.Teacher_num;

                }

            }

        }

        //  private void toolStripMenuItem5_Click(object sender, EventArgs e)
        private void 发布ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           panel7.Visible = false;
            panel4.Visible = false;
           panel2.Visible = false;
           panel5.Visible = false;
           panel添加教师页面.Visible = false;
           panel审核.Visible = false;
           查看教师页面.Visible = false;
            panel9.Visible = true;
           
            List<string> student_academys = dao.studentDao.find_academys();
            string[][] class2 = new string[student_academys.Count][];
            int i = 0;
            foreach (string student_academy in student_academys)
            {
                List<string> classs = dao.studentDao.find_classs(student_academy);
                foreach (string class1 in classs)
                {
                    class2[i] = new string[] { student_academy, class1 };
                    Console.WriteLine(student_academy + "   " + class1);
                    i++;
                }
            }
          
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Nodes.Count > 0)
            {
                foreach (TreeNode node in e.Node.Nodes)
                {
                    node.Checked = e.Node.Checked;
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void 发布ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            panel7.Visible = false;
            panel4.Visible = false;
            panel2.Visible = false;
            panel5.Visible = false;
            panel添加教师页面.Visible = false;
            查看教师页面.Visible = false;
            panel审核.Visible = false;
            panel9.Visible = true;
            treeView2.Nodes.Clear();
            treeView1.Nodes.Clear();
            //学生树
            List<string> student_academys = dao.studentDao.find_academys();
            int count = dao.studentDao.find_classCount();
            string[][] class2 = new string[count][];
           
           
            int i = 0;
            foreach (string student_academy in student_academys)
            {
                List<string> classs = dao.studentDao.find_classs(student_academy);
                foreach (string class1 in classs)
                {
                    class2[i] = new string[] { student_academy, class1 };
                    i++;
                }
            }
            foreach (var data in class2)
            {
                string date = data[0];
                string value = data[1];
                TreeNode datenode = new TreeNode(date);
                datenode.Name = date;
                TreeNode valuenode = new TreeNode(value);
                if (!treeView1.Nodes.ContainsKey(date))
                {
                    treeView1.Nodes.Add(datenode);
                    treeView1.Nodes[date].Nodes.Add(valuenode);
                }
                else
                {
                    treeView1.Nodes[date].Nodes.Add(valuenode);
                }
            }
            
            ////课程树
            List<string> course_academys = dao.courseDao.find_academys();
            count = dao.courseDao.find_countCount();
          
            string[][] course2 = new string[count][];
            int j = 0;
            foreach (string academy in course_academys)
            {
                List<string> classs = dao.courseDao.find_courses3(academy);
                foreach (string class1 in classs)
                {
                    
                    course2[j] = new string[] { academy, class1 };
                   
                    j++;
                }
            }
            foreach (var data in course2)
            {
                string date = data[0];
                string value = data[1];
                TreeNode datenode = new TreeNode(date);
                datenode.Name = date;
                TreeNode valuenode = new TreeNode(value);
                if (!treeView2.Nodes.ContainsKey(date))
                {
                    treeView2.Nodes.Add(datenode);
                    treeView2.Nodes[date].Nodes.Add(valuenode);
                }
                else
                {
                    treeView2.Nodes[date].Nodes.Add(valuenode);
                }
            }
            

        }

        private void treeView1_AfterCheck_1(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Nodes.Count > 0)
            {
                foreach (TreeNode node in e.Node.Nodes)
                {
                    node.Checked = e.Node.Checked;
                }
            }
        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void treeView2_AfterCheck(object sender, TreeViewEventArgs e)
        {
             if (e.Node.Nodes.Count > 0)
            {
                foreach (TreeNode node in e.Node.Nodes)
                {
                    node.Checked = e.Node.Checked;
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //获取选中的班级
           List<string> classs=new List<string>();
            foreach (TreeNode tn in treeView1.Nodes)
            {
                    foreach(TreeNode tn2 in tn.Nodes){
                  
                        if (tn2.Checked == true)
                        {
                            classs.Add(tn2.Text);
                        }
                    }
                 
                
            }
            //获取选中的课程号
            List<string> course_num = new List<string>();
            foreach (TreeNode tn in treeView2.Nodes)
            {
                foreach (TreeNode tn2 in tn.Nodes)
                {

                    if (tn2.Checked == true)
                    {
                        string num = tn2.Text;
                        int IndexofA = num.IndexOf('(');
                        int IndexofB = num.IndexOf(')');
                      string course_num2 = num.Substring(IndexofA + 1, IndexofB - IndexofA - 1); 

                        //string course_num2 = tn2.Text.Substring(1, 3);
                        course_num.Add(course_num2);
                    }
                }


            }

            //查询出该班级内的所有学号
            List<string> student_num = dao.studentDao.find_studentNums(classs);
            //讲学号以及课程号写入result表
            List<Result> results = new List<Result>();
            foreach (string n in student_num)
            {
                foreach (string c in course_num)
                {
                    System.DateTime currentTime=new System.DateTime(); 
                    currentTime=System.DateTime.Now; 
                    Result result = new Result();
                    result.Course_num = c;
                    result.Student_num = n;
                    result.Term = "春";
                    result.Year = currentTime.Year.ToString();
                    dao.resultDao.add_result(result);
                }
            }
            MessageBox.Show("提交成功！");
          //取消节点前的复选框选中状态
            foreach (TreeNode tn in treeView1.Nodes)
            {
                if (tn.Checked == true) tn.Checked = false;
                foreach (TreeNode tn2 in tn.Nodes)
                {

                    if (tn2.Checked == true)
                    {
                        tn2.Checked = false;
                    }
                }


            }

            foreach (TreeNode tn in treeView2.Nodes)
            {
                if (tn.Checked == true) tn.Checked = false;
                foreach (TreeNode tn2 in tn.Nodes)
                {

                    if (tn2.Checked == true)
                    {
                        tn2.Checked = false;
                    }
                }


            }
           
        }

        private void 教师查询按钮_Click(object sender, EventArgs e)
        {
            Teacher ss = new Teacher();
            ss.Teacher_num = 工号1.Text;
            ss.Teacher_name = 姓名1.Text;

            ss.Teacher_academy = 学院1.Text;

            ss.Profession = 专业1.Text;
            List<Teacher> teachers = new List<Teacher>();
            if (ss.Teacher_num == "" && ss.Teacher_name == "" && ss.Teacher_academy == "" && ss.Profession == "")//如果输入为空，则显示全部学生信息
            {


                teachers = dao.teacherDao.find_teachers();


            }
            else//如果输入查询条件则更具条件查询
            {
                teachers = dao.teacherDao.find_teachers2(ss);
            }

            教师显示.Rows.Clear();
            int i = 0;

            if (teachers != null)
            {

                foreach (Teacher s in teachers)
                {
                    教师显示.Rows.Add();
                    教师显示.Rows[i].Cells[0].Value = s.Teacher_num;
                    教师显示.Rows[i].Cells[1].Value = s.Teacher_name;
                    教师显示.Rows[i].Cells[2].Value = s.Sex;
                    教师显示.Rows[i].Cells[3].Value = s.Teacher_academy;
                    教师显示.Rows[i].Cells[4].Value = s.Profession;
                    教师显示.Rows[i].Cells[5].Value = s.Id_number;

                    i++;
                }
            }
            //清空原来输入的查询条件
            学院1.Text = "";
            专业1.Text = "";
            姓名1.Text = "";
            工号1.Text = "";
           
        }

        private void 查看ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel7.Visible = false;
            panel4.Visible = false;
            panel2.Visible = false;
            panel5.Visible = false;
            panel添加教师页面.Visible = false;
            panel9.Visible = false;
            panel审核.Visible = false;
            查看教师页面.Visible = true;

            教师显示.Rows.Clear();
            List<Teacher> teachers = new List<Teacher>();

            teachers = dao.teacherDao.find_teachers();

            int i = 0;

            if (teachers != null)
            {

                foreach (Teacher s in teachers)
                {
                    教师显示.Rows.Add();
                    教师显示.Rows[i].Cells[0].Value = s.Teacher_num;
                    教师显示.Rows[i].Cells[1].Value = s.Teacher_name;
                    教师显示.Rows[i].Cells[2].Value = s.Sex;
                    教师显示.Rows[i].Cells[3].Value = s.Teacher_academy;
                    教师显示.Rows[i].Cells[4].Value = s.Profession;
                    教师显示.Rows[i].Cells[5].Value = s.Id_number;

                    i++;
                }
            }
        }

        private void 教师显示_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)//删除
            {
                int i = e.RowIndex;
                string teacher_num = Convert.ToString(教师显示.Rows[i].Cells[0].Value);
                MessageBox.Show("删除成功！" );
                teacherDao.delete(teacher_num);
                教师显示.Rows.Remove(教师显示.Rows[i]);
            }
            else if (e.ColumnIndex == 7)//查询
            {
                int i = e.RowIndex;

                Teacher s = new Teacher();
                string teacher_num = Convert.ToString(教师显示.Rows[i].Cells[0].Value);
                Form f1 = new teacher_update(teacher_num);
                f1.ShowDialog();
                Teacher teacher = new Teacher();
                teacherDao.update(teacher);
                if (tea != null)//用户修改了信息
                {
                    教师显示.Rows[i].Cells[0].Value = tea.Teacher_num;
                    教师显示.Rows[i].Cells[1].Value = tea.Teacher_name;
                   // 教师显示.Rows[i].Cells[2].Value = tea.Sex;//性别不能修改
                    教师显示.Rows[i].Cells[3].Value = tea.Teacher_academy;
                    教师显示.Rows[i].Cells[4].Value = tea.Profession;
                    教师显示.Rows[i].Cells[5].Value = tea.Id_number;
                }

            }
           
        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel7.Visible = false;
            panel4.Visible = false;
            panel2.Visible = false;
            panel5.Visible = false;
            panel9.Visible = false;
           查看教师页面.Visible = false;
           panel审核.Visible = false;
            panel添加教师页面.Visible = true;
           
        }

        private void 提交添加老师_Click(object sender, EventArgs e)
        {
            bool wanzheng = true; ;//用户是否输入完整
            int i = 添加学生框.RowCount;
            // MessageBox.Show("" + i);
            dao.teacherDao tdao = new teacherDao();

            for (int j = 0; j < i - 1; j++)//检查时候有未填的空
            {


                string Teacher_num = Convert.ToString(添加学生框.Rows[j].Cells[0].Value);//学号
                string Teacher_name = Convert.ToString(添加学生框.Rows[j].Cells[1].Value);//学号
                string Sex = Convert.ToString(添加学生框.Rows[j].Cells[2].Value);//性别
                string Teacher_academy = Convert.ToString(添加学生框.Rows[j].Cells[3].Value);//学院
                string Profession = Convert.ToString(添加学生框.Rows[j].Cells[4].Value);//专业
                string Id_number = Convert.ToString(添加学生框.Rows[j].Cells[5].Value);//身份证号
                if (Id_number.Length != 18)
                {
                    MessageBox.Show("请输入正确的" + Teacher_name + "的身份证号码");
                    wanzheng = false;
                }
                else if (Teacher_num == "" || Teacher_name == "" || Sex == "" || Teacher_academy == "" || Profession == "" || Id_number == "")
                {
                    MessageBox.Show("请输入完整信息！");
                    wanzheng = false;
                }


            }
            if (wanzheng == true)
            {
                for (int j = 0; j < i-1; j++)
                {

                    model.Teacher teacher = new Teacher();
                    teacher.Teacher_num = Convert.ToString(添加学生框.Rows[j].Cells[0].Value);//学号
                    teacher.Teacher_name = Convert.ToString(添加学生框.Rows[j].Cells[1].Value);//学号
                    teacher.Sex = Convert.ToString(添加学生框.Rows[j].Cells[2].Value);//性别
                    teacher.Teacher_academy = Convert.ToString(添加学生框.Rows[j].Cells[3].Value);//学院
                    teacher.Profession = Convert.ToString(添加学生框.Rows[j].Cells[4].Value);//专业
                    teacher.Id_number = Convert.ToString(添加学生框.Rows[j].Cells[5].Value);//身份证号
                    string id_number = teacher.Id_number;
                    teacher.Password = id_number.Substring(id_number.Length - 6, 6);
                    bool isd = dao.teacherDao.add_teacher(teacher);
                    if (isd == false)
                    {
                        MessageBox.Show("提交失败！");
                        break;
                    }

                }

                MessageBox.Show("提交成功！");
                添加学生框.Rows.Clear();
            }
        }

        private void 清空添加老师_Click(object sender, EventArgs e)
        {
            添加学生框.Rows.Clear();
        }

        private void panel添加教师页面_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void 添加学生框_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 || e.ColumnIndex == -1)
            {
                string num = dao.teacherDao.find_num();
                int num2 = int.Parse(num) + t_count;
                num2 = num2 + 1;
                添加学生框.CurrentRow.Cells[0].Value = num2;
                t_count++;
            }

        }

        private void admin_home_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            panel7.Visible = false;
            panel4.Visible = false;
            panel2.Visible = false;
            panel5.Visible = false;
            panel9.Visible = false;
            查看教师页面.Visible = false;
            panel添加教师页面.Visible = false;
            panel审核.Visible = true;
          
            shenhe sAllPage = new shenhe();
            sAllPage.FormBorderStyle = FormBorderStyle.None;
            sAllPage.Dock = DockStyle.Fill;
            sAllPage.TopLevel = false;
            panel审核.Controls.Clear();
            panel审核.Controls.Add(sAllPage);
            sAllPage.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {

        }

       

    }
}

