using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyHotel.Api.models;
using MyHotel.Core.DTOs;
using MyHotel.Core.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyHotel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvitesController : ControllerBase
    {

        private readonly IMapper _mapper;

        private readonly IInviteService _inviteService;

        private readonly IRoomService _roomService;
        public InvitesController(IInviteService inviteService, IMapper mapper, IRoomService roomService)
        {
            _mapper = mapper;
            _inviteService = inviteService;
            _roomService = roomService;
        }

        // GET: api/<InvitesController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _inviteService.GetAllInvitesAsync());
        }

        // GET api/<InvitesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InviteDto>> Get(int id)
        {
            //Invite invite = dataContext.Invites.Find(x=>x.CodeInvite==id);
            //if (invite == null)
            //    return NotFound();
            return Ok(_mapper.Map<InviteDto>(await _inviteService.GetInviteByIdAsync(id)));
        }

        // POST api/<InvitesController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] InvitePostModel i)
        {
            //if(dataContext.Rooms.Find(x=>x.NumRoom==i.NumRoom)==null||i.NumDays<=0)
            //    return BadRequest();  
            //???????????????????????????????????
            var rooms = i.RoomIds.Select( r =>_roomService.GetRoomByIdAsync(r).Result).ToList();
            var inviteToAdd = new Invite { Start = i.Start, NumDays = i.NumDays, Payment = i.Payment, CustomerId = i.CustomerId, Rooms = rooms };
            var newInvite = await _inviteService.AddInviteAsync(inviteToAdd);
            var inviteDto = _mapper.Map<InviteDto>(newInvite);
            return Ok(inviteDto);
        }

        // PUT api/<InvitesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Invite i)
        {
            //Invite i1 = dataContext.Invites.Find(x => x.CodeInvite == id);
            //if (i1 == null)
            //    return NotFound();
            await _inviteService.UpdateInviteAsync(id, i);
            return Ok();
        }

        // DELETE api/<InvitesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            //Invite i = dataContext.Invites.Find(x => x.CodeInvite == id);
            //if (i == null)
            //    return NotFound();
            await _inviteService.DeleteInviteAsync(id);
            return Ok();
        }
    }
}
