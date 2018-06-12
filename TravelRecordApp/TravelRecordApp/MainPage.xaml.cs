using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Model;
using TravelRecordApp.ViewModel;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class MainPage : ContentPage
    {
        MainVM viewModel;
        
        public MainPage()
        {
            InitializeComponent();

            var assembly = typeof(MainPage);
            
            BindingContext = viewModel;

            iconImage.Source = ImageSource.FromResource("TravelRecordApp.Asserts.Images.plane.png", assembly);
        }

        //private void RegisterUserButton_OnClicked(object sender, EventArgs e)
        //{
        //    Navigation.PushAsync(new RegisterPage());
        //}

        //private async void LoginButton_OnClicked(object sender, EventArgs e)
        //{
        //    bool canLogin = await User.Login(emailEntry.Text, passwordEntry.Text);

        //    if (canLogin)
        //    {
        //        await Navigation.PushAsync(new HomePage());
        //    }
        //    else
        //    {
        //        await DisplayAlert("Error", "Try again!", "OK");
        //    }
        //}
    }
}
