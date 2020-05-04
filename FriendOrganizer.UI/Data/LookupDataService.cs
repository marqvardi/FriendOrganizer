using FriendOrganizer.DataAccess;
using FriendOrganizer.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.Data
{
    public class LookupDataService : IFriendLookupDataService
    {
        private readonly Func<FriendOrganizerDbContext> _contextcreator;

        public LookupDataService(Func<FriendOrganizerDbContext> contextcreator)
        {
            this._contextcreator = contextcreator;
        }

        public async Task<IEnumerable<LookupItem>> GetFriendLookupAsync()
        {
            using (var ctx = _contextcreator())
            {
                return await ctx.Friends.AsNoTracking()
                     .Select(f =>
                     new LookupItem
                     {
                         Id = f.Id,
                         DisplayMember = f.FirstName + " " + f.LastName
                     })
                     .ToListAsync();
            }
        }
    }
}
