using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OldSparrowTavern.HelperMethods;
using OldSparrowTavern.Models;
using OldSparrowTavern.ViewModels;
using System.Collections.Generic;
using System;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using System.Threading;
using AutoMapper;

namespace OldSparrowTavern.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        public ActionResult Index()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var users = db.Users.ToList();
            User user = users.Find(u => u.UserName == User.Identity.Name);
           
            ProfileViewModel pvm = Mapper.Map<ProfileViewModel>(user);
            return View(pvm);
        }

        [HttpPost]
        public void ChangeAvatar(FormCollection formCollection)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var users = db.Users.ToList();
            User user = users.Find(u => u.UserName == User.Identity.Name);
            foreach (string item in Request.Files)
            {
                HttpPostedFileBase file = Request.Files[item] as HttpPostedFileBase;
                if (file.ContentLength == 0)
                {
                   continue;
                }
                if (file.ContentLength > 0)
                {
                    ImageUpload imageUpload = new ImageUpload { Width = 600 };
                
                    ImageResult imageResult = imageUpload.RenameUploadFile(file);

                    user.AvatarURL = imageUpload.DatabasePath + '/' + imageResult.ImageName;

                    db.SaveChanges();
                }
            }
            Response.Redirect("Index");
        }
        [HttpPost]
        public void Consume(int itemid)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            User user = db.Users.ToList().Find(u => u.UserName == User.Identity.Name);
            Item itemtoconsume = user.Items.Where(i => i.ItemId == int.Parse(Request.Form["Itemid"])).FirstOrDefault();

            if (user.Experience + itemtoconsume.ExperienceGain >= 1000)
            {
                user.Level += 1;
                user.Experience = (user.Experience + itemtoconsume.ExperienceGain) - 1000;
            }
            else
            {
                user.Experience+= itemtoconsume.ExperienceGain;
            }
            user.Items.Remove(itemtoconsume);
            db.SaveChanges();
            Thread.Sleep(700);
            Response.Redirect("Index");
        }
    }
}