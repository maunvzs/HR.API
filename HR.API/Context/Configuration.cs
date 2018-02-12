using System.Data.Entity.Migrations;

namespace HR.API.Context
{
    public class Configuration : DbMigrationsConfiguration<HRContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }
    }
}