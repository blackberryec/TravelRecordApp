using TravelRecordApp.ViewModel.Commands;

namespace TravelRecordApp.ViewModel
{
    public class HomeVM
    {
        public NavigationCommand NavCommand { get; set; }

        public HomeVM()
        {
            NavCommand = new NavigationCommand(this);
        }

        public async void Navigate()
        {
            //todo
            await App.Current.MainPage.Navigation.PushAsync(new NewTravelPage());
        }
    }
}