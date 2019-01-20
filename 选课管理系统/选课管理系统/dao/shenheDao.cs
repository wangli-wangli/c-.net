using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;//链接数据库需导的包
using MySql.Data.MySqlClient;
using 选课管理系统.util;
using 选课管理系统.model;
namespace 选课管理系统.dao
{
    class shenheDao
    {
        public List<Course> find_courses()//查询所有课程
        {
            MySqlConnection conn = Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;

            List<Course> cours = new List<Course>();

            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM course";
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {

                    model.Course course = new Course();
                    course.Course_num = dataReader.GetString("Course_num");
                    course.Course_name = dataReader.GetString("Course_name");
                    course.Credit_hour = dataReader.GetString("credit_hour");
                    course.Type = dataReader.GetString("type");
                    course.Address = dataReader.GetString("address");
                    course.Time_week = dataReader.GetString("time_week");
                    course.Time_jie = dataReader.GetString("time_jie");
                    course.Academy = dataReader.GetString("academy");
                    course.Maxcount = dataReader.GetInt16("maxcount");
                    course.Teacher_num = dataReader.GetString("teacher_num");
                    cours.Add(course);

                }
            }
            catch (Exception)
            {
            }
            finally
            {
                if (!dataReader.IsClosed)
                {
                    dataReader.Close();
                }
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return cours;
        }
        public  Student find_student(string student_num)//根据学号查询学生信息
        {
            MySqlConnection conn = Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            model.Student student = new Student();

            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM student where student_num='" + student_num + "'";
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {
                    student.Student_num = dataReader.GetString("student_num");
                    student.Student_name = dataReader.GetString("student_name");
                    student.Student_academy = dataReader.GetString("student_academy");
                    student.Student_grade = dataReader.GetString("student_grade");
                    student.Classs = dataReader.GetString("classs");
                    student.Profession = dataReader.GetString("profession");
                    student.Id_number = dataReader.GetString("id_number");
                    student.Password = dataReader.GetString("password");
                    student.Sex = dataReader.GetString("sex");

                }
            }
            catch (Exception)
            {
            }
            finally
            {
                if (!dataReader.IsClosed)
                {
                    dataReader.Close();
                }
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return student;
        }
        public  Course find_course(string Course_name)
        {
            MySqlConnection conn = Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            model.Course course = new Course();

            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM course where Course_name='" + Course_name + "'";
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {
                    course.Course_num = dataReader.GetString("Course_num");
                    course.Course_name = dataReader.GetString("Course_name");
                    course.Credit_hour = dataReader.GetString("credit_hour");
                    course.Type = dataReader.GetString("type");
                    course.Address = dataReader.GetString("address");
                    course.Time_week = dataReader.GetString("time_week");
                    course.Time_jie = dataReader.GetString("time_jie");
                    course.Academy = dataReader.GetString("academy");
                    course.Maxcount = dataReader.GetInt16("maxcount");
                    course.Teacher_num = dataReader.GetString("teacher_num");
                    Console.Write(course.Course_name);
                }
            }
            catch (Exception)
            {
                
            }
            finally
            {
                if (!dataReader.IsClosed)
                {
                    dataReader.Close();
                }
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return course;
        }
        public static void update(string number, string state)//修改学生信息
        {
            MySqlConnection conn = Util.getConn();
            MySqlCommand command = null;
            try
            {
                command = conn.CreateCommand();
                string sql = "update result set state='" + state + "' where result_num='" +
               number + "'";


                Console.Write("sql:" + sql);
                command.CommandText = sql;

                command.ExecuteNonQuery();
                Console.WriteLine();

            }
            catch (Exception)
            {
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        
        public List<Result> selectAll1(string number)
        {
            MySqlConnection conn = util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            Result r = null;
            List<Result> rs = new List<model.Result>();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT result_num,student_num,course_num,state FROM result where course_num='" + number + "'";
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {
                    r = new Result();
                    r.Result_num = dataReader.GetString(0);
                    r.Student_num = dataReader.GetString(1);
                    r.Course_num = dataReader.GetString(2);
                    r.State = dataReader.GetString(3);
                    rs.Add(r);

                }
            }
            catch (Exception)
            {

            }
            finally
            {
                if (!dataReader.IsClosed)
                {
                    dataReader.Close();
                }
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return rs;
        }
        public int selectAll2(string number)
        {
            MySqlConnection conn = util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            Result r = null;
            List<Result> rs = new List<model.Result>();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT count(*) from result where course_num='" + number + "' and state='" +"审核已通过"+ "' ";
                dataReader = command.ExecuteReader();

                Console.WriteLine(command.CommandText);
                while (dataReader.Read())
                {
                    Console.Write(dataReader.GetInt16(0));
                    return dataReader.GetInt16(0);

                }

            }
            catch (Exception)
            {

            }
            finally
            {
               
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return 0;
        }
    }
    }
