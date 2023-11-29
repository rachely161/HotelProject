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

        public void AddRoom(Room room)
        {
            _context.Rooms.Add(new Room { NumRoom = 100 * room.Floor + _context.RoomCount[room.Floor]++, NumBeds = room.NumBeds, Floor = room.Floor, Type = room.Type, Price = room.Price });
        }

        public void DeleteRoom(int id)
        {
            Room r = _context.Rooms.Find(x => x.NumRoom == id);
            _context.Rooms.Remove(r);
        }

        public List<Room> GetAllRooms()
        {
            return _context.Rooms;
        }

        public Room GetRoomById(int id)
        {
            return _context.Rooms.First(r => r.NumRoom == id);
        }

        public void UpdateRoom(int id, Room room)
        {
            Room r1 = _context.Rooms.Find(x => x.NumRoom == id);
            r1.NumBeds = room.NumBeds;
            r1.Type = room.Type;
            r1.Price = room.Price;
        }
    }
}
