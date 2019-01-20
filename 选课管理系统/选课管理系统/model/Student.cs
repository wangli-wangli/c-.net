using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 选课管理系统.model
{
    public class Student//学生
    {
        private string student_num;//学号
        public string id;
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Student_num
        {
            get { return student_num; }
            set { student_num = value; }
        }
        private string student_name;//姓名

        public string Student_name
        {
            get { return student_name; }
            set { student_name = value; }
        }
        private string student_academy;//学院

        public string Student_academy
        {
            get { return student_academy; }
            set { student_academy = value; }
        }
        private string student_grade;//年级

        public string Student_grade
        {
            get { return student_grade; }
            set { student_grade = value; }
        }
       
        private string password;//密码 

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        private string sex;//性别

        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }
        private string profession;//专业

        public string Profession
        {
            get { return profession; }
            set { profession = value; }
        }
        private string id_number;//身份证号码

        public string Id_number
        {
            get { return id_number; }
            set { id_number = value; }
        }
        private string classs;//班级

        public string Classs
        {
            get { return classs; }
            set { classs = value; }
        }
          private string telephone;//电话

        public string Telephone
        {
            get { return Telephone; }
            set { Telephone = value; }
        }
        private string sushe;//宿舍

        public string Sushe
        {
            get { return sushe; }
            set { sushe = value; }
        }
        private string zhuzhi;//住址

        public string Zhuzhi
        {
            get { return zhuzhi; }
            set { zhuzhi = value; }
        }
        private string shengao;//身高
        public string Shengao
        {
            get { return Shengao; }
            set { Shengao = value; }
        }
        private string tizhong;//体重

        public string Tizhong
        {
            get { return tizhong; }
            set { tizhong  = value; }
        }
        private string aihao;//爱好

        public string Aihao
        {
            get { return aihao; }
            set { aihao = value; }
        }
        private string techang;//特长

        public string Techang
        {
            get { return techang; }
            set { techang = value; }
        }
        private string  m_telephone;//母亲电话
        
        public string M_telephone
        {
            get { return  m_telephone; }
            set { m_telephone = value; }
        }
        private string f_telephone;//父亲电话

        public string F_telephone
        {
            get { return f_telephone; }
            set { f_telephone = value; }
        }

    
    }
}
