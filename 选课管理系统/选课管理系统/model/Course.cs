using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 选课管理系统.model
{
    public class Course//课程
    {

        private string course_num;//课程号

        public string Course_num
        {
            get { return course_num; }
            set { course_num = value; }
        }
        private string course_name;//课程名

        public string Course_name
        {
            get { return course_name; }
            set { course_name = value; }
        }
        private string credit_hour;//学分

        public string Credit_hour
        {
            get { return credit_hour; }
            set { credit_hour = value; }
        }
        private string type;//类别：必修，限选，任选，先选

        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        private string address;//地点

        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        private string time_week;//上课时间：周×：

        public string Time_week
        {
            get { return time_week; }
            set { time_week = value; }
        }
        private string time_jie;//上课时间：1-2节

        public string Time_jie
        {
            get { return time_jie; }
            set { time_jie = value; }
        }
        private string academy;//学院（与开课老师学院相同）

        public string Academy
        {
            get { return academy; }
            set { academy = value; }
        }

        private int maxcount;//最大容量

        public int Maxcount
        {
            get { return maxcount; }
            set { maxcount = value; }
        }
        private string teacher_num;//老师工号

        public string Teacher_num
        {
            get { return teacher_num; }
            set { teacher_num = value; }
        }

        


    }
}
