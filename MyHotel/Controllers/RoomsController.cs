using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyHotel.Api.models;
using MyHotel.Core.DTOs;
using MyHotel.Core.Services;
using MyHotel.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyHotel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRoomService _roomService;
        public RoomsController(IRoomService roomService,IMapper mapper)
        {
            _roomService = roomService;
            _mapper = mapper;
        }

        // GET: api/<RoomsController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _roomService.GetAllRoomsAsync());
        }

        // GET api/<RoomsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomDto>> Get(int id)
        {
            //Room r = dataContext.Rooms.Find(x => x.NumRoom == id);
            //if (r == null)
            //    return NotFound();
            //return r;
            return Ok(_mapper.Map<RoomDto>(await _roomService.GetRoomByIdAsync(id)));
        }

        // POST api/<RoomsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RoomPostModel r)
        {
            //if (r.Type != 'A' && r.Type != 'B' && r.Type != 'C' || r.Price <= 0 || r.NumBeds <= 0)
            //    return BadRequest();
            var roomToAdd=new Room { Floor = r.Floor,NumBeds=r.NumBeds,Price=r.Price,Type=r.Type};
            var newRoom=await _roomService.AddRoomAsync(roomToAdd);
            var roomDto = _mapper.Map<RoomDto>(newRoom);
            return Ok(roomDto);
        }

        // PUT api/<RoomsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Room r)
        {
            //Room r1 = dataContext.Rooms.Find(x => x.NumRoom == id);
            //if (r1 == null)
            //    return NotFound();
            //if (r.Type != 'A' && r.Type != 'B' && r.Type != 'C' || r.Price <= 0 || r.NumBeds <= 0)
            //    return BadRequest();
            await _roomService.UpdateRoomAsync(id, r);
            return Ok();
        }

        // DELETE api/<RoomsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            //Room r = dataContext.Rooms.Find(x => x.NumRoom == id);
            //if (r == null)
            //    return NotFound();
            await _roomService.DeleteRoomAsync(id);
            return Ok();    
        }
    }
}
