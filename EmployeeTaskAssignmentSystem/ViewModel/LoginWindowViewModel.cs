using EmployeeTaskAssignmentSystem.Command;
using EmployeeTaskAssignmentSystem.Data;
using EmployeeTaskAssignmentSystem.Model;
using EmployeeTaskAssignmentSystem.View;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace EmployeeTaskAssignmentSystem.ViewModel
{
    public class LoginWindowViewModel : ViewModelBase
    {
        public AppDbContext appDbContext { get; set; }
        public ICommand LoginButtonCommand { get; set; }
        public ICommand NavigateToEmployeeDashboardCommand { get; }
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
            NavigateToEmployeeDashboardCommand = new RelayCommand(NavigateToEmployeeDashboard);

        }
        private void GrantAccess()
        {
            if (string.IsNullOrWhiteSpace(User.Email) || string.IsNullOrWhiteSpace(User.Password))
            {
                MessageBox.Show("Please enter both email and password.","Error Login");
                return; 
            }
            bool userFound = appDbContext.Users.Any(user => user.Email == User.Email && user.Password == User.Password);
            if (userFound)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Application.Current.Windows.OfType<LoginView>().FirstOrDefault()?.Close();
            }
            else
            {
                MessageBox.Show("Invalid credentials");
            }
        }

        private void NavigateToEmployeeDashboard()
        {
            var employeeDashboardView = new EmployeeDashBoardLoginView();

            employeeDashboardView.Show();
            Application.Current.Windows.OfType<LoginView>().FirstOrDefault()?.Close();
        }

    }
}



