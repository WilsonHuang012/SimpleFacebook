using SimpleFacebook.ViewModels;
using System;
using System.Collections.Generic;
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
    public partial class OptionPage : ContentPage
    {
      
        private string _accessToken;

        public OptionPage()
        {
            InitializeComponent();

            

        }

        public OptionPage(string accessToken) : this()
        {
            this._accessToken = accessToken;
        }

        private void ProfileButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FacebookProfilePage(_accessToken));
        }

        private void FriendsButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FacebookFriendsPage(_accessToken));
        }
    }

   
}
