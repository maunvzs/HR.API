using System.Threading.Tasks;
using System.Web.Http;
using System.Data.Entity;

namespace HR.API.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            using (var context = new HRContext())
            {
                return Ok(await context.UserEntity.Include(x => x.Name).ToListAsync());
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] User user)
        {
            using (var context = new HRContext())
            {
                var userType = await context.UserTypeEntity.FirstOrDefaultAsync(b => b.Id == user.UserType.Id);
                if (userType == null)
                {
                    return NotFound();
                }

                var newUser = context.UserEntity.Add(new User
                {
                    UserType = userType,
                    Name = user.Name,
                    LastName = user.LastName,
                    Email = user.Email,
                    Password = user.Password
                });

                await context.SaveChangesAsync();
                return Ok(newUser);
            }
        }
    }
}
