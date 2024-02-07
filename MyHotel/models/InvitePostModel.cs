namespace MyHotel.Api.models
{
    public class InvitePostModel
    {
        public DateTime Start { get; set; }
        public int NumDays { get; set; }
        public int Payment { get; set; }
        public int CustomerId { get; set; }
        public List<int> RoomIds { get; set; }
    }
}
