using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFacebook.Models
{
   

    public class Datum
    {
        public string name { get; set; }
        public string id { get; set; }
    }

    public class Cursors
    {
        public string before { get; set; }
        public string after { get; set; }
    }

    public class Paging
    {
        public Cursors cursors { get; set; }
    }

    public class Summary
    {
        public int total_count { get; set; }
    }

    public class UserFriends
    {
        public List<Datum> data { get; set; }
        public Paging paging { get; set; }
        public Summary summary { get; set; }
    }


    public class FacebookFriend
    {
        public Datum FriendItem { get; set; }
        public Picture ImageItem { get; set; }
    }
}
