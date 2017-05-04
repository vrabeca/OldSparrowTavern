using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OldSparrowTavern.Models
{
    public class Item
    {
        public Item()
        {
            this.Owners = new List<User>();
        }
        [Key]
        public int ItemId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureURL { get; set; }
        [Required]
        public int Cost { get; set; }
        public int ExperienceGain { get; set; }
        public virtual ICollection<User> Owners { get; set; }

    }
}