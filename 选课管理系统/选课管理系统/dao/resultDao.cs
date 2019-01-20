using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;//链接数据库需导的包
using 选课管理系统.util;
using 选课管理系统.model;


namespace 选课管理系统.dao
{
    class resultDao
    {
        public static bool add_result(model.Result result)
        {
            MySqlConnection conn = Util.getConn();
            MySqlCommand command;

            try
            {
                command = conn.CreateCommand();
                command.CommandText = "INSERT INTO result(student_num,course_num,year,term,state) VALUES('"
                    + result.Student_num + "','" + result.Course_num + "','" +
                        result.Year + "','" + result.Term + "','审核已通过')";
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
        //根据课程号查询学生号
        public List<Result> selectStudent(string course_num, string year, string term)
        {
            MySqlConnection conn = util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            Result r = null;
            List<Result> rs = new List<model.Result>();
            try
            {
                command = conn.CreateCommand();
                string sql = "SELECT student_num FROM result where course_num='" + course_num + "' and year='" + year + "' and term='" + term + "' and state='审核已通过'" ;
                Console.WriteLine(sql);
                command.CommandText = sql;
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    r = new Result();
                    r.Student_num = dataReader.GetString(0);
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

        //姚雅丽代码部分
        public List<Result> selectAll(string number, string year, string term)
        {
            MySqlConnection conn = util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            Result r = null;
            List<Result> rs = new List<model.Result>();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM result where student_num='" + number + "' and year='" + year + "' and term='" + term + "'";
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {
                    r = new Result();
                    r.Result_num = dataReader.GetString(0);
                    r.Student_num = dataReader.GetString(1);
                    //r.Teacher_num = dataReader.GetString(2);
                    r.Course_num = dataReader.GetString(2);
                    r.Score = dataReader.GetDouble(3);
                    r.Type = dataReader.GetString(4);
                    r.Year = dataReader.GetString(5);
                    r.Term = dataReader.GetString(6);

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
        //查询未通过课程
        public List<Result> select1(string s_num, string year, string term)
        {
            MySqlConnection conn = util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            Result r = null;
            List<Result> rs = new List<model.Result>();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM result where score<60 and year='" + year + "' and term='" + term + "'";
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {
                    r = new Result();
                    r.Result_num = dataReader.GetString(0);
                    r.Student_num = dataReader.GetString(1);
                    //r.Teacher_num = dataReader.GetString(2);
                    r.Course_num = dataReader.GetString(2);
                    r.Score = dataReader.GetDouble(3);
                    r.Type = dataReader.GetString(4);
                    r.Year = dataReader.GetString(5);
                    r.Term = dataReader.GetString(6);

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
        //查询最高分
        public List<Result> select2(string s_num, string year, string term)
        {
            MySqlConnection conn = util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            Result r = null;
            List<Result> rs = new List<model.Result>();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM result where score=(select max(score) from result) and year='" + year + "' and term='" + term + "' and student_num='" + s_num + "'";
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {
                    r = new Result();
                    r.Result_num = dataReader.GetString(0);
                    r.Student_num = dataReader.GetString(1);
                    //r.Teacher_num = dataReader.GetString(2);
                    r.Course_num = dataReader.GetString(2);
                    r.Score = dataReader.GetDouble(3);
                    r.Type = dataReader.GetString(4);
                    r.Year = dataReader.GetString(5);
                    r.Term = dataReader.GetString(6);

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
        public List<Result> select3(string s_num, string year, string term)
        {
            MySqlConnection conn = util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            Result r = null;
            List<Result> rs = new List<model.Result>();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM result where score=(select max(score) from result) and year='" + year + "' and term='" + term + "' and student_num='" + s_num + "' and score<60";
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {
                    r = new Result();
                    r.Result_num = dataReader.GetString(0);
                    r.Student_num = dataReader.GetString(1);
                    //r.Teacher_num = dataReader.GetString(2);
                    r.Course_num = dataReader.GetString(2);
                    r.Score = dataReader.GetDouble(3);
                    r.Type = dataReader.GetString(4);
                    r.Year = dataReader.GetString(5);
                    r.Term = dataReader.GetString(6);

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
        public List<Result> selectTeacher(string teacher_num)
        {
            MySqlConnection conn = util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            Result r = null;
            List<Result> rs = new List<model.Result>();
            try
            {
                command = conn.CreateCommand();
                string sql = "SELECT * FROM result where teacher_num='" + teacher_num + "'";
                Console.WriteLine("sql:" + sql);
                command.CommandText = sql;
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {
                    r = new Result();
                    r.Result_num = dataReader.GetString(0);

                    r.Student_num = dataReader.GetString("student_num");
                    //r.Teacher_num = dataReader.GetString(2);
                    r.Course_num = dataReader.GetString("course_num");
                    //r.Score = dataReader.GetDouble(4);
                    //r.Type = dataReader.GetString(5);
                    r.Year = dataReader.GetString("year");
                    r.Term = dataReader.GetString("term");
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
        //根据课程号查询成绩表
        public List<Result> selectResult(string course_num)
        {
            MySqlConnection conn = util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            Result r = null;
            List<Result> rs = new List<model.Result>();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM result where course_num='" + course_num + "' and state='审核已通过' and score is null";
                Console.WriteLine(command.CommandText);
                dataReader = command.ExecuteReader();
                Console.WriteLine(dataReader);
                while (dataReader.Read())
                {
                    r = new Result();
                    r.Result_num = dataReader.GetString(0);
                    r.Student_num = dataReader.GetString("student_num");
                    //r.Teacher_num = dataReader.GetString(2);
                    r.Course_num = dataReader.GetString("course_num");
                    //r.Score = dataReader.GetDouble(4);
                    //r.Type = dataReader.GetString(5);
                    r.Year = dataReader.GetString("year");
                    r.Term = dataReader.GetString("term");

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

        //修改成绩
        public void updateScore(string student_num, string course_num, string type, double score)
        {
            MySqlConnection conn = util.Util.getConn();
            MySqlCommand command;
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "update result set score=" + score + ", type='" + type + "' where student_num='" + student_num + "' and course_num='" + course_num + "'";
                Console.Write(command.CommandText);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                Console.WriteLine("添加失败！");
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        
        //寇肖萌
        public List<Result> selectAll1(string number, string year, string term)
        {
            MySqlConnection conn = util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            Result r = null;
            List<Result> rs = new List<model.Result>();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM result where student_num='" + number + "' and year='" + year + "' and term='" + term + "'and state='审核已通过'";
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {
                    r = new Result();
                    r.Result_num = dataReader.GetString(0);
                    r.Student_num = dataReader.GetString(1);
                   // r.Teacher_num = dataReader.GetString(2);
                    r.Course_num = dataReader.GetString(2);
                  
                    r.Year = dataReader.GetString(5);
                    r.Term = dataReader.GetString(6);

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
        public List<Result> selectAll2(string year, string term)
        {
            MySqlConnection conn = util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            Result r = null;
            List<Result> rs = new List<model.Result>();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM result where year='" + year + "' and term='" + term + "'";
                dataReader = command.ExecuteReader();
                Console.WriteLine(command.CommandText);
                while (dataReader.Read())
                {
                    r = new Result();
                    r.Result_num = dataReader.GetString(0);
                    r.Student_num = dataReader.GetString(1);
                   
                    r.Course_num = dataReader.GetString(2);
                   
                    r.Year = dataReader.GetString(5);
                    r.Term = dataReader.GetString(6);

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
       
        public Course selectNum1(string number)
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

        public Teacher selectNum2(string number)
        {
            MySqlConnection conn = util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            Teacher r = new Teacher();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM teacher where Teacher_num ='" + number + "'";
                dataReader = command.ExecuteReader();
                Console.WriteLine(command.CommandText);
                while (dataReader.Read())
                {
                    r.Teacher_num = dataReader.GetString(0);
                    r.Teacher_name = dataReader.GetString(1);

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

    }
}
