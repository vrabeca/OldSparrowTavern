using AutoMapper;
using OldSparrowTavern.Areas.Admin.ViewModels;
using OldSparrowTavern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OldSparrowTavern.Areas.Admin.Controllers
{
    [RoutePrefix("Admin/ManageUsers")]
    public class ManageUsersController : Controller
    {
        public ActionResult Users()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            IEnumerable<User> users = db.Users.ToList();
            IEnumerable<UserToEditViewModel> usersToEdit = Mapper.Map<IEnumerable<User>, IEnumerable<UserToEditViewModel>>(users);
            return View(usersToEdit);
        }
       [HttpPost]
       public void EditUsername()
       {
            ApplicationDbContext db = new ApplicationDbContext();
            string username = Request.Form["userid"].ToString();
            User userToEdit = db.Users.Where(u => u.UserName == username).FirstOrDefault();
            userToEdit.UserName = Request.Form["username"];
            db.SaveChanges();
            Response.Redirect("Users");

        }
        [HttpPost]
        public void EditUserGold()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            string username = Request.Form["userid"].ToString();
            User userToEdit = db.Users.Where(u => u.UserName == username).FirstOrDefault();
            userToEdit.Gold = int.Parse(Request.Form["usergold"]);
            db.SaveChanges();
            Response.Redirect("Users");

        }
        [HttpPost]
        public void EditUserLevel()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            string username = Request.Form["userid"].ToString();
            User userToEdit = db.Users.Where(u => u.UserName == username).FirstOrDefault();
            userToEdit.Level = int.Parse(Request.Form["userlevel"]);
            db.SaveChanges();
            Response.Redirect("Users");

        }
        [HttpPost]
        public void EditUserExperience(string information)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            string username = Request.Form["userid"].ToString();
            User userToEdit = db.Users.Where(u => u.UserName == username).FirstOrDefault();
            userToEdit.Experience = int.Parse(Request.Form["userexperience"]);
            db.SaveChanges();
            Response.Redirect("Users");
        
        }
        [HttpPost]
        public void EditUserRole(string information)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            string username = Request.Form["userid"].ToString();
            User userToEdit = db.Users.Where(u => u.UserName == username).FirstOrDefault();
            userToEdit.Experience = int.Parse(Request.Form["userrole"]);
            db.SaveChanges();
            Response.Redirect("Users");

        }
    }
}