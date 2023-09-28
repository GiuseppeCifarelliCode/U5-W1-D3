using Scarpe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Scarpe.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(DB.getAllVisibleScarpe());
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                User loggedUser = DB.getUserByUsername(user.Username);
                if(loggedUser != null && loggedUser.Password == user.Password)
                {
                    FormsAuthentication.SetAuthCookie(user.Username, false);
                    HttpCookie auth = new HttpCookie("role");
                    auth.Value = loggedUser.Role;
                    Response.Cookies.Add(auth);
                    if (loggedUser.Role == "admin") return RedirectToAction("Index","Admin");
                    else return RedirectToAction("Index");
                } else return View();
            } else return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if(ModelState.IsValid)
            {
                DB.SignIn(user.Name,user.Surname,user.Username,user.Password, user.Role);
                FormsAuthentication.SetAuthCookie(user.Username, false);
                HttpCookie auth = new HttpCookie("role");
                auth.Value = user.Role;
                Response.Cookies.Add(auth);
                return RedirectToAction("Index");
            } else { return View(); }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            HttpCookie auth = new HttpCookie("role");
            auth.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(auth);
            return RedirectToAction("Index");
        }

        public ActionResult Detail(int id)
        {
            Scarpa scarpa = DB.getScarpaById(id);
            return View(scarpa);
        }

    }
}