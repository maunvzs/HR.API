using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace HR.API
{
    public partial class HRContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Singular table convention
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<User>()
                .HasKey(a => a.Id)
                .HasRequired(b => b.UserType)
                .WithMany(c => c.Users);

            base.OnModelCreating(modelBuilder);
        }
    }
}