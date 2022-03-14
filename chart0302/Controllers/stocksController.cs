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


        public ActionResult Chart(string id)
        {
            if(id == null)
            {
                return View("Index");
            }
            else
            {
                var stock = db.stocks.Where(x => x.stockID == id).OrderBy(x => x.stockDate).ToList();
                ViewBag.id = stock.First().stockName + "(" + stock.First().stockID + ")";
                return View(stock);
            }
        }

        [HttpPost]
        public ActionResult Chart(string stockID, string id)
        {

            if (stockID == "")
            {
                return View("Index");
            }
            else
            {
                var stock = db.stocks.Where(x => x.stockID == stockID || x.stockName == stockID).OrderBy(x => x.stockDate).ToList();
                ViewBag.id = stock.First().stockName + "(" + stock.First().stockID + ")";
                return View(stock);
            }
        }

        public ActionResult Strategy(string str)
        {
            string id = "Strategy";
            string stringID = "";
            string stockArray =  "";
            switch (str)
            {
                case "策略一":
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
                    stockArray += ", 2303";
                    stockArray += ", 2330";
                    break;
                case "策略二":
                    stockArray += ", 0050";
                    stockArray += ", 2603";
                    break;
                case "策略三":
                    stockArray += ", 2609";
                    stockArray += ", 2409";
                    break;
                case "策略四":
                    stockArray += ", 2610";
                    stockArray += ", 2618";
                    break;
                case "策略五":
                    stockArray += ", 3481";
                    stockArray += ", 2002";
                    break;
                default:
                    break;
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

        public ActionResult Customize()
        {
            return View();
        }

        public ActionResult StockMarketIndex()
        {
            return View();
        }
    }
}
