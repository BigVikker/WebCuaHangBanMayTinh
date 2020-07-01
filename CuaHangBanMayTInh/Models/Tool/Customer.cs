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
        public bool checkManagerment(string username,string password)
        {
            var number_check = db.NhanViens.SqlQuery("select * from NhanVien where " +
                "MaNV = '" + username + "' and matKhau = '" + password + "'").SingleOrDefault();
            if (number_check != null) return true;
            return false;
        }
        public void ThemKhachHach(string tenKH, string tenDangNhap, string matKhau, string gmail, string SDT)
        {
            KhachHang khachHang = new KhachHang();
            khachHang = db.KhachHangs.SqlQuery("Select Top(1)* from KhachHang order by maKH desc").SingleOrDefault();
            
            int numberID = Int32.Parse(khachHang.maKH.ToString().Substring(2));
            numberID++;
            string id = "KH" + numberID.ToString();

            db.Database.ExecuteSqlCommand("insert into KhachHang values ('"+id+"','"+tenKH+"','"+tenDangNhap+"','"+matKhau+"','"+gmail+ "',"+SDT+")");
            return;        
        }
    }
}