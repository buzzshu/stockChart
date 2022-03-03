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
            return View(db.stocks.ToList());
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

        // GET: stocks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stocks stocks = db.stocks.Find(id);
            if (stocks == null)
            {
                return HttpNotFound();
            }
            return View(stocks);
        }

        // GET: stocks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: stocks/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "stockID,stockName,numOfSharesTrade,numOfTrade,moneyOfDeal,openPrice,highPrice,lowPrice,endPrice,upDowm,upDowmPrice,PER,stockDate,id_pk")] stocks stocks)
        {
            if (ModelState.IsValid)
            {
                db.stocks.Add(stocks);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stocks);
        }

        // GET: stocks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stocks stocks = db.stocks.Find(id);
            if (stocks == null)
            {
                return HttpNotFound();
            }
            return View(stocks);
        }

        // POST: stocks/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "stockID,stockName,numOfSharesTrade,numOfTrade,moneyOfDeal,openPrice,highPrice,lowPrice,endPrice,upDowm,upDowmPrice,PER,stockDate,id_pk")] stocks stocks)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stocks).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stocks);
        }

        // GET: stocks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stocks stocks = db.stocks.Find(id);
            if (stocks == null)
            {
                return HttpNotFound();
            }
            return View(stocks);
        }

        // POST: stocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            stocks stocks = db.stocks.Find(id);
            db.stocks.Remove(stocks);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
