namespace MyHotel.Data
{
    public class DataContext
    {
        public List<Customer> Costumers { get; set; }
        public List<Invite> Invites { get; set; }
        public int CountInvites { get; set; }
        public List<Room> Rooms { get; set; }
        public int[] RoomCount { get; set; }
        public DataContext()
        {
            Costumers = new List<Customer>();
            Invites = new List<Invite>();
            CountInvites = 100;
            Rooms = new List<Room>();
            RoomCount = new int[8];
        }
    }
}
