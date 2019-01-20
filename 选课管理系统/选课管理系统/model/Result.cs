using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 选课管理系统.model
{
    class Result//成绩
    {
        private string result_num;//关键字
        public int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Result_num
        {
            get { return result_num; }
            set { result_num = value; }
        }
        private string student_num;//学号

        public string Student_num
        {
            get { return student_num; }
            set { student_num = value; }
        }
     
        private string course_num;//课程号

        public string Course_num
        {
            get { return course_num; }
            set { course_num = value; }
        }
        private double  score;//成绩

        public double Score
        {
            get { return score; }
            set { score = value; }
        }
        private string suggest;//评价

        public string Suggest
        {
            get { return suggest; }
            set { suggest = value; }
        }
        private string type;//考试类型:补考，正考

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        private string year;//学年

        public string Year
        {
            get { return year; }
            set { year = value; }
        }

        private string term;//学期：春秋

        public string Term
        {
            get { return term; }
            set { term = value; }
        }

        private string state;//状态：待审核，审核未过，审核已过

        public string State
        {
            get { return state; }
            set { state = value; }
        }






    }
}
