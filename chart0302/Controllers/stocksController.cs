using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using chart0302.Models;

namespace chart0302.Controllers
{
    public class stocksController : Controller
    {
        private DB1 db = new DB1();

        // GET: stocks
        public ActionResult Index()
        {
            // return View(db.stocks.ToList());
            return View();
        }

        public ActionResult chart(int? id)
        {
            ViewBag.id = id;
            if(id == null)
            {
                return View("Index");
            }
            else
            {
                return View(db.stocks.Where(x => x.stockID == id.ToString()).OrderBy(x => x.stockDate).ToList());
            }
        }

        [HttpPost]
        public ActionResult chart(string stockID)
        {
            ViewBag.id = stockID;
            if (stockID == "")
            {
                return View("Index");
            }
            else
            {
                return View(db.stocks.Where(x => x.stockID == stockID).OrderBy(x => x.stockDate).ToList());
            }
        }

        public ActionResult strategy(string str1)
        {
            string id = "Strategy";
            string stringID = "";
            string stockArray =  "";
            if (str1 == "確認")
            {
                //foreach (string s in db.stocks.Select(x => x.stockID).Distinct().OrderBy(x => x))
                //{
                //    var dbs = db.stocks.Where(x => x.stockID == s).ToList();
                //    try
                //    {
                //        if (float.Parse(dbs.Where(x => x.stockDate == "20210409").Select(x => x.endPrice).ToList()[0]) > 900)
                //        {
                //            stringID = stringID + s + "\n";
                //        }
                //    }
                //    catch
                //    {
                //    }
                //}
                stockArray += ", 1439";
                stockArray += ", 2330";
            }
            ViewBag.id = id;
            ViewBag.stringID = stringID;
            if(stockArray == "")
            {
                return View();
            }
            else
            {
                return View(db.stocks.Where(x => stockArray.Contains(x.stockID)).OrderBy(x => x.stockDate).ToList());
            }
        }
    }
}
