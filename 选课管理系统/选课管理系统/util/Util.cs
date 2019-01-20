using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;


namespace 选课管理系统.util
{
    class Util
    {
        public static MySqlConnection conn;
        public static string sqlcon = "server=localhost;user id=root;password=root;database=xuanke;port=3307";
        //建立数据库连接
        public static MySqlConnection getConn()
        {
            conn = new MySqlConnection(sqlcon);
            conn.Open();
            
            return conn;
        }

        

        //关闭数据库
        public void CloseConn()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
                conn.Dispose();

            }
        }

       

    }
}
