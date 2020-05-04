using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.ViewModel
{
    public class FriendDetailViewModel : ViewModelBase, IFriendDetailViewModel
    {
        private readonly IFriendDataService dataService;

        public FriendDetailViewModel(IFriendDataService dataService)
        {
            this.dataService = dataService;
        }

        public async Task LoadAsync(int friendId)
        {
            Friend = await dataService.GetByIdAsync(friendId);
        }

        private Friend _friend;

        public Friend Friend
        {
            get { return _friend; }
            set
            {
                _friend = value;
                OnPropertyChanged();
            }
        }
    }
}
