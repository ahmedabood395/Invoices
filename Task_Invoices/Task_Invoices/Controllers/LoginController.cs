using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Task_Invoices.Models;

namespace Task_Invoices.Controllers
{
    public class LoginController : Controller
    {
        DBContext db = new DBContext();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(TUser user,string role)
        {
            TUser u= db.TUsers.Where(n => n.UserName == user.UserName && n.Password == user.Password).SingleOrDefault();
            if(user.UserName== "ahmedmagdy15"&&user.Password== "123"&&role=="Admin")
            {
                return RedirectToAction("Index", "Main",new { id = 1 });
            }
            else if(u!=null && role == "User")
            {
                return RedirectToAction("Index", "Main", new { id = u.ID });
            }
            else if(u != null && role == "Admin")
            {
                ViewBag.mess = "You Are Not Admin";
                return View();
            }
            else
            {
                 ViewBag.mess = "incorrect username or password";
                return View();
            }
        }
        public ActionResult register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult register(TUser user)
        {
            TUser u = new TUser()
            {
                FullName=user.FullName,
                UserName=user.UserName,
                Email=user.Email,
                Password=user.Password,
                Phone=user.Phone
            };
            db.TUsers.Add(u);
            db.SaveChanges();
            return RedirectToAction("Index", "Main",new { id = u.ID });
        }
        //public ActionResult ChangeLang()
        //{

        //    if (Thread.CurrentThread.CurrentCulture.Name == "en-US")
        //    {
        //        Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("ar-AR");
        //        ViewBag.CultBtn = "En";
        //    }
        //    else
        //    {
        //        Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        //        ViewBag.CultBtn = "AR";
        //    }

        //    Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

        //    HttpContext.Current.Session["culture"] = Thread.CurrentThread.CurrentCulture.Name;
        //    return View();
        //}
    }
}