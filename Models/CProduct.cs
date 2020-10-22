using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace houseCRUD.Models
{
    public class CProduct
    {
        public int fProductId { get; set; }
        public string fProductName { get; set; }
        public int fProductPrice { get; set; }
        public string fProductAddress { get; set; }
        public string fProductExplain { get; set; }
        public string fProductPhoto { get; set; }
    }
}