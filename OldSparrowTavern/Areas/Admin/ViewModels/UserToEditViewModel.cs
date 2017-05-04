using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OldSparrowTavern.Areas.Admin.ViewModels
{
    public class UserToEditViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public int InventoryCapacity { get; set; }
        public string Gender { get; set; }
        public string AvatarURL { get; set; }
        public int Gold { get; set; }
        public int Experience { get; set; }
        public int Level { get; set; }
        public string Email { get; set; }
        public string UserRole { get; set; }
    }
}