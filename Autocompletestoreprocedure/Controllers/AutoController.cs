using Autocompletestoreprocedure.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Autocompletestoreprocedure.Controllers
{
    public class AutoController : Controller
    {
        // GET: Auto
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Index(string Prefix,string GetType)
        {
            string[,] param=new string[,] { 
                { "@Prefix", Prefix },
                { "@GetType", GetType }
            };
            DataTable dt = Common.ExecuteData(param, "USP_AutoComplete");
            if(dt!=null)
            {
               List<string> item = new List<string>(dt.Rows.Count);
                foreach(DataRow dr in dt.Rows)
                {
                    item.Add(dr[0].ToString());
                }
                return Json(item);
            }
            else
            {
                return Json("");
            }
            
        }
    }
}