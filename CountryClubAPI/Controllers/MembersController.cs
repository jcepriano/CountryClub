using CountryClubAPI.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CountryClubAPI.Models;

namespace CountryClubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly CountryClubContext _context;

        public MembersController(CountryClubContext context)
        {
            _context = context;
        }

        public IActionResult AllMembers()
        {
            var members = _context.Members;

            return new JsonResult(members);
        }

        [HttpGet("{id}")]
        public ActionResult GetMember(int id)
        {
            var member = _context.Members.Find(id);
            return new JsonResult(member);
        }

        [HttpPost]
        public ActionResult CreateMemeber(Member member)
        {
            if(!ModelState.IsValid)
            {
                Response.StatusCode = 400;
                return BadRequest();
            }

            _context.Members.Add(member);
            _context.SaveChanges();
            Response.StatusCode = 201;

            return new JsonResult(member);
        }
    }
}
