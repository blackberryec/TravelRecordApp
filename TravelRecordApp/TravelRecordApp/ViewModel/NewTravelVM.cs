using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TravelRecordApp.Helpers;
using TravelRecordApp.Model;
using TravelRecordApp.ViewModel.Commands;

namespace TravelRecordApp.ViewModel
{
    public class NewTravelVM : INotifyPropertyChanged
    {
        public PostCommand PostCommand { get; set; }

        private Post post;

        public Post Post
        {
            get { return post; }
            set
            {
                post = value;
                OnPropertyChanged("Post");
            }
        }

        private string experience;

        public string Experience
        {
            get { return experience; }
            set
            {
                experience = value;
                Post = new Post()
                {
                    Experience = this.experience,
                    Venue = this.venue
                };
                OnPropertyChanged("Experience");
            }
        }

        private Venue venue;

        public Venue Venue
        {
            get { return venue; }
            set
            {
                venue = value;
                Post = new Post()
                {
                    Experience = this.experience,
                    Venue = this.venue
                };
                OnPropertyChanged("Venue");
            }
        }



        public NewTravelVM()
        {
            PostCommand = new PostCommand(this);
            Post = new Post();
            Venue = new Venue();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public async void PublishPost(Post post)
        {
            try
            {
                Post.Insert(post);
                await App.Current.MainPage.DisplayAlert("Success", "Experience successfuly inserted", "Ok");
            }
            catch (NullReferenceException nre)
            {
                Console.WriteLine(nre);
                await App.Current.MainPage.DisplayAlert("Failure", "Experience failured to be inserted", "Ok");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                await App.Current.MainPage.DisplayAlert("Failure", "Experience failured to be inserted", "Ok");
            }
        }
    }
}
