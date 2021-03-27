using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task_Invoices.Models;

namespace Task_Invoices.Controllers
{
    public class MainController : Controller
    {
        DBContext db = new DBContext();
        // GET: Main
        public ActionResult Index( int id,string Name)
        {
            ViewBag.role = id;
            ViewBag.search = Name;
            ViewBag.user = db.TUsers.Where(n => n.FullName == Name).ToList();
            ViewBag.Name = db.TUsers.Where(n => n.ID == id).SingleOrDefault();
            List<TUser> users = db.TUsers.ToList();
            return View(users);
        }
        [HttpPost]
        public ActionResult Index(TUser user)
        {

            return RedirectToAction("Index", new { id = user.ID ,Name=user.FullName});
        }
        public ActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddUser(TUser user)
        {
            TUser u = new TUser()
            {
                FullName = user.FullName,
                UserName = user.UserName,
                Email = user.Email,
                Phone = user.Phone,
                Password = user.Password
            };
            db.TUsers.Add(u);
            db.SaveChanges();

            Session["reload"] = "reload";
            return RedirectToAction("Index",new { id=1});
        }
        public ActionResult EditUser(int id)
        {
            TUser user = db.TUsers.Where(n => n.ID == id).SingleOrDefault();
            return View(user);
        }
        [HttpPost]
        public ActionResult EditUser(TUser user)
        {
            TUser u = db.TUsers.Where(n => n.ID == user.ID).SingleOrDefault();
            u.FullName = user.FullName;
            u.UserName = user.UserName;
            u.Email = user.Email;
            u.Phone = user.Phone;
            db.SaveChanges();

            Session["reload"] = "reload";
            return RedirectToAction("Index", new { id = 1 });
        }
        public ActionResult DeleteUser(int id)
        {
            TUser user = db.TUsers.Where(n => n.ID == id).SingleOrDefault();
            db.TUsers.Remove(user);
            db.SaveChanges();

            return RedirectToAction("Index", new { id = 1 });
        }
    }
}