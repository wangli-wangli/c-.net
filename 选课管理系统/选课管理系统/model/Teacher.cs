using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 选课管理系统.model
{
    public class Teacher//老师
    {
        private string teacher_num;//工号

        public string Teacher_num
        {
            get { return teacher_num; }
            set { teacher_num = value; }
        }
        private string teacher_name;//姓名

        public string Teacher_name
        {
            get { return teacher_name; }
            set { teacher_name = value; }
        }
        private string teacher_academy;//学院

        public string Teacher_academy
        {
            get { return teacher_academy; }
            set { teacher_academy = value; }
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
    }
}
