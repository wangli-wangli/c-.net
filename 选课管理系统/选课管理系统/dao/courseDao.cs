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
    class courseDao
    {
        //添加一条课程信息
        //
        public static bool add_course(model.Course course)
        {
            MySqlConnection conn = Util.getConn();
            MySqlCommand command;

            try
            {
                command = conn.CreateCommand();
                command.CommandText = "INSERT INTO course(Course_num,Course_name,credit_hour,type,address,time_week,time_jie,academy,maxcount,teacher_num) VALUES('"
                    + course.Course_num + "','" + course.Course_name + "','" +
                       course.Credit_hour + "','" + course.Type + "','" +
                             course.Address + "','" + course.Time_week + "','" +
                             course.Time_jie + "','" + course.Academy + "'," +
                             course.Maxcount + ",'" + course.Teacher_num + "')";
                Console.WriteLine("sql:" + command.CommandText);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return true;

        }
        //查询出最后一条数据的学生学号
        public static string find_num()//查询最大的课程号
        {
            MySqlConnection conn = Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            string num = null;
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT max(course_num) FROM course";
                Console.WriteLine("sql:" + command.CommandText);
                dataReader = command.ExecuteReader();
                Console.WriteLine();

                while (dataReader.Read())
                {
                    num = dataReader.GetString(0);


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
            return num;
        }

        public static List<Course> find_courses()//查询所有课程
        {
            MySqlConnection conn = Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;

            List<Course> cours = new List<Course>();

            string num = null;
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
        public static List<Course> find_courses2(Course s)//根据条件查询
        {
            MySqlConnection conn = Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;

            List<Course> courses = new List<Course>();

            string num = null;
            try
            {
                command = conn.CreateCommand();
                string sql = "SELECT * FROM course where";
                bool shuru = false;//sql语句中是否已添加条件
                if (s.Type != "")
                {
                    sql = sql + "  type='" + s.Type + "' ";
                    shuru = true;
                }
                if (s.Academy != "")
                {
                    if (shuru == true) sql = sql + "  and  ";
                    sql = sql + "  academy='" + s.Academy + "' ";
                    shuru = true;
                }
                if (s.Time_jie != "")
                {
                    if (shuru == true) sql = sql + "  and  ";
                    sql = sql + "  time_jie='" + s.Time_jie + "' ";
                    shuru = true;
                }
                if (s.Time_week != "")
                {
                    if (shuru == true) sql = sql + "  and  ";
                    sql = sql + "  time_week='" + s.Time_week + "' ";
                    shuru = true;
                }
                if (s.Course_num != "")
                {
                    if (shuru == true) sql = sql + "  and  ";
                    sql = sql + "  Course_num='" + s.Course_num + "' ";
                    shuru = true;
                }
                if (s.Course_name != "")
                {
                    if (shuru == true) sql = sql + "  and  ";
                    sql = sql + "  Course_name='" + s.Course_name + "' ";
                    shuru = true;
                }
                Console.Write("sql:" + sql);
                command.CommandText = sql;
                dataReader = command.ExecuteReader();
                Console.WriteLine();
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
                    courses.Add(course);

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
            return courses;
        }

        public static void delete(string num)//管理员删除学生
        {
            MySqlConnection conn = Util.getConn();
            MySqlCommand command = null;
            try
            {
                command = conn.CreateCommand();
                string sql = "delete from course where Course_num='" + num + "'";

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
        public static Course find_course(string Course_num)//根据学号查询学生信息
        {
            MySqlConnection conn = Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            model.Course course = new Course();

            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM course where Course_num='" + Course_num + "'";
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

        public static void update(Course s)//修改学生信息
        {
            MySqlConnection conn = Util.getConn();
            MySqlCommand command = null;
            try
            {
                command = conn.CreateCommand();
                string sql = "update course set Course_name='" + s.Course_name + "',credit_hour='" +
                    s.Credit_hour + "',type='" + s.Type + "',address='" +
                    s.Address + "',time_week='" + s.Time_week + "',time_jie='" + s.Time_jie + "',academy='" +
                s.Academy + "',maxcount=" + s.Maxcount + ",teacher_num='"+s.Teacher_num+"'   where Course_num='" + s.Course_num + "'";
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
        public static List<string> find_academys()//根据院名查询出所有的学院
        {
            MySqlConnection conn = Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            model.Course course = new Course();
            List<string> academys = new List<string>();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "select distinct academy from course ";
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {
                    string academy = dataReader.GetString("academy");
                    academys.Add(academy);
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
            return academys;
        }

        public static List<string> find_courses3(string academy)//根据院名查询出所有的班级
        {
            MySqlConnection conn = Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            List<string> coueses = new List<string>(); ;//一共有18个学院
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "select Course_name,Course_num from course where academy='" + academy + "' and type='必修'";
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {
                    string couese1 = dataReader.GetString("Course_name");
                    string couese2 = dataReader.GetString("Course_num");
                    couese1 = "("+couese2+")"+couese1;
                    coueses.Add(couese1);
                }

                if (!dataReader.IsClosed)
                {
                    dataReader.Close();
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
            return coueses;
        }

        public static int find_countCount()//查出班级的总个数
        {
            MySqlConnection conn = Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            model.Student student = new Student();
            int count = 0;//一共有18个学院
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "select count(Course_name) from course where type='必修'";
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {
                    count = dataReader.GetInt16(0);

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
            return count;
        }

        //姚雅丽
        public Course selectNum(string number)
        {
            MySqlConnection conn = util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            Course r = new Course();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM course where Course_num ='" + number + "'";
                dataReader = command.ExecuteReader();
                Console.WriteLine(command.CommandText);
                while (dataReader.Read())
                {
                    r.Course_num = dataReader.GetString(0);
                    r.Course_name = dataReader.GetString(1);
                    r.Credit_hour = dataReader.GetString(2);
                    r.Type = dataReader.GetString(3);
                    r.Address = dataReader.GetString(4);
                    r.Time_week = dataReader.GetString(5);
                    r.Time_jie = dataReader.GetString(6);
                    r.Academy = dataReader.GetString(7);
                    r.Teacher_num = dataReader.GetString(9);
                    return r;
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
            return null;
        }
        public List<Course> selecttc(string teacher_num)
        {
            MySqlConnection conn = util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            Course r = null;
            List<Course> rs = new List<model.Course>();
            try
            {
                command = conn.CreateCommand();
                string sql = "SELECT * FROM course where teacher_num='" + teacher_num + "'";
                Console.WriteLine("sql:" + sql);
                command.CommandText = sql;
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {
                    r = new Course();
                    r.Course_num = dataReader.GetString(0);
                    r.Course_name = dataReader.GetString(1);
                    r.Credit_hour = dataReader.GetString(2);
                    r.Type = dataReader.GetString(3);
                    r.Address = dataReader.GetString(4);
                    r.Time_week = dataReader.GetString(5);
                    r.Time_jie = dataReader.GetString(6);
                    r.Academy = dataReader.GetString(7);
                    r.Teacher_num = dataReader.GetString(9);
                    Console.WriteLine("aaa:" + dataReader.GetString(0));
                    rs.Add(r);

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
            return rs;
        }




        //寇肖萌部分
        public List<Course> selectNum1(string number)
        {
            MySqlConnection conn = util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            Course r = new Course();
            List<Course> rs = new List<model.Course>();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM course where  teacher_num ='" + number + "'";
                dataReader = command.ExecuteReader();
                Console.WriteLine(command.CommandText);
                while (dataReader.Read())
                {
                    r = new Course();
                    r.Course_num = dataReader.GetString(0);
                    r.Course_name = dataReader.GetString(1);
                    r.Credit_hour = dataReader.GetString(2);
                    r.Type = dataReader.GetString(3);
                    r.Address = dataReader.GetString(4);
                    r.Time_week = dataReader.GetString(5);
                    r.Time_jie = dataReader.GetString(6);
                    r.Academy = dataReader.GetString(7);
                    r.Teacher_num = dataReader.GetString(9);
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

       


    }
}
