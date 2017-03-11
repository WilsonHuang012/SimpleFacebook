using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SimpleFacebook.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;

namespace SimpleFacebook.Helper
{
    public class FacebookHelper
    {

        public async Task<FacebookProfile> GetFacebookProfileAsync(string accessToken)
        {
            var requestUrl =
                "https://graph.facebook.com/v2.8/me/?fields=id,name,picture,work,website,religion,location,locale,link,cover,age_range,birthday,devices,email,first_name,last_name,gender,hometown,is_verified,languages&access_token="
                + accessToken;

            var httpClient = new HttpClient();

            var userJson = await httpClient.GetStringAsync(requestUrl);

            var facebookProfile = JsonConvert.DeserializeObject<FacebookProfile>(userJson);

            return facebookProfile;
        }

        public async Task<ObservableCollection<FacebookFriend>> GetFacebookProfileFriendAsync(string accessToken, string userID)
        {
            ObservableCollection<FacebookFriend> list = new ObservableCollection<FacebookFriend>();
            var requestUrl =
               "https://graph.facebook.com/v2.8/"+ userID +"/friends?access_token=" + accessToken;
            var httpClient = new HttpClient();
            var friendsJson = await httpClient.GetStringAsync(requestUrl).ConfigureAwait(false);
            var userFriends = JsonConvert.DeserializeObject<UserFriends>(friendsJson);
            
            

            for (int i = 0; i < userFriends.data.Count; i++)
            {
                var friendID = userFriends.data[i].id;
                
                var friendRequestUrl =
               "https://graph.facebook.com/v2.8/" + friendID + "/picture?access_token=" + accessToken;
                var json = await httpClient.GetStringAsync(friendRequestUrl);

                var data = JsonConvert.DeserializeObject<Data>(json);
                
                list.Add(new FacebookFriend()
                {
                    FriendItem = userFriends.data[i],
                    ImageItem = new Picture() { Data = data }
                });
                
            }
            return list;
        }
    }
}
