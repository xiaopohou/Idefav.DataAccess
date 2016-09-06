﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Idefav.DbObjects.Oracle;
using Idefav.IDAL;
using Idefav.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Idefav.Test
{
    [TestClass]
    public class OracleTest
    {
        private string ConnStr = @"Data Source=FUNDBHVW;User Id=funddev;Password=veddnuf;";
        [TestMethod] 
        public void TestGetPageDataTable()
        {
            DbObject db = (DbObject) Idefav.DbFactory.DBOMaker.CreateDbObj("Oracle",ConnStr);
            db.DbConnectStr = ConnStr;
            int count = 0;
            Assert.AreEqual(db.QueryPageTable("select t.* from fundadmin.cfg_advert t", 1, 10, "eid", "*").Rows.Count>0,true);
             
        }

        public void TestGetPageDataTable_2()
        {
            IDbObject db = DbFactory.DBOMaker.CreateDbObj(DBType.Oracle, ConnStr);
            db.DbConnectStr = ConnStr;
            int count = 0;
            db.QueryPageTable("", 1, 20, out count, "eid", "*", new {});
            Assert.AreEqual(db.QueryPageTable("select t.* from fundadmin.cfg_advert t", 1, 10, "eid", "*").Rows.Count > 0, true);
        }
    }
}
