using AutoMapper;
using OldSparrowTavern.Models;
using OldSparrowTavern.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OldSparrowTavern.Controllers
{
    [Authorize]
    public class ChatRoomController : Controller
    {
        // GET: Chat
        public ActionResult Chat()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UserInfo(string username)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var users = db.Users.ToList();
            User user = users.Find(u => u.UserName == username);
            UserInfoViewModel vm = Mapper.Map<UserInfoViewModel>(user);
            return PartialView("UserInfo", vm);
        }
    }
}