using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using SQLite;
using TravelRecordApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var locator = CrossGeolocator.Current;
            locator.PositionChanged += Locator_PositionChanged;
            await locator.StartListeningAsync(TimeSpan.Zero, 100);

            var position = await locator.GetPositionAsync();

            var center = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude);

            var span = new Xamarin.Forms.Maps.MapSpan(center, 2, 2);

            locationMap.MoveToRegion(span);

            /*using (SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation))
            {
                connection.CreateTable<Post>();
                var posts = connection.Table<Post>().ToList();

                DisplayInMap(posts);
            }
            */
            
            var posts = await Post.Read();
            
            DisplayInMap(posts);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            
            var locator = CrossGeolocator.Current;
            locator.PositionChanged -= Locator_PositionChanged;
            
            locator.StopListeningAsync();
        }

        private void DisplayInMap(List<Post> posts)
        {
            foreach (var post in posts)
            {
                try
                {
                    var position = new Xamarin.Forms.Maps.Position(post.Latitude, post.Longitude);

                    var pin = new Xamarin.Forms.Maps.Pin()
                    {
                        Type = Xamarin.Forms.Maps.PinType.SavedPin,
                        Position = position,
                        Label = post.VenueName,
                        Address = post.Address
                    };
                
                    locationMap.Pins.Add(pin);
                }
                catch(NullReferenceException nre)
                {
                    Console.WriteLine(nre);
                    throw;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
              
            }
        }

        private void Locator_PositionChanged(object sender, PositionEventArgs e)
        {
            var center = new Xamarin.Forms.Maps.Position(e.Position.Latitude, e.Position.Longitude);

            var span = new Xamarin.Forms.Maps.MapSpan(center, 2, 2);

            locationMap.MoveToRegion(span);
        }
    }
}