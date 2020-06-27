using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CuaHangBanMayTInh.Models.Enites;
using System.Web.Mvc;
using CuaHangBanMayTInh.Models.Tool;
using PagedList;
using System.IO;
namespace CuaHangBanMayTInh.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop


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
            if(ModelState.IsValid)
            {
                if(photo != null && photo.ContentLength > 0)
                {
                    string fileName = mayTinh.maMayTinh+".jpg";
                    var path = Path.Combine(Server.MapPath("~/Content/Photo/"),fileName);
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
        public ActionResult Edit( string id , string tenMayTinh, int Gia, int namSanXuat, string maLoai, HttpPostedFileBase photo)
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
                    string path_delete = Path.Combine(Server.MapPath("~/Content/Photo/"),id+".jpg");
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
        public ActionResult Index(int? page,string stringFind)
        {
            Computer computers = new Computer();
            if (stringFind != null)
            {
                ViewBag.stringFind = stringFind;
                return View(computers.FindToMayTinh(stringFind).ToPagedList(page ?? 1, 6));
            }
            return View(computers.ToList().ToPagedList(page ?? 1, 7));
        }
        public ActionResult Delete(string id)
        {
            Model1 db = new Model1();
            db.Database.ExecuteSqlCommand("delete MayTinh where maMayTinh = '"+id+"'");
            db.SaveChanges();
            return RedirectToAction("QuanLy");
        }
        public ActionResult QuanLy(int ? page, string stringFind, string stringFindLoai, string sapXep)
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
                query = query + " order by "+sapXep ;
                
            }
            var list = db.MayTinhs.SqlQuery(query).ToList();
            return View(list.ToPagedList(page ?? 1,5));
        }
        public ActionResult Cart()
        {
            var l = new List<GioHang>();
            if (Session["cart"] != null)
            {
                l = (List<GioHang>)Session["cart"];

            }
            return View(l);
            
        }
        public ActionResult AddToCart(string id,string donGia)
        {
            //Model1 db = new Model1();
            //db.Database.ExecuteSqlCommand("asdadad");
            var gio = new List<GioHang>();
            if (Session["cart"] == null)
            {
                GioHang gioHang_add1 = new GioHang(id, 1, Int64.Parse(donGia));
                gio.Add(gioHang_add1);
                Session["cart"] = gio;
            }

            else
            {
                gio = (List<GioHang>)Session["cart"];
                bool check = false;
                foreach(var item in gio)
                {
                    if(item.maGioHang == id)
                    {
                        check = true;
                        item.soLuong++;
                        break;
                    }
                }
                if(check == false) { 
                GioHang gioHang = new GioHang(id, 1, Int64.Parse(donGia));
                gio.Add(gioHang);
                }
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult EditCart(string id,int soLuong)
        {
            
            var gio = new List<GioHang>();
            gio = (List<GioHang>)Session["cart"];
            if (soLuong <= 0)
            {
                var gioHang = gio.Find(x => x.maGioHang == id);
                gio.Remove(gioHang);
            }
            else
                foreach (var item in gio)
                {
                    if (item.maGioHang == id)
                    {
                        item.soLuong = soLuong;
                    }
                }
            return RedirectToAction("Cart");
        }
        public ActionResult XacNhanGioHang()
        {
            if(Session["username"] == null)
            {
                return RedirectToAction("Login","Home");
            }
            else
            {
                Model1 db = new Model1();
                var obj_khachHang = db.KhachHangs.SqlQuery("select Top(1) * from KhachHang where tenDangNhap = '"+Session["username"]+"'");
                if(obj_khachHang == null)
                {
                    return RedirectToAction("Cart");
                }
                else
                {
                    var gio = new List<GioHang>();
                    gio = (List<GioHang>)Session["cart"];
                    return RedirectToAction("Index");
                }
            }
        }
        
    }
}