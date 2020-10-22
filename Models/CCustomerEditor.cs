using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace houseCRUD.Models
{
    public class CCustomerEditor
    {
        public int fCustomerId { get; set; }
        public string fCustomerName { get; set; }
        public DateTime fCustomerBirth { get; set; }
        public string fCustomerGender { get; set; }
        public string fCustomerEmail { get; set; }
        public string fCustomerAddress { get; set; }
        public string fCustomerPhone { get; set; }
    }
}