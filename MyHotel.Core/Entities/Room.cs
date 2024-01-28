namespace MyHotel
{
    public class Room
    {
        public int Id { get; set; }
        public int NumBeds { get; set; }
        public int Floor { get; set; }
        public int Price { get; set; }
        public char Type { get; set; }

        public List<Invite> Invites { get; set; }
    }
}
