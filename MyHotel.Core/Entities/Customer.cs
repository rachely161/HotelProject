﻿namespace MyHotel
{
    public class Customer
    {
        public int Id { get; set; }
        public string Tz { get; set; }
        public string Name { get; set; }    
        public string Phone { get; set; }
        public string Address { get; set; }

        public List<Invite> Invites { get; set; }
    }
}
