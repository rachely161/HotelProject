using AutoMapper;
using MyHotel.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHotel.Core
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<RoomDto, Room>().ReverseMap();
            CreateMap<CustomerDto, Customer>().ReverseMap();
            CreateMap<InviteDto, Invite>().ReverseMap();
        }
        
    }
}
