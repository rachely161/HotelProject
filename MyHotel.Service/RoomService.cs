using MyHotel.Core.Repositories;
using MyHotel.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHotel.Service
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
    
        public Room AddRoom(Room room)
        {
            return _roomRepository.AddRoom(room);
        }

        public void DeleteRoom(int id)
        {
            _roomRepository.DeleteRoom(id);
        }

        public List<Room> GetAllRooms()
        {
            return _roomRepository.GetAllRooms();
        }

        public Room GetRoomById(int id)
        {
            return _roomRepository.GetRoomById(id);
        }

        public void UpdateRoom(int id, Room room)
        {
            _roomRepository.UpdateRoom(id, room);
        }
    }
}
