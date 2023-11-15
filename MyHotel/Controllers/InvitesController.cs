using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvitesController : ControllerBase
    {
        DataContext dataContext;
        public InvitesController(DataContext context)
        {
            dataContext = context;
        }
        // GET: api/<InvitesController>
        [HttpGet]
        public IEnumerable<Invite> Get()
        {
            return dataContext.Invites;
        }

        // GET api/<InvitesController>/5
        [HttpGet("{id}")]
        public ActionResult<Invite> Get(int id)
        {
            Invite invite = dataContext.Invites.Find(x=>x.CodeInvite==id);
            if (invite == null)
                return NotFound();
            return invite;
        }

        // POST api/<InvitesController>
        [HttpPost]
        public ActionResult Post([FromBody] Invite i)
        {
            if(dataContext.Rooms.Find(x=>x.NumRoom==i.NumRoom)==null||i.NumDays<=0)
                return BadRequest();  
            dataContext.Invites.Add(new Invite { CodeInvite=dataContext.CountInvites++,NumRoom=i.NumRoom,Start=i.Start,NumDays=i.NumDays,IdCostumer=i.IdCostumer,Payment=i.Payment});
            return Ok(); 
        }

        // PUT api/<InvitesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Invite i)
        {
            Invite i1 = dataContext.Invites.Find(x => x.CodeInvite == id);
            if (i1 == null)
                return NotFound();
            i1.NumRoom = i.NumRoom;
            i1.Start = i.Start;
            i1.NumDays = i.NumDays;
            i1.Payment = i.Payment;
            return Ok();
        }

        // DELETE api/<InvitesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Invite i = dataContext.Invites.Find(x => x.CodeInvite == id);
            if (i == null)
                return NotFound();
            dataContext.Invites.Remove(i);
            return Ok();
        }
    }
}
