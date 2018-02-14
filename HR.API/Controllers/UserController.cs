using System.Threading.Tasks;
using System.Web.Http;
using System.Data.Entity;

namespace HR.API.Controllers
{
    [Authorize]
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            using (var context = new HRContext())
            {
                var list = await context.UserEntity.ToListAsync();
                list.ForEach(a => a.Password = string.Empty);
                return Ok(list);
            }
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            using (var context = new HRContext())
            {
                var user = await context.UserEntity.FirstOrDefaultAsync(y => y.Id == id);

                if (user is null)
                    return this.NotFound("User not found");

                user.Password = string.Empty;
                return Ok(user);
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] User user)
        {
            using (var context = new HRContext())
            {
                var userType = await context.UserTypeEntity.FirstOrDefaultAsync(b => b.Id == user.UserTypeId);
                if (userType == null)
                {
                    return NotFound();
                }

                var newUser = context.UserEntity.Add(new User
                {
                    UserTypeId = userType.Id,
                    Name = user.Name,
                    LastName = user.LastName,
                    Email = user.Email,
                    Password = user.Password.ToSHA256()
                });

                await context.SaveChangesAsync();
                return Ok(newUser);
            }
        }
    }
}
