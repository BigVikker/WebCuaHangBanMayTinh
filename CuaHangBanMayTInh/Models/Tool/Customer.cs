using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CuaHangBanMayTInh.Models.Enites;

namespace CuaHangBanMayTInh.Models.Tool
{
    
    public class Customer
    {
        Model1 db;
        public Customer()
        {
            db = new Model1();
        }
        public bool checkLogin(string username,string password)
        {
            var check_number = db.KhachHangs.SqlQuery("select * from KhachHang where " +
                "tenDangNhap = '"+username+"' and matKhau = '"+password+"'").SingleOrDefault();
            if (check_number != null) return true;
            else return false;
        }

    }
}