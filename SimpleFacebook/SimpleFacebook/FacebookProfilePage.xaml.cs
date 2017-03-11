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
using SimpleFacebook.ViewModels;

namespace SimpleFacebook
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FacebookProfilePage : ContentPage
    {
        App app = (App)Application.Current;
        string ClientId = string.Empty;
        public FacebookProfilePage()
        {
            ClientId = app.ClientId;
            InitializeComponent();
            
        }

        public FacebookProfilePage(string accessToken) : this()
        {
            SetFacebookData(accessToken);
        }

        public async void SetFacebookData(string accessToken)
        {
            var vm = BindingContext as FacebookViewModel;
            await vm.SetFacebookUserProfileAsync(accessToken);
            Content = MainStackLayout;
        }
    }

  
}
