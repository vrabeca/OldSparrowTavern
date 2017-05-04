using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OldSparrowTavern.ViewModels
{
    public class UserInfoViewModel
    {
        public string UserName { get; set; }
        public string Gender { get; set; }
        public string AvatarURL { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public string UserRole { get; set; }
    }
}