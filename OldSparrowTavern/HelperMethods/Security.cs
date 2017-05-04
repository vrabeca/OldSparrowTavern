using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OldSparrowTavern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OldSparrowTavern.HelperMethods
{
    public class Security
    {
        internal static void AddUserToRole(string userName, string roleName)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var UserManager = new UserManager<User>(new UserStore<User>(context));

            try
            {
                var user = UserManager.FindByName(userName);
                UserManager.AddToRole(user.Id, roleName);
                context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}