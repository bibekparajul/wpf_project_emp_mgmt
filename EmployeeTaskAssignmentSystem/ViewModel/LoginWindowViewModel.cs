using EmployeeTaskAssignmentSystem.Command;
using EmployeeTaskAssignmentSystem.Data;
using EmployeeTaskAssignmentSystem.Model;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace EmployeeTaskAssignmentSystem.ViewModel
{
    public class LoginWindowViewModel : ViewModelBase
    {
        public AppDbContext appDbContext { get; set; }
        public ICommand LoginButtonCommand { get; set; }
        private UserModel _user { get; set; }
        public UserModel User
        {
            get => _user;
            set
            {
                if (_user != value)
                {
                    _user = value;
                    OnPropertyChanged(nameof(User));
                }
            }
        }

        public LoginWindowViewModel()
        {
            User = new UserModel();
            appDbContext = new AppDbContext();
            LoginButtonCommand = new RelayCommand(GrantAccess);

        }
        private void GrantAccess()
        {
            bool userFound = appDbContext.Users.Any(user => user.Email == User.Email && user.Password == User.Password);
            if (userFound)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Application.Current.MainWindow.Close();
            }
            else
            {
                MessageBox.Show("Invalid credentials");
            }
        }

    }
}
