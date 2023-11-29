﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHotel.Core.Repositories
{
    public interface IInviteRepository
    {
        public List<Invite> GetAllInvites();
        public Invite GetInviteById(int id);   
        public void DeleteInvite(int id);
        public void AddInvite(Invite invite);   
        public void UpdateInvite(int id, Invite invite);    
    }
}
