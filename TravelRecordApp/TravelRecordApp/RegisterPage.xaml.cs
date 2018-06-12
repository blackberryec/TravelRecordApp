using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Model;
using TravelRecordApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterPage : ContentPage
	{
	    User user;
	    RegisterVM viewModel;
	    
		public RegisterPage ()
		{
			InitializeComponent ();
		    
		    viewModel = new RegisterVM();
		    BindingContext = viewModel;
		    
		    //user = new User();
		    //containerStackLayout.BindingContext = user;
		}

	    //private async void RegisterButton_OnClicked(object sender, EventArgs e)
	    //{
	    //    if (passwordEntry.Text == confirmpasswordEntry.Text)
	    //    {
	    //        // we can register the user
	    //        //User user = new User()
	    //        //{
	    //        //    Email = emailEntry.Text,
	    //        //    Password = passwordEntry.Text
	    //        //};
	    //        //deleted beacause already have binding context and INotify property 

     //           User.Register(user);
	    //    }
	    //    else
	    //    {
     //           await DisplayAlert("Error", "Passwords don't match", "OK");
	    //    }
	    //}
	}
}