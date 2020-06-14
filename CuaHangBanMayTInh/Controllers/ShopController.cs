using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CuaHangBanMayTInh.Models.Enites;
using System.Web.Mvc;
using CuaHangBanMayTInh.Models.Tool;
using PagedList;

namespace CuaHangBanMayTInh.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Index(int? page)
        {
            Computer computers = new Computer();
            return View(computers.ToList().ToPagedList(page ?? 1, 6));
        }
    }
}