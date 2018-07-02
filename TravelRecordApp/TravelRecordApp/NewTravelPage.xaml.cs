using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Geolocator;
using SQLite;
using TravelRecordApp.Helpers;
using TravelRecordApp.Model;
using TravelRecordApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewTravelPage : ContentPage
    {
        //Post post;
        
        NewTravelVM viewModel;
        
        public NewTravelPage()
        {
            InitializeComponent();

            //post = new Post();
            //containerStackLayout.BindingContext = post
            viewModel = new NewTravelVM();
            BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync();

            var venues = await Venue.GetVenues(position.Latitude, position.Longitude);
            venueListView.ItemsSource = venues;
        }

        //Move to NewTravelVM
        //private async void ToolbarItem_Clicked(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //var selectedVenue = venueListView.SelectedItem as Venue;
                
        //        //var firstCategory = selectedVenue.categories.FirstOrDefault();

        //        //Experience have set by binding context
        //        //post.Experience = experienceEntry.Text;
        //        //post.CategoryId = firstCategory.id;
        //        //post.CategoryName = firstCategory.name;
        //        //post.Address = selectedVenue.location.address;
        //        //post.Distance = selectedVenue.location.distance;
        //        //post.Latitude = selectedVenue.location.lat;
        //        //post.Longitude = selectedVenue.location.lng;
        //        //post.VenueName = selectedVenue.name;
        //        //post.UserId = App.user.Id;

        //        //using (SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation))
        //        //{
        //        //    connection.CreateTable<Post>();
        //        //    int rows = connection.Insert(post);

        //        //    if (rows > 0)
        //        //    {
        //        //        DisplayAlert("Success", "Experience successfuly inserted", "Ok");
        //        //    }
        //        //    else
        //        //    {
        //        //        DisplayAlert("Failure", "Experience failured to be inserted", "Ok");
        //        //    }
        //        //}

        //        Post.Insert(post);
        //        await DisplayAlert("Success", "Experience successfuly inserted", "Ok");
        //    }
        //    catch (NullReferenceException nre)
        //    {
        //        Console.WriteLine(nre);
        //        await DisplayAlert("Failure", "Experience failured to be inserted", "Ok");
        //    }
        //    catch (Exception exception)
        //    {
        //        Console.WriteLine(exception);
        //        await DisplayAlert("Failure", "Experience failured to be inserted", "Ok");
        //    }
        //}
    }
}