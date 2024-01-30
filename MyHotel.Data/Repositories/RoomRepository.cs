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

        public Room AddRoom(Room room)
        {
            _context.Rooms.Add(room);
            _context.SaveChanges();
            return room;
        }

        public void DeleteRoom(int id)
        {
            Room r = GetRoomById(id);
            _context.Rooms.Remove(r);
            _context.SaveChanges();
        }

        public List<Room> GetAllRooms()
        {
            return _context.Rooms.ToList();
        }

        public Room GetRoomById(int id)
        {
            return _context.Rooms.Find(id);
        }

        public void UpdateRoom(int id, Room room)
        {
            Room r1 = GetRoomById(id);
            r1.NumBeds = room.NumBeds;
            r1.Type = room.Type;
            r1.Price = room.Price;
            _context.SaveChanges();
        }
    }
}
