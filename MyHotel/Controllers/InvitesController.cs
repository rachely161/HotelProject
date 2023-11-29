using Microsoft.AspNetCore.Mvc;
using MyHotel.Core.Services;
using MyHotel.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyHotel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvitesController : ControllerBase
    {
        private readonly IInviteService _inviteService;
        public InvitesController(IInviteService inviteService)
        {
            _inviteService = inviteService;
        }

        // GET: api/<InvitesController>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_inviteService.GetAllInvites());
        }

        // GET api/<InvitesController>/5
        [HttpGet("{id}")]
        public ActionResult<Invite> Get(int id)
        {
            //Invite invite = dataContext.Invites.Find(x=>x.CodeInvite==id);
            //if (invite == null)
            //    return NotFound();
            return Ok(_inviteService.GetInviteById(id));
        }

        // POST api/<InvitesController>
        [HttpPost]
        public ActionResult Post([FromBody] Invite i)
        {
            //if(dataContext.Rooms.Find(x=>x.NumRoom==i.NumRoom)==null||i.NumDays<=0)
            //    return BadRequest();  
            _inviteService.AddInvite(i);
            return Ok(); 
        }

        // PUT api/<InvitesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Invite i)
        {
            //Invite i1 = dataContext.Invites.Find(x => x.CodeInvite == id);
            //if (i1 == null)
            //    return NotFound();
            _inviteService.UpdateInvite(id, i);
            return Ok();
        }

        // DELETE api/<InvitesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            //Invite i = dataContext.Invites.Find(x => x.CodeInvite == id);
            //if (i == null)
            //    return NotFound();
            _inviteService.DeleteInvite(id);   
            return Ok();
        }
    }
}
