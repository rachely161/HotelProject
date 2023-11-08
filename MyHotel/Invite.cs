namespace MyHotel
{
    public class Invite
    {
        public int CodeInvite { get; set; }
        public int NumRoom { get; set; }
        public DateOnly Start { get; set; }
        public int NumDays { get; set; }
        public int IdCostumer { get; set; }
        public int Payment { get; set; }
    }
}
