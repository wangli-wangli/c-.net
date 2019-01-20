using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;//链接数据库需导的包
using MySql.Data.MySqlClient;
using 选课管理系统.util;

namespace 选课管理系统.dao
{
    class teacherDao
    {
        public static string find_password(string student_num)//查询出登录者的密码
        {
            MySqlConnection conn = Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            string password = null;
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT password FROM teacher where teacher_num=" + student_num;
                dataReader = command.ExecuteReader();
                Console.WriteLine();

                while (dataReader.Read())
                {
                    password = dataReader.GetString(0);


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
            return password;
        }

        public static string find_password2(string admin_num)//查询出管理员的密码
        {
            MySqlConnection conn = Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            string password = null;
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT password FROM admin where admin_num=" + admin_num;
                dataReader = command.ExecuteReader();
                Console.WriteLine("sql:" + command.CommandText);

                while (dataReader.Read())
                {
                    password = dataReader.GetString(0);


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
            return password;
        }

        //添加老师信息
        public static bool add_teacher(model.Teacher teacher)
        {
            MySqlConnection conn = Util.getConn();
            MySqlCommand command;

            try
            {
                command = conn.CreateCommand();
                command.CommandText = "INSERT INTO teacher(teacher_num,teacher_name,teacher_academy,password,sex,profession,id_number) VALUES('"
                    + teacher.Teacher_num + "','" + teacher.Teacher_name + "','" +
                        teacher.Teacher_academy + "','" +
                             teacher.Password + "','" + teacher.Sex + "','" +
                              teacher.Profession + "','" + teacher.Id_number + "')";
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

        public static List<model.Teacher> find_teachers()//查询所有老师
        {
            MySqlConnection conn = Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;

            List<model.Teacher> tea = new List<model.Teacher>();

            string num = null;
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM teacher";
                dataReader = command.ExecuteReader();
                Console.WriteLine("sql:" + command.CommandText);
                while (dataReader.Read())
                {

                    model.Teacher teacher = new model.Teacher();
                    teacher.Teacher_num = dataReader.GetString("teacher_num");
                    teacher.Teacher_name = dataReader.GetString("teacher_name");
                    teacher.Teacher_academy = dataReader.GetString("teacher_academy");
                    teacher.Profession = dataReader.GetString("profession");
                    teacher.Id_number = dataReader.GetString("id_number");
                    teacher.Password = dataReader.GetString("password");
                    teacher.Sex = dataReader.GetString("sex");
                    tea.Add(teacher);

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
            return tea;
        }

        public static List<model.Teacher> find_teachers2(model.Teacher s)//根据条件老师
        {
            MySqlConnection conn = Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;

            List<model.Teacher> studs = new List<model.Teacher>();

            string num = null;
            try
            {
                command = conn.CreateCommand();
                string sql = "SELECT * FROM teacher where";
                bool shuru = false;//sql语句中是否已添加条件
                if (s.Teacher_num != "")
                {
                    sql = sql + "  teacher_num='" + s.Teacher_num + "' ";
                    shuru = true;
                }
                if (s.Teacher_name != "")
                {
                    if (shuru == true) sql = sql + "  and  ";
                    sql = sql + "  teacher_name='" + s.Teacher_name + "' ";
                }
                if (s.Teacher_academy != "")
                {
                    if (shuru == true) sql = sql + "  and  ";
                    sql = sql + "  teacher_academy like '%" + s.Teacher_academy + "%' ";
                }
                if (s.Profession != "")
                {
                    if (shuru == true) sql = sql + "  and  ";
                    sql = sql + "  profession='" + s.Profession + "' ";
                }
                Console.Write("sql:" + sql);
                command.CommandText = sql;
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {

                    model.Teacher teacher = new model.Teacher();
                    teacher.Teacher_num = dataReader.GetString("teacher_num");
                    teacher.Teacher_name = dataReader.GetString("teacher_name");
                    teacher.Teacher_academy = dataReader.GetString("teacher_academy");
                    teacher.Profession = dataReader.GetString("profession");
                    teacher.Id_number = dataReader.GetString("id_number");
                    teacher.Password = dataReader.GetString("password");
                    teacher.Sex = dataReader.GetString("sex");
                    studs.Add(teacher);

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
            return studs;
        }

        public static void delete(string num)//管理员删除老师
        {
            MySqlConnection conn = Util.getConn();
            MySqlCommand command = null;
            try
            {
                command = conn.CreateCommand();
                string sql = "delete from teacher where teacher_num='" + num + "'";


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
        public static void update(model.Teacher s)//修改学生信息
        {
            MySqlConnection conn = Util.getConn();
            MySqlCommand command = null;
            try
            {
                command = conn.CreateCommand();
                string sql = "update teacher set teacher_name='" + s.Teacher_name + "',teacher_academy='" +
                    s.Teacher_academy + "',password='" + s.Password + "',profession='" +
                s.Profession + "',id_number='" + s.Id_number + "' where teacher_num='" +
                s.Teacher_num + "'";


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

        public static model.Teacher find_teacher(string teacher_num)//根据学号查询学生信息
        {
            MySqlConnection conn = Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            model.Teacher teacher = new model.Teacher();

            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM teacher where teacher_num='" + teacher_num + "'";
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {


                    teacher.Teacher_num = dataReader.GetString("teacher_num");
                    teacher.Teacher_name = dataReader.GetString("teacher_name");
                    teacher.Teacher_academy = dataReader.GetString("teacher_academy");

                    teacher.Profession = dataReader.GetString("profession");
                    teacher.Id_number = dataReader.GetString("id_number");
                    teacher.Password = dataReader.GetString("password");
                    teacher.Sex = dataReader.GetString("sex");
                 

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
            return teacher;
        }
        //姚雅丽
        public model.Teacher selectNum(string number)
        {
            MySqlConnection conn = util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            model.Teacher r = new model.Teacher();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM teacher where teacher_num ='" + number + "'";
                dataReader = command.ExecuteReader();
                Console.WriteLine(command.CommandText);
                while (dataReader.Read())
                {
                    r.Teacher_num = dataReader.GetString(0);
                    r.Teacher_name = dataReader.GetString(1);
                    r.Teacher_academy = dataReader.GetString(2);
                    //r.Question = dataReader.GetString(3);
                    //r.Answer = dataReader.GetString(4);
                    r.Password = dataReader.GetString(3);
                    r.Sex = dataReader.GetString(4);
                    r.Profession = dataReader.GetString(5);
                    r.Id_number = dataReader.GetString(6);
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

        public static string find_num()//查询出登录者的密码
        {
            MySqlConnection conn = Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            string num = null;
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT max(teacher_num) FROM teacher";
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


        //寇肖萌
         public model.Teacher selectNum2(string number)
        {
            MySqlConnection conn = util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            model.Teacher r = new model.Teacher();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM teacher where teacher_num ='" + number + "'";
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
