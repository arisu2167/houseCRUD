using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace houseCRUD.Models
{
    public class CDbManager
    {
        private static string _dbConnect = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        //public delegate IList
        //test
    }
}