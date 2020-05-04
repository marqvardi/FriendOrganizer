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
    public class FriendDataService : IFriendDataService
    {
        public FriendDataService(Func<FriendOrganizerDbContext> contextCreator)
        {
            _contextCreator = contextCreator;
        }

        public Func<FriendOrganizerDbContext> _contextCreator { get; }

        public async Task<Friend> GetByIdAsync(int friendId)
        {

            using (var ctx  = _contextCreator())
            {
                return  await ctx.Friends.AsNoTracking().SingleAsync(f=> f.Id == friendId);
            }

            //yield return new Friend { FirstName = "Pedro", LastName = "Cabral", Email = "cabral@cabral.com" };
            //yield return new Friend { FirstName = "Joao", LastName = "Bozo", Email = "bozo@bozo.com" };
            //yield return new Friend { FirstName = "Marcelo", LastName = "Tavares", Email = "tavares@tavares.com" };
        }
    }
}
