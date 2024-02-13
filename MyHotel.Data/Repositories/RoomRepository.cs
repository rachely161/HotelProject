using MyHotel.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHotel.Data.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly DataContext _context;
        public RoomRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Room> AddRoomAsync(Room room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task DeleteRoomAsync(int id)
        {
            Room r =await GetRoomByIdAsync(id);
            _context.Rooms.Remove(r);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Room>> GetAllRoomsAsync()
        {
            return await _context.Rooms.ToListAsync();
        }

        public Task<Room> GetRoomByIdAsync(int id)
        {
            return _context.Rooms.FindAsync(id);
        }

        public async Task UpdateRoomAsync(int id, Room room)
        {
            Room r1 =await GetRoomByIdAsync(id);
            r1.NumBeds = room.NumBeds;
            r1.Type = room.Type;
            r1.Price = room.Price;
            _context.SaveChangesAsync();
        }
    }
}
