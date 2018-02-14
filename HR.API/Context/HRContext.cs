using System.Data.Entity;
using System.Threading.Tasks;

namespace HR.API
{
    public partial class HRContext : DbContext
    {
        // Your context has been configured to use a 'HR' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'HR.API.Context.HR' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'HR' 
        // connection string in the application configuration file.
        public HRContext() : base("name=HR") { }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<User> UserEntity { get; set; }
        public virtual DbSet<UserType> UserTypeEntity { get; set; }

        public bool CheckPasswordAsync(User user, string password)
        {
            //return true;
            var dbuser = UserEntity.FirstOrDefaultAsync(o => o.Email == user.Email && o.Password == password.ToSHA256());
            return dbuser == null ? false : true;
        }
    }
}