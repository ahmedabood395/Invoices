using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task_Invoices.Models;

namespace Task_Invoices.Controllers
{
    public class InvoicesController : Controller
    {
        DBContext db = new DBContext();
        // GET: Invoices
        public ActionResult Display(int id)
        {
            ViewBag.role = id;
            List<Invoice> inv = db.Invoices.Where(n=>n.Id_User==id).ToList();
            return View(inv);
        }
        public ActionResult Create(int id)
        {
            ViewBag.Id = id;

            if (Session["listInvoice"] != null)
            {
                ViewBag.data = Session["listInvoice"];
            }
            else
            {
                ViewBag.data = null;
            }

            return View();
        }
        [HttpPost]
        public ActionResult Create(Invoice inv)
        {
            List<ListInvoice> lstinv = new List<ListInvoice>();
            if(Session["listInvoice"] !=null)
                lstinv = (List<ListInvoice>)Session["listInvoice"];

            ListInvoice invoic = new ListInvoice()
            {
                Product = inv.Product,
                Quantity = inv.Quantity,
                Price = inv.Price
            };

            lstinv.Add(invoic);

            Session["listInvoice"]=lstinv;

            return RedirectToAction("Create",new { id = inv.Id_User });
        }
        public ActionResult SaveDB(int id)
        {
            List<ListInvoice> lstinv = new List<ListInvoice>();
            lstinv = (List<ListInvoice>)Session["listInvoice"];
            foreach (var item in lstinv)
            {
                Invoice inv = new Invoice()
                {
                    Product=item.Product,
                    Quantity=item.Quantity,
                    Price=item.Price,
                    Id_User=id
                };
                db.Invoices.Add(inv);
                db.SaveChanges();
            }
            Session["listInvoice"] = null;
            Session["relo"] = "reload";

            return RedirectToAction("Display", new { id = id });
        }
    }
}