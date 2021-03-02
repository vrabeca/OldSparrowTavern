namespace OldSparrowTavern.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        //public virtual DbSet<Item> Items { get; set; }

        protected override void Seed(ApplicationDbContext context)
        {
            IList<Item> items = new List<Item>();

            items.Add(new Item() {
                Name = "Pale Beer",
                Cost = 22
            });
            items.Add(new Item()
            {
                Name = "Dark Beer",
                Cost = 12
            });
            items.Add(new Item()
            {
                Name = "Pale Beer",
                Cost = 22
            });
            //foreach (Item drink in items)
            //    context.Items.Add(drink);
            //base.Seed(context);
        }
       //
       // public MyContext() : base("name=MyContextDB") {
       //     Database.SetInitializer<MyContext>(new UniDBInitializer<MyContext>());
       // }
    }
}


