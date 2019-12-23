using OldSparrowTavern.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace OldSparrowTavern.Controllers
{
    public class HomeController : Controller
    {
        private const string urlPattern = "http://rate-exchange-1.appspot.com/currency?from={0}&to={1}";
        [HttpPost]
        public ActionResult Index(string amount, string fromCurrency, string toCurrency, string returnUrl)
        {
            fromCurrency = Request.Form["from"]; 
            toCurrency = Request.Form["to"];
            string url = string.Format(urlPattern, fromCurrency, toCurrency);
            decimal amountt = decimal.Parse(Request.Form["txtAmount"].ToString());

            using (var wc = new WebClient())
            {
                Thread.Sleep(1500);
                var json = wc.DownloadString(url);
                Thread.Sleep(1000);
                Newtonsoft.Json.Linq.JToken token = Newtonsoft.Json.Linq.JObject.Parse(json);
                decimal exchangeRate = (decimal)token.SelectToken("rate");
                string svm = (amountt * exchangeRate).ToString();
                TempData["finalCurrency"] = svm;
                return Redirect(returnUrl);
            }
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
    }
}