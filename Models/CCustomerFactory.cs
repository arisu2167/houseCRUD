using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace houseCRUD.Models
{
    public class CCustomerFactory
    {
        private static IList reader顧客查詢(SqlDataReader reader)
        {
            List<CCustomer> lsCustomer = new List<CCustomer>();//顧客表單
            while (reader.Read())//讀取顧客資料
            {
                lsCustomer.Add(new CCustomer()//加入顧客資料
                {
                    fCustomerId = (int)reader[CCustomerKey.fCustomerId],
                    fCustomerName = (string)reader[CCustomerKey.fCustomerName],
                    fCustomerBirth = (DateTime)reader[CCustomerKey.fCustomerBirth],
                    fCustomerGender = (string)reader[CCustomerKey.fCustomerGender],
                    fCustomerEmail = (string)reader[CCustomerKey.fCustomerEmail],
                    fCustomerAddress = (string)reader[CCustomerKey.fCustomerAddress],
                    fCustomerPhone = (string)reader[CCustomerKey.fCustomerPhone]

                });
            }
            return lsCustomer;//回傳顧客列表
        }
        public static List<CCustomer> fn顧客查詢()
        {
            string sql = $"EXEC 顧客查詢";
            return (List<CCustomer>)CDbManager.querySql(sql, null, reader顧客查詢);
        }
        public static void fn顧客新增(CCustomer customer)
        {
            string sql = $"EXEC 顧客新增 ";
            sql += $"@{CCustomerKey.fCustomerName},";
            sql += $"@{CCustomerKey.fCustomerBirth},";
            sql += $"@{CCustomerKey.fCustomerGender},";
            sql += $"@{CCustomerKey.fCustomerEmail},";
            sql += $"@{CCustomerKey.fCustomerAddress},";
            sql += $"@{CCustomerKey.fCustomerPhone}";



            List<SqlParameter> paras = new List<SqlParameter>()
            {
                new SqlParameter(CCustomerKey.fCustomerName, customer.fCustomerName),
                new SqlParameter(CCustomerKey.fCustomerBirth, customer.fCustomerBirth),
                new SqlParameter(CCustomerKey.fCustomerGender, customer.fCustomerGender),
                new SqlParameter(CCustomerKey.fCustomerEmail, customer.fCustomerEmail),
                new SqlParameter(CCustomerKey.fCustomerAddress, customer.fCustomerAddress),
                new SqlParameter(CCustomerKey.fCustomerPhone, customer.fCustomerPhone)




            };

            CDbManager.executeSql(sql, paras);
        }

        public static void fn顧客更新(CCustomer customer)
        {
            string sql = $"EXEC 顧客更新 ";
            sql += $"@{CCustomerKey.fCustomerId},";
            sql += $"@{CCustomerKey.fCustomerName},";
            sql += $"@{CCustomerKey.fCustomerBirth},";
            sql += $"@{CCustomerKey.fCustomerGender},";
            sql += $"@{CCustomerKey.fCustomerEmail},";
            sql += $"@{CCustomerKey.fCustomerAddress},";
            sql += $"@{CCustomerKey.fCustomerPhone}";



            List<SqlParameter> paras = new List<SqlParameter>()
            {
                new SqlParameter(CCustomerKey.fCustomerId, customer.fCustomerId),
                new SqlParameter(CCustomerKey.fCustomerName, customer.fCustomerName),
                new SqlParameter(CCustomerKey.fCustomerBirth, customer.fCustomerBirth),
                new SqlParameter(CCustomerKey.fCustomerGender, customer.fCustomerGender),
                new SqlParameter(CCustomerKey.fCustomerEmail, customer.fCustomerEmail),
                new SqlParameter(CCustomerKey.fCustomerAddress,customer.fCustomerAddress),
                new SqlParameter(CCustomerKey.fCustomerPhone,customer.fCustomerPhone)



            };

            CDbManager.executeSql(sql, paras);
        }
        public static void fn顧客刪除(CCustomer customer)
        {
            string sql = $"EXEC 顧客刪除 ";
            sql += $"@{CCustomerKey.fCustomerId}";

            List<SqlParameter> paras = new List<SqlParameter>()
            {
                new SqlParameter(CCustomerKey.fCustomerId, customer.fCustomerId)
            };

            CDbManager.executeSql(sql, paras);
        }
        //public void delete(CCustomer p)
        //{
        //    string sql = "DELETE FROM tCustomer WHERE fId=" + p.fCustomerId.ToString();
        //    (new CDbManager()).executeSql(sql, null);
        //}
    }
}