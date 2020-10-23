using houseCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace houseCRUD.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult CustomerData()
        {
            var customerdata = CCustomerFactory.fn顧客查詢().ToList();
            return View(customerdata);
        }

        public ActionResult CustomerCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CustomerCreate(CCustomer c)
        {
            List<CCustomer> lsCustomers = CCustomerFactory.fn顧客查詢();
            CCustomer ccustomer = lsCustomers.FirstOrDefault(m => m.fCustomerEmail == c.fCustomerEmail);

            CCustomerFactory.fn顧客新增(c);
            ViewBag.message = "新增成功";
            return View();


        }
        public ActionResult CustomerEdit(CCustomer n)
        {
            //int id = Convert.ToInt32(fCustomerId);
            //List<CCustomer> lsCustomers = CCustomerFactory.fn顧客查詢();
            //CCustomer ccustomer = lsCustomers.FirstOrDefault(m => m.fCustomerId == n.fCustomerId);
            //var cus=db.tcus

            return View();
        }
        [HttpPost]
        public ActionResult CustomerEdit(CCustomerEditor c)
        {
            List<CCustomer> lsCustomers = CCustomerFactory.fn顧客查詢();
            CCustomer ccustomer = lsCustomers.FirstOrDefault(m => m.fCustomerId == c.fCustomerId);
            var data = "";
            if (ccustomer != null)
            {
                ccustomer.fCustomerName = c.fCustomerName;
                ccustomer.fCustomerBirth = c.fCustomerBirth;
                ccustomer.fCustomerGender = c.fCustomerGender;
                ccustomer.fCustomerEmail = c.fCustomerEmail;
                ccustomer.fCustomerAddress = c.fCustomerAddress;
                ccustomer.fCustomerPhone = c.fCustomerPhone;
                CCustomerFactory.fn顧客更新(ccustomer);
                return RedirectToAction("CustomerEdit");
            }
            else
            {                
                return RedirectToAction("CustomerData");
            }           
        }

        public ActionResult CustomerDelete(CCustomer c)
        {
            CCustomerFactory.fn顧客刪除(c);
            return View();
        }
    }
}