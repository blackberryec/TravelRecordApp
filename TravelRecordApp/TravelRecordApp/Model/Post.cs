using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SQLite;
using TravelRecordApp.Helpers;

namespace TravelRecordApp.Model
{
    public class Post : INotifyPropertyChanged
    {
        //[PrimaryKey, AutoIncrement]
        //public string Id { get; set; }

        private string id;

        public string Id
        {
            get { return id; }
            set
            {
                id = value; 
                OnPropertyChanged("Id");
            }
        }


        //[MaxLength(250)]
        //public string Experience { get; set; }

        private string experience;

        public string Experience
        {
            get { return experience; }
            set
            {
                experience = value; 
                OnPropertyChanged("Experience");
            }
        }


        //public string VenueName { get; set; }

        private string venueName;

        public string VenueName
        {
            get { return venueName; }
            set
            {
                venueName = value; 
                OnPropertyChanged("VenueName");
            }
        }
        

        //public string CategoryId { get; set; }

        private string categoryId;

        public string CategoryId
        {
            get { return categoryId; }
            set
            {
                categoryId = value; 
                OnPropertyChanged("CategoryId");
            }
        }


        //public string CategoryName { get; set; }
        private string categoryName;

        public string CategoryName
        {
            get { return categoryName; }
            set
            {
                categoryName = value;
                OnPropertyChanged("CategoryName");
            }
        }


        //public string Address { get; set; }
        private string address;

        public string Address
        {
            get { return address; }
            set
            {
                address = value; 
                OnPropertyChanged("Address");
            }
        }


        //public double Latitude { get; set; }
        private double latitude;

        public double Latitude
        {
            get { return latitude; }
            set
            {
                latitude = value; 
                OnPropertyChanged("Latitude");
            }
        }


        //public double Longitude { get; set; }
        private double longitude;

        public double Longitude
        {
            get { return longitude; }
            set
            {
                longitude = value; 
                OnPropertyChanged("Longitude");
            }
        }


        //public int Distance { get; set; }
        private int distance;

        public int Distance
        {
            get { return distance; }
            set
            {
                distance = value; 
                OnPropertyChanged("Distance");
            }
        }


        //public string UserId { get; set; }
        private string userId;

        public string UserId
        {
            get { return userId; }
            set
            {
                userId = value; 
                OnPropertyChanged("UserId");
            }
        }

        private Venue venue;

        [JsonIgnore]
        public Venue Venue
        {
            get { return venue; }
            set
            {
                venue = value;

                if (venue.categories != null)
                {
                    var firstCategory = venue.categories.FirstOrDefault();

                    if (firstCategory != null)
                    {
                        CategoryId = firstCategory.id;
                        CategoryName = firstCategory.name;
                    }
                }

                if (venue.location != null)
                {
                    Address = venue.location.address;
                    Distance = venue.location.distance;
                    Latitude = venue.location.lat;
                    Longitude = venue.location.lng;
                }
              
                VenueName = venue.name;
                UserId = App.user.Id;
                
                OnPropertyChanged("Venue");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public async static void Insert(Post post)
        {
            await App.MobileService.GetTable<Post>().InsertAsync(post);
        }

        public static async Task<List<Post>> Read()
        {
            var post = await App.MobileService.GetTable<Post>().Where(p => p.UserId == App.user.Id).ToListAsync();
            
            return post;
        }
        
        public static Dictionary<string, int> PostCategories(List<Post> posts)
        {
            
            var categories = (from p in posts
                orderby p.CategoryId
                select p.CategoryName).Distinct().ToList();

            var categories2 = posts.OrderBy(p => p.CategoryId).Select(p => p.CategoryName).Distinct().ToList();

            Dictionary<string, int> categoriesCount = new Dictionary<string, int>();
            foreach (var category in categories)
            {
                var count = (from post in posts
                    where post.CategoryName == category
                    select post).ToList().Count;

                var count2 = posts.Where(p => p.CategoryName == category).ToList().Count;

                categoriesCount.Add(category, count);
            }
            
            return categoriesCount;
        }
        
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
