﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections;
using System.Collections.Generic;

namespace OldSparrowTavern.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        public User()
        {
            this.Items = new List<Item>();
        }
        public string Gender { get; set; }
        public string AvatarURL { get; set; }
        public int Gold { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public string UserRole { get; set; }
        public int InventoryCapacity { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}