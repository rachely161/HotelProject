namespace MyHotel
{
    public class Invite
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public int NumDays { get; set; }
        public int Payment { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        //public int RoomId { get; set; }
        //public Room Room { get; set; }
        public List<Room> Rooms { get; set; }


    }
}
