using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SimpleFacebook.Models;
using SimpleFacebook.Helper;
using System.Collections.ObjectModel;

namespace SimpleFacebook.ViewModels
{
    public class FacebookViewModel : INotifyPropertyChanged
    {
        private FacebookProfile _facebookProfile;
        private FacebookFriend _facebookFriend;

        private ObservableCollection<FacebookFriend> FacebookFriends { get; set; }

        public FacebookFriend FacebookFriend
        {
            get { return _facebookFriend; }
            set
            {
                _facebookFriend = value;
                OnPropertyChanged();
            }
        }

        public FacebookProfile FacebookProfile
        {
            get { return _facebookProfile; }
            set
            {
                _facebookProfile = value;
                OnPropertyChanged();
            }
        }

        public async Task SetFacebookFriendsAsync(string accessToken)
        {
            var facebookHelper = new FacebookHelper();

            FacebookProfile = await facebookHelper.GetFacebookProfileAsync(accessToken);
            if (FacebookProfile != null)
            {
                string userID = FacebookProfile.Id;
                FacebookFriends = facebookHelper.GetFacebookProfileFriendAsync(accessToken ,userID).Result;
            }
        }

        public async Task SetFacebookUserProfileAsync(string accessToken)
        {
            var facebookHelper = new FacebookHelper();

            FacebookProfile = await facebookHelper.GetFacebookProfileAsync(accessToken);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
