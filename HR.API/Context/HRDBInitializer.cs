using System.Collections.Generic;
using System.Data.Entity;

namespace HR.API
{
    public class HRDBInitializer : CreateDatabaseIfNotExists<HRContext>
    {
        protected override void Seed(HRContext context)
        {
            var userTypes = new List<UserType>()
            {
                new UserType
                {
                    Id = 1,
                    Title = "Developer",
                    Description = "Developer"
                }
            };

            var users = new List<User>()
            {
                new User
                {
                    Email = "mauricio.narvaez@enkoder.com.mx",
                    Name = "Mauricio",
                    LastName = "Narvaez",
                    Password = "enk0derdev1".ToSHA256(),
                    UserTypeId = 1
                }
            };

            context.UserTypeEntity.AddRange(userTypes);
            context.UserEntity.AddRange(users);

            base.Seed(context);
        }
    }
}