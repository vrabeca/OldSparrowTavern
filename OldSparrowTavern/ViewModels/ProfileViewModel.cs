using OldSparrowTavern.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OldSparrowTavern.ViewModels
{
    public class ProfileViewModel
    {
        public ProfileViewModel()
        {
            InventorySlots = new Item[InventoryCapacity];
        }
        public string Username { get; set; }
        public int Level { get; set; }
        public int Gold { get; set; }
        public string AvatarURL { get; set; }
        public int Experience { get; set; }
        public int InventoryCapacity { get; set; }
        public ICollection<Item> Items { get; set; }
        public Item[] InventorySlots { get; set; }

    }
}