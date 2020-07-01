using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CuaHangBanMayTInh.Models.Enites;
using CuaHangBanMayTInh.Models.Tool;
using System.IO;
using PagedList.Mvc;
using PagedList;

namespace CuaHangBanMayTInh.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult QuanLy(int? page, string stringFind, string stringFindLoai, string sapXep)
        {
            Model1 db = new Model1();
            var query = "select * from MayTinh ";
            if (stringFind != null && stringFind != "")
            {
                ViewBag.stringFind = stringFind;
                query = query + "where tenMayTinh like '%" + stringFind + "%' ";
            }
            if (stringFindLoai != null && stringFindLoai != "")
            {
                ViewBag.stringFindLoai = stringFindLoai;
                if (stringFind == "" || stringFind == null)
                {
                    query = query + " where maLoai = '" + stringFindLoai + "'";
                }
                else
                {
                    query = query + " and maLoai = '" + stringFindLoai + "'";
                }
            }
            if (sapXep != null && sapXep != "")
            {
                ViewBag.sapXep = sapXep;
                query = query + " order by " + sapXep;

            }
            var list = db.MayTinhs.SqlQuery(query).ToList();
            return View(list.ToPagedList(page ?? 1, 5));
        }
        public ActionResult Create()
        {
            Model1 db = new Model1();
            var list = db.LoaiMayTinhs.ToList();
            return View(list);
        }


        //public ActionResult Add(string idcategory, string description, string name, string amount, string price, HttpPostedFileBase photo)
        //{
        //    var img = Path.GetFileName(photo.FileName);
        //    System.IO.File.Move(photo.FileName, );
        //    Product product = new Product();
        //    product.amount = Int32.Parse(amount);
        //    product.price = Int32.Parse(price);
        //    product.name = name;
        //    product.description = description;
        //    product.idcategory = Int32.Parse(idcategory);
        //    if (ModelState.IsValid)
        //    {
        //        if (photo != null && photo.ContentLength > 0)
        //        {
        //            var path = Path.Combine(Server.MapPath("~/Areas/Admin/Content/Photo/"),
        //                                    System.IO.Path.GetFileName(photo.FileName));
        //            photo.SaveAs(path);

        //            product.photo = photo.FileName;
        //            ProductDao dao = new ProductDao();
        //            dao.Add(product);
        //        }
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        return View(product);
        //    }
        //}


        [HttpPost, ActionName("Create")]
        public ActionResult Create(string tenMayTinh, int Gia, int namSanXuat, string maLoai, HttpPostedFileBase photo)
        {
            Model1 db = new Model1();
            MayTinh mayTinh = new MayTinh();
            mayTinh.tenMayTinh = tenMayTinh;
            mayTinh.Gia = Gia;
            mayTinh.namSanXuat = namSanXuat;
            mayTinh.maLoai = maLoai;
            MayTinh obj_take_id = db.MayTinhs.SqlQuery("select top(1) * from MayTinh order by maMayTinh desc").SingleOrDefault();
            string id = obj_take_id.maMayTinh.ToString();
            id = id.Substring(2);
            int numberID = Int32.Parse(id);
            numberID++;
            id = "MT" + numberID;
            mayTinh.maMayTinh = id;
            if (ModelState.IsValid)
            {
                if (photo != null && photo.ContentLength > 0)
                {
                    string fileName = mayTinh.maMayTinh + ".jpg";
                    var path = Path.Combine(Server.MapPath("~/Content/Photo/"), fileName);
                    photo.SaveAs(path);
                    db.MayTinhs.Add(mayTinh);
                    db.SaveChanges();
                    return RedirectToAction("QuanLy");
                }
            }
            return View();

         }

        public ActionResult Edit(string id)
        {
            Model1 db = new Model1();
            var obj_found = db.MayTinhs.Find(id);
            return View(obj_found);
        }
        [HttpPost, ActionName("Edit")]
        public ActionResult Edit(string id, string tenMayTinh, int Gia, int namSanXuat, string maLoai, HttpPostedFileBase photo)
        {
            Model1 db = new Model1();
            MayTinh mayTinh = db.MayTinhs.Find(id);
            if (mayTinh != null)
            {
                mayTinh.tenMayTinh = tenMayTinh;
                mayTinh.Gia = Gia;
                mayTinh.namSanXuat = namSanXuat;
                mayTinh.maLoai = maLoai;

                if (TryUpdateModel(mayTinh))
                    db.SaveChanges();
                else return View();

                if (photo != null && photo.ContentLength > 0)
                {
                    string path_delete = Path.Combine(Server.MapPath("~/Content/Photo/"), id + ".jpg");
                    System.IO.File.Delete(path_delete);
                    string nameFile = id + ".jpg";
                    var path = Path.Combine(Server.MapPath("~/Content/Photo/"), nameFile);
                    photo.SaveAs(path);

                }
                return RedirectToAction("QuanLy");
            }
            return View();
        }

        public ActionResult Details(string id)
        {
            Model1 db = new Model1();
            var obj_found = db.MayTinhs.Find(id);
            return View(obj_found);
        }
        
        public ActionResult Delete(string id)
        {
            Model1 db = new Model1();
            db.Database.ExecuteSqlCommand("delete MayTinh where maMayTinh = '" + id + "'");
            db.SaveChanges();
            return RedirectToAction("QuanLy");
        }

    }
}