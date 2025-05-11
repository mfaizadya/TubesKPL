using Microsoft.AspNetCore.Mvc;

namespace LoginAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private static List<Admin> daftarAdmin = new List<Admin>
        {
            new Admin("Admin1", "admin", "password"),
            new Admin{Nama="Admin2", Username="admin2", Password="password"}
        };

        [HttpGet]
        public ActionResult<IEnumerable<Admin>> GetAllAdmin()
        {
            return daftarAdmin;
        }

        [HttpPost("login")]
        public ActionResult<Admin> Login([FromBody] LoginReq req)
        {
            int i;
            for (i = 0; i < daftarAdmin.Count; i++)
            {
                if (daftarAdmin[i].Username == req.Username && daftarAdmin[i].Password == req.Password)
                {
                    return daftarAdmin[i];
                }
            }
            return NotFound();
        }
    }
}
