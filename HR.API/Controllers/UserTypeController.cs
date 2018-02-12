using System.Threading.Tasks;
using System.Web.Http;
using System.Data.Entity;

namespace HR.API.Controllers
{
    [RoutePrefix("api/UserType")]
    public class UserTypeController : ApiController
    {
        [HttpGet]
        [Route("")]
        [Authorize(Roles = "Administrator")]
        public async Task<IHttpActionResult> Get()
        {
            using (var context = new HRContext())
            {
                return Ok(await context.UserTypeEntity.ToListAsync());
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] UserType usertype)
        {
            using (var context = new HRContext())
            {
                var newUserType = context.UserTypeEntity.Add(new UserType
                {
                    Description = usertype.Description,
                    Title = usertype.Title
                });

                await context.SaveChangesAsync();
                return Ok(newUserType);
            }
        }
    }
}
