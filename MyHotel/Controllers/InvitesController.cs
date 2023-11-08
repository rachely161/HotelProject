using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvitesController : ControllerBase
    {
        private static List<Invite> invites=new List<Invite>();
        private static int countInvites = 100;
        // GET: api/<InvitesController>
        [HttpGet]
        public IEnumerable<Invite> Get()
        {
            return invites;
        }

        // GET api/<InvitesController>/5
        [HttpGet("{id}")]
        public Invite Get(int id)
        {
            Invite invite = invites.Find(x=>x.CodeInvite==id);
            return invite;
        }

        // POST api/<InvitesController>
        [HttpPost]
        public void Post([FromBody] Invite i)
        {
            invites.Add(new Invite { CodeInvite=countInvites++,NumRoom=i.NumRoom,Start=i.Start,NumDays=i.NumDays,IdCostumer=i.IdCostumer,Payment=i.Payment});
        }

        // PUT api/<InvitesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Invite i)
        {
            Invite i1 = invites.Find(x => x.CodeInvite == id);
            i1.NumRoom = i.NumRoom;
            i1.Start = i.Start;
            i1.NumDays = i.NumDays;
            i1.Payment = i.Payment;
        }

        // DELETE api/<InvitesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Invite i = invites.Find(x => x.CodeInvite == id);
            invites.Remove(i);
        }
    }
}
