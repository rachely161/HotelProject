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

        public async Task<Invite> AddInviteAsync(Invite invite)
        {
            _context.Invites.Add(invite);
            await _context.SaveChangesAsync();
            return invite;
        }

        public async Task DeleteInviteAsync(int id)
        {
            Invite i = await GetInviteByIdAsync(id);
            _context.Invites.Remove(i);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Invite>> GetAllInvitesAsync()
        {
            return await _context.Invites.ToListAsync();
        }

        public async Task<Invite> GetInviteByIdAsync(int id)
        {
            return await _context.Invites.FindAsync(id);
        }

        public async Task UpdateInviteAsync(int id, Invite invite)
        {
            Invite i1 =await GetInviteByIdAsync(id);
            //i1.RoomId = invite.RoomId;
            i1.Start = invite.Start;
            i1.NumDays = invite.NumDays;
            i1.Payment = invite.Payment;
            await _context.SaveChangesAsync();
        }
    }
}
