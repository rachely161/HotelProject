using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHotel.Core.DTOs
{
    public class RoomDto
    {
        public int Id { get; set; }
        public int NumBeds { get; set; }
        public int Floor { get; set; }
        public int Price { get; set; }
        public char Type { get; set; }

    }
}
