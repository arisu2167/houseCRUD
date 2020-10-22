using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace houseCRUD.Models
{
    public class CDbManager
    {
        //private static string _connectionString = ConfigurationManager.ConnectionStrings["Data Source=.;Initial Catalog=houseCRUD;Integrated Security=True"].ConnectionString;
        //提供用戶端應用程式的組態檔存取。 此類別無法獲得繼承。 繼承 Object->ConfigurationManager
       
        public delegate IList DataReader(SqlDataReader reader);

        public static void executeSql(string sql, List<SqlParameter> paras)
        {
            //SqlConnection con = new SqlConnection();
            //con.ConnectionString = @"Data Source=.;Initial Catalog=houseCRUD;Integrated Security=True";
            //con.Open();

            //SqlCommand cmd = new SqlCommand();
            //cmd.Connection = con;
            //cmd.CommandText = sql;
            //if (paras != null)
            //{
            //    foreach (SqlParameter p in paras)
            //    {
            //        cmd.Parameters.Add(p);
            //    }
            //}
            //cmd.ExecuteNonQuery();

            //con.Close();
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString= @"Data Source=.;Initial Catalog=houseCRUD;Integrated Security=True";
                connection.Open();
                //Console.WriteLine("[Info]成功連接資料庫！");

                SqlCommand command = new SqlCommand(sql, connection);
                //Console.WriteLine("[Info]執行的SQL語句為：" + sql);

                if (paras != null)
                {
                    foreach (SqlParameter p in paras)
                    {
                        command.Parameters.Add(p);
                        //Console.WriteLine($"[Info]成功將[{p.ParameterName}]:[{p.Value}]SQL語句參數化！");
                    }
                }

                command.ExecuteNonQuery();
                // Console.WriteLine("[Info]執行SQL成功！");
                connection.Close();
            }
        }

        public static IList querySql(string sql, List<SqlParameter> paras,DataReader dr)
        {
            //SqlConnection con = new SqlConnection();
            //con.ConnectionString = @"Data Source=.;Initial Catalog=houseCRUD;Integrated Security=True";
            //con.Open();

            //SqlCommand cmd = new SqlCommand();
            //cmd.Connection = con;
            //cmd.CommandText = sql;
            //if (paras != null)
            //{
            //    foreach (SqlParameter p in paras)
            //    {
            //        cmd.Parameters.Add(p);
            //    }
            //}

            //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //adapter.Fill(ds);
            //con.Close();
            //return ds.Tables[0];
            IList lsResult;
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Data Source=.;Initial Catalog=houseCRUD;Integrated Security=True";
                connection.Open();
                //Console.WriteLine("[Info]成功連接資料庫！");

                SqlCommand command = new SqlCommand(sql, connection);
                //Console.WriteLine("[Info]查詢的SQL語句為：" + sql);

                if (paras != null)
                {
                    foreach (SqlParameter p in paras)
                    {
                        command.Parameters.Add(p);
                        //Console.WriteLine("[Info]成功將SQL語句參數化！");
                    }
                }

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    lsResult = dr(reader);
                    //Console.WriteLine("[Info]查詢SQL成功！"); 
                }
            }
            return lsResult;
        }
    }
}