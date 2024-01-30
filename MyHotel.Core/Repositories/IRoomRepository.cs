using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHotel.Core.Repositories
{
    public interface IRoomRepository
    {
        public List<Room> GetAllRooms();
        public Room GetRoomById(int id);     
        public void DeleteRoom(int id);  
        public Room AddRoom(Room room);
        public void UpdateRoom(int id, Room room);
    }
}
