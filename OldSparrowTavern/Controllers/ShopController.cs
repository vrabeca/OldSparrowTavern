using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MoreLinq;
using OldSparrowTavern.Models;
using OldSparrowTavern.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace OldSparrowTavern.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Browse()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var users = db.Users.ToList();
            User user = users.Find(u=>u.UserName==User.Identity.Name);
            List<Item> items = db.Items.ToList();
            ShopViewModel svm = new ShopViewModel() { user = user, items = items.DistinctBy(i => i.Name).ToList() };
            return View(svm);
        }
        [HttpPost]
        public ActionResult Browse(string order)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var users = db.Users.ToList();
            User user = users.Find(u => u.UserName == User.Identity.Name);
            var items = db.Items.ToList();
            switch (Request.Form["sortby"])
            {
                case "priceDescending":
                    items = items.OrderByDescending(s => s.Cost).ToList();
                    break;
                case "priceAscending":
                    items = items.OrderBy(s => s.Cost).ToList();
                    break;
                case "name":
                    items = items.OrderBy(s => s.Name).ToList();
                    break;
                default:
                    break;
            }
            ShopViewModel svm = new ShopViewModel() { user = user, items = items };
            return View(svm);
        }
        [HttpPost]
        public void Buy(int itemId)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            User user = db.Users.ToList().Find(u => u.UserName == User.Identity.Name);
            itemId = int.Parse(Request.Form["Itemid"]);
            Item item = db.Items.Find(itemId);
            user.Gold -= item.Cost;
            item.Owners.Add(user);
            if (user.Items.Contains(item))
            {
                Item itemDuplicate = new Item()
                {
                    ItemId = db.Items.ToList().Last().ItemId + 1,
                    Cost = item.Cost,
                    Description = item.Description,
                    ExperienceGain = item.ExperienceGain,
                    Name = item.Name,
                    PictureURL = item.PictureURL
                };
                user.Items.Add(itemDuplicate);
            }
            else
            {
                user.Items.Add(item);
            }
            db.SaveChanges();
            List<Item> items = db.Items.ToList();
            ShopViewModel svm = new ShopViewModel() { user = user, items = items };
            Thread.Sleep(700);
            Response.Redirect("Browse");
        }
    }
}