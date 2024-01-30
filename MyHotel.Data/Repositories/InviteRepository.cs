using MyHotel.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHotel.Data.Repositories
{
    public class InviteRepository : IInviteRepository
    {
        private readonly DataContext _context;
        public InviteRepository(DataContext context)
        {
            _context = context;
        }

        public Invite AddInvite(Invite invite)
        {
            _context.Invites.Add(invite);
            _context.SaveChanges();
            return invite;
        }

        public void DeleteInvite(int id)
        {
            Invite i = GetInviteById(id);
            _context.Invites.Remove(i);
            _context.SaveChanges();
        }

        public List<Invite> GetAllInvites()
        {
            return _context.Invites.ToList();
        }

        public Invite GetInviteById(int id)
        {
            return _context.Invites.Find(id);
        }

        public void UpdateInvite(int id, Invite invite)
        {
            Invite i1 = GetInviteById(id);
            //i1.RoomId = invite.RoomId;
            i1.Start = invite.Start;
            i1.NumDays = invite.NumDays;
            i1.Payment = invite.Payment;
            _context.SaveChanges();
        }
    }
}
