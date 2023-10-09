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
        public ActionResult CreateMember(Member member)
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

        [HttpPut("{id}")]
        public ActionResult EditMember(Member member)
        {
            _context.Members.Update(member);
            _context.SaveChanges();
            //Response.StatusCode = 204;

            return new JsonResult(member);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMember(int id)
        {
            var member = _context.Members.Find(id);

            _context.Members.Remove(member);
            _context.SaveChanges();
            var members = _context.Members;

            //Response.StatusCode = 204;

            return new JsonResult(members);
        }


    }
}
