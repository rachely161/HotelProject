using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHotel.Core.DTOs
{
    public class InviteDto
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public int NumDays { get; set; }
        public int Payment { get; set; }

        public CustomerDto Customer { get; set; }

        public RoomDto Room { get; set; }
    }
}
