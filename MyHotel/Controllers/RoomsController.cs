using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private static List<Room> rooms=new List<Room>();
        private static int[] roomCount = new int[8];
        // GET: api/<RoomsController>
        [HttpGet]
        public IEnumerable<Room> Get()
        {
            return rooms;
        }

        // GET api/<RoomsController>/5
        [HttpGet("{id}")]
        public Room Get(int id)
        {
            Room r = rooms.Find(x => x.NumRoom == id);
            return r;
        }

        // POST api/<RoomsController>
        [HttpPost]
        public void Post([FromBody] Room r)
        {
            rooms.Add(new Room { NumRoom = 100 * r.Floor + roomCount[r.Floor]++,NumBeds=r.NumBeds,Floor=r.Floor,Type=r.Type,Price=r.Price });
        }

        // PUT api/<RoomsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Room r)
        {
            Room r1 = rooms.Find(x => x.NumRoom == id);
            r1.NumBeds = r.NumBeds;
            r1.Type=r.Type;
            r1.Price = r.Price;
        }

        // DELETE api/<RoomsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Room r = rooms.Find(x => x.NumRoom == id);
            rooms.Remove(r); 
        }
    }
}
