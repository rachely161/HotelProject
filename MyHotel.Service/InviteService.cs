using MyHotel.Core.Repositories;
using MyHotel.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHotel.Service
{
    public class InviteService : IInviteService
    {
        private readonly IInviteRepository _inviteRepository;
        public InviteService(IInviteRepository inviteRepository)
        {
            _inviteRepository = inviteRepository;
        }
        public async Task<Invite> AddInviteAsync(Invite invite)
        {
            return await _inviteRepository.AddInviteAsync(invite);
        }

        public async Task DeleteInviteAsync(int id)
        {
            await _inviteRepository.DeleteInviteAsync(id);
        }

        public async Task<List<Invite>> GetAllInvitesAsync()
        {
            return await _inviteRepository.GetAllInvitesAsync();
        }

        public async Task<Invite> GetInviteByIdAsync(int id)
        {
            return await _inviteRepository.GetInviteByIdAsync(id);
        }

        public async Task UpdateInviteAsync(int id, Invite invite)
        {
            await _inviteRepository.UpdateInviteAsync(id, invite);
        }
    }
}
