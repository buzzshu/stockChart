using chart0302.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace chart0302.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ErrDevBar()
        {
            string[] Months = { "1月", "2月", "3月", "4月", "5月", "6月", "7月", "8月", "9月", "10月", "11月", "12月" };
            ViewBag.MonthLabel = Months;
            List<ModelChartJs> Dev = new List<ModelChartJs>
            {
                new ModelChartJs
                {
                    dev="1號機",
                    errCount = new int[] {
                        1,3,5,7,9,12,20,9,10,14,19,20
                    }
                },
                new ModelChartJs
                {
                    dev="2號機",
                    errCount=new int[]
                    {
                        1,2,9,8,7,4,1,2,3,6,4,5
                    }
                }
            };

            return View(Dev);
        }

        
    }
}