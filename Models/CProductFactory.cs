using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace houseCRUD.Models
{
    public class CProductFactory
    {
        private static IList reader物件查詢(SqlDataReader reader)
        {
            List<CProduct> lsProduct = new List<CProduct>();//物件列表
            while (reader.Read())//讀取物件資料
            {
                lsProduct.Add(new CProduct()
                {
                    fProductId = (int)reader[CProdcutKey.fProductId],
                    fProductName = (string)reader[CProdcutKey.fProductName],
                    fProductPrice = (int)reader[CProdcutKey.fProductPrice],
                    fProductAddress = (string)reader[CProdcutKey.fProductAddress],
                    fProductExplain = (string)reader[CProdcutKey.fProductExplain],
                    fProductPhoto = reader[CProdcutKey.fProductPhoto] as string//可null
                    
                });
            }
            return lsProduct;//回傳至物件列表
        }
        public static List<CProduct> fn物件查詢()
        {
            string sql = $"EXEC 物件查詢";
            return (List<CProduct>)CDbManager.querySql(sql, null, reader物件查詢);
        }
        public static void fn物件新增(CProduct product)
        {
            string sql = $"EXEC 物件新增 ";
            sql += $"@{CProdcutKey.fProductName},";
            sql += $"@{CProdcutKey.fProductPrice},";
            sql += $"@{CProdcutKey.fProductAddress},";
            sql += $"@{CProdcutKey.fProductExplain},";
            sql += $"@{CProdcutKey.fProductPhoto}";            


            List<SqlParameter> paras = new List<SqlParameter>()
            {
                new SqlParameter(CProdcutKey.fProductName, product.fProductName),
                new SqlParameter(CProdcutKey.fProductPrice, product.fProductPrice),
                new SqlParameter(CProdcutKey.fProductAddress, product.fProductAddress),
                new SqlParameter(CProdcutKey.fProductExplain, product.fProductExplain),
                new SqlParameter(CProdcutKey.fProductPhoto,(object)product.fProductPhoto ?? DBNull.Value)//可null               


            };

            CDbManager.executeSql(sql, paras);
        }

        public static void fn物件更新(CProduct product)
        {
            string sql = $"EXEC 物件更新 ";
            sql += $"@{CProdcutKey.fProductId},";
            sql += $"@{CProdcutKey.fProductName},";
            sql += $"@{CProdcutKey.fProductPrice},";
            sql += $"@{CProdcutKey.fProductAddress},";
            sql += $"@{CProdcutKey.fProductExplain},";
            sql += $"@{CProdcutKey.fProductPhoto}";           



            List<SqlParameter> paras = new List<SqlParameter>()
            {
                new SqlParameter(CProdcutKey.fProductId, product.fProductId),
                new SqlParameter(CProdcutKey.fProductName, product.fProductName),
                new SqlParameter(CProdcutKey.fProductPrice, product.fProductPrice),
                new SqlParameter(CProdcutKey.fProductAddress, product.fProductAddress),
                new SqlParameter(CProdcutKey.fProductExplain, product.fProductExplain),
                new SqlParameter(CProdcutKey.fProductPhoto,(object)product.fProductPhoto ?? DBNull.Value) //可null               


            };

            CDbManager.executeSql(sql, paras);
        }
        public static void fn物件刪除(CProduct product)
        {
            string sql = $"EXEC 物件刪除 ";
            sql += $"@{CProdcutKey.fProductId}";

            List<SqlParameter> paras = new List<SqlParameter>()
            {
                new SqlParameter(CProdcutKey.fProductId, product.fProductId)
            };

            CDbManager.executeSql(sql, paras);
        }
    }
}