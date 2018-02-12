using System.Data.Entity;

namespace HR.API.Context
{
    public class Initializer : MigrateDatabaseToLatestVersion<HRContext, Configuration>
    {
    }
}