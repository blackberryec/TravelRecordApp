using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace TravelRecordApp.Model
{
    public class User : INotifyPropertyChanged
    {
        //public string Id { get; set; }

        private string id;

        public string Id
        {
            get { return id; }
            set
            {
                id = value;

            }
        }


        //public string Email { get; set; }
        private string email;

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        //public string Password { get; set; }
        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        
        private string confirmPassword;

        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set
            {
                confirmPassword = value;
                OnPropertyChanged("ConfirmPassword");
            }
        }

        public static async Task<bool> Login(string email, string password)
        {
            bool isEmailEmpty = string.IsNullOrEmpty(email);
            bool isPasswordEmpty = string.IsNullOrEmpty(password);

            if (isEmailEmpty || isPasswordEmpty)
            {
                return false;
            }
            else
            {
                var user = (await App.MobileService.GetTable<User>().Where(u => u.Email == email).ToListAsync()).FirstOrDefault();

                if (user != null)
                {
                    App.user = user;

                    if (user.Password == password)
                    {
                        //await Navigation.PushAsync(new HomePage());
                        return true;
                    }
                    else
                    {
                        //await DisplayAlert("Error", "Email or password are incorrect", "Ok");
                        return false;
                    }
                }
                else
                {
                    //await DisplayAlert("Error", "There was an error logging you in", "Ok");
                    return false;
                }

            }
        }

        public static async void Register(User user)
        {
            await App.MobileService.GetTable<User>().InsertAsync(user);
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}