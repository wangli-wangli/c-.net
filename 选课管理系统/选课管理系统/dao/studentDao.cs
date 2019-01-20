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
    class studentDao//对user进行的数据库操作
    {
     
        public static string find_password(string student_num)//查询出登录者的密码
        {
            MySqlConnection conn = Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            string password=null;
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT password FROM student where student_num=" + student_num;
                dataReader = command.ExecuteReader();
                Console.WriteLine();

                while (dataReader.Read())
                {
                    password = dataReader.GetString(0);
                   

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
            return password;
        } 
        //添加一条学生信息
          //
        public static bool add_student(model.Student student)
        {
            MySqlConnection conn = Util.getConn();
            MySqlCommand command;
           
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "INSERT INTO student(student_num,student_name,student_academy,student_grade,password,sex,profession,id_number,classs) VALUES('"
                    + student.Student_num + "','" + student.Student_name + "','" +
                        student.Student_academy + "','" + student.Student_grade + "','" +
                             student.Password + "','" + student.Sex + "','" +
                              student.Profession + "','" + student.Id_number + "','"+
                                 student.Classs+"')";
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
        public static string find_num()//查询出登录者的密码
        {
            MySqlConnection conn = Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            string num = null;
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT max(student_num) FROM student";
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
        public static List<Student> find_students()//查询所有学生
        {
            MySqlConnection conn = Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
          
            List<Student> studs = new List<Student>(); 
            
            string num = null;
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM student";
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {
                    
                    model.Student student=new Student();
                     student.Student_num=dataReader.GetString("student_num");
                     student.Student_name=dataReader.GetString("student_name");
                     student.Student_academy=dataReader.GetString("student_academy");
                     student.Student_grade=dataReader.GetString("student_grade");
                     student.Classs=dataReader.GetString("classs");
                     student.Profession= dataReader.GetString("profession");
                     student.Id_number = dataReader.GetString("id_number");
                     student.Password= dataReader.GetString("password");
                     student.Sex=dataReader.GetString("sex");
                     studs.Add(student);
                     
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

        public static List<Student> find_students2(Student s)//根据条件查询
        {
            MySqlConnection conn = Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;

            List<Student> studs = new List<Student>();

            string num = null;
            try
            {
                command = conn.CreateCommand();
               string sql="SELECT * FROM student where";
               bool shuru=false;//sql语句中是否已添加条件
               if (s.Student_num != "")
                {
                    sql = sql + "  student_num='" + s.Student_num + "' ";
                    shuru=true;
                }
               if (s.Student_name != "")
                {
                    if (shuru == true) sql = sql + "  and  ";
                    sql = sql + "  student_name='" + s.Student_name + "' ";
                    shuru = true;
                }
               if (s.Student_grade != "")
                {
                    if (shuru == true) sql = sql + "  and  ";
                    sql = sql + "  student_grade='" + s.Student_grade + "' ";
                    shuru = true;
                }
               if (s.Student_academy != "")
                {
                    if (shuru == true) sql = sql + "  and  ";
                    sql = sql + "  student_academy='" + s.Student_academy + "' ";
                    shuru = true;
                }
               if (s.Profession != "")
                {
                    if (shuru == true) sql = sql + "  and  ";
                    sql = sql + "  profession='" + s.Profession + "' ";
                    shuru = true;
                }
               if (s.Classs != "")
                {
                    if (shuru == true) sql = sql + "  and  ";
                    sql = sql + "  classs='" + s.Classs + "' ";
                    shuru = true;
                }
                Console.Write("sql:" + sql);
                command.CommandText =sql;
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {

                    model.Student student = new Student();
                    student.Student_num = dataReader.GetString("student_num");
                    student.Student_name = dataReader.GetString("student_name");
                    student.Student_academy = dataReader.GetString("student_academy");
                    student.Student_grade = dataReader.GetString("student_grade");
                    student.Classs = dataReader.GetString("classs");
                    student.Profession = dataReader.GetString("profession");
                    student.Id_number = dataReader.GetString("id_number");
                    student.Password = dataReader.GetString("password");
                    student.Sex = dataReader.GetString("sex");
                    studs.Add(student);

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
        public static void delete(string num)//管理员删除学生
        {
            MySqlConnection conn = Util.getConn();
            MySqlCommand command = null;
            try
            {
                command = conn.CreateCommand();
                string sql = "delete from student where student_num='"+num+"'";
               
               
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
        public static Student find_student(string student_num)//根据学号查询学生信息
        {
            MySqlConnection conn = Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            model.Student student = new Student();
           
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM student where student_num='"+student_num+"'";
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
        public static void update(Student s)//修改学生信息
        {
            MySqlConnection conn = Util.getConn();
            MySqlCommand command = null;
            try
            {
                command = conn.CreateCommand();
                string sql = "update student set student_name='"+s.Student_name+"',student_academy='"+
                    s.Student_academy+"',student_grade='"+s.Student_grade+"',password='"+s.Password+"',profession='"+
                s.Profession + "',id_number='" + s.Id_number + "',classs='" + s.Classs + "' where student_num='"+
                s.Student_num+"'";


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

        public static List<string> find_classs(string academy)//根据院名查询出所有的班级
        {
            MySqlConnection conn = Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            model.Student student = new Student();
            List<string> classs = new List<string>(); ;//一共有18个学院
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "select distinct classs from student where student_academy='" + academy + "'";
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {
                    string class1 = dataReader.GetString("classs");
                    classs.Add(class1);
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
            return classs;
        }
        public static List<string> find_academys()//根据院名查询出所有的学院
        {
            MySqlConnection conn = Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            model.Student student = new Student();
            List<string> classs = new List<string>(); ;//一共有18个学院
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "select distinct student_academy from student ";
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {
                    string student_academy = dataReader.GetString("student_academy");
                    classs.Add(student_academy);
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
            return classs;
        }

        public static int find_classCount()//查出班级的总个数
        {
            MySqlConnection conn = Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            model.Student student = new Student();
            int count = 0;//一共有18个学院
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "select count(distinct classs) from student ";
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

        public static List<string> find_studentNums(List<string> classs)//查询所有学生
        {
            MySqlConnection conn = Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;

            List<string> stud_nums = new List<string>();

            string num = null;
            try
            {
                foreach (string c in classs)
                {
                    command = conn.CreateCommand();
                    command.CommandText = "SELECT student_num FROM student where classs='" + c + "'";
                    dataReader = command.ExecuteReader();
                    Console.WriteLine();
                    while (dataReader.Read())
                    {

                        string s_n = dataReader.GetString("student_num");
                        stud_nums.Add(s_n);

                    }
                    if (!dataReader.IsClosed)
                    {
                        dataReader.Close();
                    }
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
            return stud_nums;
        }

        //根据学生编号查询学生信息
        public List<Student> selectStudent(List<Result> student)
        {
            MySqlConnection conn = util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;

            List<Student> sts = new List<Student>();
            Console.WriteLine("list:" + student.Count);
            try
            {
                foreach (Result s1 in student)
                {
                    command = conn.CreateCommand();
                    string sql = "SELECT student_name,id_number,sex,student_academy,profession,student_grade,classs FROM student where student_num='" + s1.Student_num + "'";
                    Console.WriteLine(sql);
                    command.CommandText = sql;
                    dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {

                        Student s = new Student();

                        s.Student_name = dataReader.GetString("student_name");

                        s.Student_academy = dataReader.GetString("student_academy");

                        s.Student_grade = dataReader.GetString("student_grade");

                        s.Sex = dataReader.GetString("sex");

                        s.Profession = dataReader.GetString("profession");

                        s.Id_number = dataReader.GetString("id_number");

                        s.Classs = dataReader.GetString("classs");

                        sts.Add(s);

                    }
                    if (!dataReader.IsClosed)
                    {
                        dataReader.Close();
                    }

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

            return sts;
        }

        //根据学号查询学生信息
        public Student selectNum(string number)
        {
            MySqlConnection conn = util.Util.getConn();
            MySqlDataReader dataReader = null;
            MySqlCommand command = null;
            Student r = new Student();
            try
            {
                command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM student where student_num ='" + number + "'";
                Console.WriteLine("aasql:" + command.CommandText);
                dataReader = command.ExecuteReader();
                Console.WriteLine();
                while (dataReader.Read())
                {
                    r.Student_num = dataReader.GetString("student_num");
                    r.Student_name = dataReader.GetString("student_name");
                   
                    r.Sex = dataReader.GetString("sex");
                    Console.WriteLine(r.Student_num + "a  " + r.Student_name + "   " + r.Sex);
                    
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


