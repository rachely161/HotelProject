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
        public void AddInvite(Invite invite)
        {
            _inviteRepository.AddInvite(invite);
        }

        public void DeleteInvite(int id)
        {
            _inviteRepository.DeleteInvite(id);
        }

        public List<Invite> GetAllInvites()
        {
            return _inviteRepository.GetAllInvites();
        }

        public Invite GetInviteById(int id)
        {
            return _inviteRepository.GetInviteById(id);
        }

        public void UpdateInvite(int id, Invite invite)
        {
            _inviteRepository.UpdateInvite(id, invite);
        }
    }
}
