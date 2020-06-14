using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CuaHangBanMayTInh.Models.Tool;
using System.Web.Mvc;

namespace CuaHangBanMayTInh.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        

        public ActionResult Login()
        {
            Session["username"] = null;
            return View();
        }
        [HttpPost,ActionName("Login")]
        public ActionResult Login(string username,string password)
        {
            Customer tool_user = new Customer();
            if (tool_user.checkLogin(username, password))
            {
                Session["username"] = username;
                return RedirectToAction("Index","Shop");
            }
            return View();
        }
    }
}