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

    }
}