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

        public void AddInvite(Invite invite)
        {
            _context.Invites.Add(new Invite {Id = _context.CountInvites++, NumRoom = invite.NumRoom, Start = invite.Start, NumDays = invite.NumDays, IdCostumer = invite.IdCostumer, Payment = invite.Payment });
        }

        public void DeleteInvite(int id)
        {
            Invite i = _context.Invites.ToList().Find(x => x.Id == id);
            _context.Invites.Remove(i);
        }

        public List<Invite> GetAllInvites()
        {
            return _context.Invites.ToList();
        }

        public Invite GetInviteById(int id)
        {
            return _context.Invites.First(i=>i.Id==id);
        }

        public void UpdateInvite(int id, Invite invite)
        {
            Invite i1 = _context.Invites.ToList().Find(x => x.Id == id);
            i1.NumRoom = invite.NumRoom;
            i1.Start = invite.Start;
            i1.NumDays = invite.NumDays;
            i1.Payment = invite.Payment;
        }
    }
}
