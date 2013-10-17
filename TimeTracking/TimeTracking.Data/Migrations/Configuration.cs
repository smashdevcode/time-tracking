using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using TimeTracking.Data.Models;

namespace TimeTracking.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Context context)
        {
			var user = new User()
			{
				UserId = 1,
				Username = "jamesc",
				Name = "James Churchill",
				Email = "jamesc@csgpro.com"
			};
			context.Users.AddOrUpdate(user);
        }
    }
}
