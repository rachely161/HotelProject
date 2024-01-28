﻿namespace MyHotel
{
    public class Customer
    {
        public string Id { get; set; }
        public string Name { get; set; }    
        public string Phone { get; set; }
        public string Address { get; set; }

        public List<Invite> Invites { get; set; }
    }
}
