using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CuaHangBanMayTInh.Models.Enites;

namespace CuaHangBanMayTInh.Models.Tool
{

    public class Computer
    {
        Model1 db;
        public Computer()
        {
            db = new Model1();
        }
        public List<MayTinh> ToList()
        {
            return db.MayTinhs.ToList();
        }
        public List<MayTinh> FindToMayTinh(string strNameFind)
        {
           
            return db.MayTinhs.SqlQuery("select * from MayTinh where tenMayTinh like '%"+strNameFind+"%'").ToList();
        }
        public List<MayTinh> Find(string stringFindTen,string stringFindLoai,string SapXep)
        {
            var query = "select * from MayTinh ";
            if(stringFindTen != "NULL" || stringFindTen != null)
            {
                query = query + " where tenMayTinh like '%" + stringFindTen + "%' ";
                if (stringFindLoai != "NULL" || stringFindLoai != null) { 
                    query = query + "and maLoai like '"+stringFindLoai+"' ";
                }
            }
            else
            {
                if (stringFindLoai != "NULL" || stringFindLoai != null) { 
                    query = query + " where maLoai = '%" + stringFindLoai + "%'";
                }
            }
            if (SapXep != "NULL" || SapXep != null)
            {
                query = query + " order by " + SapXep + "";
            }

            var list = db.MayTinhs.SqlQuery(query).ToList();
            return list;
        }

    }
}