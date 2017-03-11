using SimpleFacebook.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleFacebook
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FacebookFriendsPage : ContentPage
    {
        public FacebookFriendsPage()
        {
            InitializeComponent();
        }

        public FacebookFriendsPage(string accessToken) : this()
        {
            SetFacebookFriendData(accessToken);
            
        }

        private async void SetFacebookFriendData(string accessToken)
        {
            var vm = BindingContext as FacebookViewModel;
            await vm.SetFacebookFriendsAsync(accessToken);
        }

        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
            => ((ListView)sender).SelectedItem = null;

        async void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            await DisplayAlert("Selected", e.SelectedItem.ToString(), "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        private void ListView_Refreshing(object sender, EventArgs e)
        {

        }
    }



    
}
