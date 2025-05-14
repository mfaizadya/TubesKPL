using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LoginAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PelajarController : ControllerBase
    {
        private static List<Pelajar> daftarPelajar = new List<Pelajar>
        {
            new Pelajar("Pelajar1","pela1","pass"),
            new Pelajar("Pelajar2","pela2","pass2")
        };

        [HttpGet]
        public ActionResult<IEnumerable<Pelajar>> GetAllPelajar()
        {
            return daftarPelajar;
        }

        [HttpPost("login")]
        public ActionResult<Pelajar> Login([FromBody] LoginReq req)
        {
            int i;
            if (req == null || string.IsNullOrWhiteSpace(req.Username) || string.IsNullOrWhiteSpace(req.Password))
            {
                return BadRequest("Username dan password harus diisi.");
            }

            for (i = 0; i < daftarPelajar.Count; i++)
            {
                if (req.Username == daftarPelajar[i].Username && req.Password == daftarPelajar[i].Password)
                {
                    return daftarPelajar[i];
                }
            }

            return Unauthorized("Username atau password salah");
        }
    }
}
