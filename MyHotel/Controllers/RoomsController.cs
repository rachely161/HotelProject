using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        DataContext dataContext;
        public RoomsController(DataContext context)
        {
            dataContext = context;
        }
        // GET: api/<RoomsController>
        [HttpGet]
        public IEnumerable<Room> Get()
        {
            return dataContext.Rooms;
        }

        // GET api/<RoomsController>/5
        [HttpGet("{id}")]
        public ActionResult<Room> Get(int id)
        {
            Room r = dataContext.Rooms.Find(x => x.NumRoom == id);
            if (r == null)
                return NotFound();
            return r;
        }

        // POST api/<RoomsController>
        [HttpPost]
        public ActionResult Post([FromBody] Room r)
        {
            if (r.Type != 'A' && r.Type != 'B' && r.Type != 'C' || r.Price <= 0||r.NumBeds<=0)
                return BadRequest();
            dataContext.Rooms.Add(new Room { NumRoom = 100 * r.Floor + dataContext.RoomCount[r.Floor]++,NumBeds=r.NumBeds,Floor=r.Floor,Type=r.Type,Price=r.Price });
            return Ok();
        }

        // PUT api/<RoomsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Room r)
        {
            Room r1 = dataContext.Rooms.Find(x => x.NumRoom == id);
            if (r1 == null)
                return NotFound();
            if (r.Type != 'A' && r.Type != 'B' && r.Type != 'C' || r.Price <= 0 || r.NumBeds <= 0)
                return BadRequest();
            r1.NumBeds = r.NumBeds;
            r1.Type=r.Type;
            r1.Price = r.Price;
            return Ok();
        }

        // DELETE api/<RoomsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Room r = dataContext.Rooms.Find(x => x.NumRoom == id);
            if (r == null)
                return NotFound();
            dataContext.Rooms.Remove(r); 
            return Ok();    
        }
    }
}
