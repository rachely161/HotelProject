using Microsoft.AspNetCore.Mvc;
using MyHotel.Core.Services;
using MyHotel.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyHotel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _roomService;
        public RoomsController(IRoomService roomService)
        {
            this._roomService = roomService;
        }

        // GET: api/<RoomsController>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_roomService.GetAllRooms());
        }

        // GET api/<RoomsController>/5
        [HttpGet("{id}")]
        public ActionResult<Room> Get(int id)
        {
            //Room r = dataContext.Rooms.Find(x => x.NumRoom == id);
            //if (r == null)
            //    return NotFound();
            //return r;
            return Ok(_roomService.GetRoomById(id));
        }

        // POST api/<RoomsController>
        [HttpPost]
        public ActionResult Post([FromBody] Room r)
        {
            //if (r.Type != 'A' && r.Type != 'B' && r.Type != 'C' || r.Price <= 0 || r.NumBeds <= 0)
            //    return BadRequest();
            _roomService.AddRoom(r);
            return Ok();
        }

        // PUT api/<RoomsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Room r)
        {
            //Room r1 = dataContext.Rooms.Find(x => x.NumRoom == id);
            //if (r1 == null)
            //    return NotFound();
            //if (r.Type != 'A' && r.Type != 'B' && r.Type != 'C' || r.Price <= 0 || r.NumBeds <= 0)
            //    return BadRequest();
            _roomService.UpdateRoom(id, r);
            return Ok();
        }

        // DELETE api/<RoomsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            //Room r = dataContext.Rooms.Find(x => x.NumRoom == id);
            //if (r == null)
            //    return NotFound();
            _roomService.DeleteRoom(id);
            return Ok();    
        }
    }
}
