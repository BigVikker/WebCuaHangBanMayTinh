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
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Create(string tenKH,string tenDangNhap,string matKhau,string gmail,string SDT)
        {
            Customer customer1 = new Customer();
            customer1.ThemKhachHach(tenKH, tenDangNhap, matKhau, gmail, SDT);
            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            Session["cart"] = null;
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
            if(tool_user.checkManagerment(username,password))
            {
                Session["username"] = username;
                return RedirectToAction("QuanLy", "Admin");
            }
            return View();
        }
    }
}