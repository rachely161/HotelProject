using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHotel.Core.Repositories
{
    public interface IInviteRepository
    {
        public Task<List<Invite>> GetAllInvitesAsync();
        public Task<Invite> GetInviteByIdAsync(int id);   
        public Task DeleteInviteAsync(int id);
        public Task<Invite> AddInviteAsync(Invite invite);   
        public Task UpdateInviteAsync(int id, Invite invite);    
    }
}
