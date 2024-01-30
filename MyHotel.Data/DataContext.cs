using Microsoft.EntityFrameworkCore;

namespace MyHotel.Data
{
    public class DataContext:DbContext
    {
        public DbSet<Customer> Costumers { get; set; }
        public DbSet<Invite> Invites { get; set; }
        public int CountInvites { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public int[] RoomCount { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=RacheliElshteinHotelProject");
        }

        //public DataContext()
        //{
        //    Costumers = new List<Customer>();
        //    Invites = new List<Invite>();
        //    CountInvites = 100;
        //    Rooms = new List<Room>();
        //    RoomCount = new int[8];
        //}
    }
}
