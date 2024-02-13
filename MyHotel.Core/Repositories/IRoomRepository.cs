using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHotel.Core.Repositories
{
    public interface IRoomRepository
    {
        public Task<List<Room>> GetAllRoomsAsync();
        public Task<Room> GetRoomByIdAsync(int id);     
        public Task DeleteRoomAsync(int id);  
        public Task<Room> AddRoomAsync(Room room);
        public Task UpdateRoomAsync(int id, Room room);
    }
}
