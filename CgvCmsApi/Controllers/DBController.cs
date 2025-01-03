using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CgvCmsApi.Models;
using log4net;
using System.Data.SqlClient;
using CgvCmsApi.Controls;
/*
namespace CgvCmsApi.Controllers
{

public class DBController : BaseController
{
    public class PlayerInfo
    {
        public int index { get; set; }
        public string deviceid { get; set; }
        public string mediatype { get; set; }
        public string sitecode { get; set; }
    }



    //protected SqlHelper db { get; set; }
    //private readonly ILog log = LogManager.GetLogger(typeof(DBController));


    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPost]
    public PlayerInfo Sample(PlayerInfo req)
    {
        List<SqlParameter> para = new List<SqlParameter>();
        para.Add(new SqlParameter("@Test", "TEST"));
        PlayerInfo model = this.db.ExecuteList<PlayerInfo>("TEST_SP", para)[0];
        return model;
    }

}

}
*/