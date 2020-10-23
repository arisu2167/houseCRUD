using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using houseCRUD;

namespace houseCRUD.Controllers
{
    public class CCustomerstestController : Controller
    {
        private houseCRUDEntities db = new houseCRUDEntities();

        // GET: CCustomerstest
        public ActionResult Index()
        {
            return View(db.tCustomers.ToList());
        }

        // GET: CCustomerstest/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tCustomer tCustomer = db.tCustomers.Find(id);
            if (tCustomer == null)
            {
                return HttpNotFound();
            }
            return View(tCustomer);
        }

        // GET: CCustomerstest/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CCustomerstest/Create
        // 若要免於大量指派 (overposting) 攻擊，請啟用您要繫結的特定屬性，
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "fCustomerId,fCustomerName,fCustomerBirth,fCustomerGender,fCustomerEmail,fCustomerAddress,fCustomerPhone")] tCustomer tCustomer)
        {
            if (ModelState.IsValid)
            {
                db.tCustomers.Add(tCustomer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tCustomer);
        }

        // GET: CCustomerstest/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tCustomer tCustomer = db.tCustomers.Find(id);
            if (tCustomer == null)
            {
                return HttpNotFound();
            }
            return View(tCustomer);
        }

        // POST: CCustomerstest/Edit/5
        // 若要免於大量指派 (overposting) 攻擊，請啟用您要繫結的特定屬性，
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "fCustomerId,fCustomerName,fCustomerBirth,fCustomerGender,fCustomerEmail,fCustomerAddress,fCustomerPhone")] tCustomer tCustomer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tCustomer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tCustomer);
        }

        // GET: CCustomerstest/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tCustomer tCustomer = db.tCustomers.Find(id);
            if (tCustomer == null)
            {
                return HttpNotFound();
            }
            return View(tCustomer);
        }

        // POST: CCustomerstest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tCustomer tCustomer = db.tCustomers.Find(id);
            db.tCustomers.Remove(tCustomer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
