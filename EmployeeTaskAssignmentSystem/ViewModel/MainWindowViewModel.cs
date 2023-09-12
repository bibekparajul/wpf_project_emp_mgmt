using EmployeeTaskAssignmentSystem.Command;
using EmployeeTaskAssignmentSystem.View;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace EmployeeTaskAssignmentSystem.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private object currentPage;
        public object CurrentPage
        {
            get { return currentPage; }
            set
            {
                currentPage = value;
                OnPropertyChanged(nameof(CurrentPage));
            }
        }

        public ICommand HomeButtonCommand { get; }
        public ICommand EmployeeButtonCommand { get; }

        public ICommand TaskButtonCommand { get; }
        public ICommand LogoutCommand { get; }

        public MainViewModel()
        {
            // Initialize commands
            HomeButtonCommand = new RelayCommand(ShowHomePage);
            EmployeeButtonCommand = new RelayCommand(ShowEmployeePage);
            TaskButtonCommand = new RelayCommand(ShowTaskPage);
            LogoutCommand = new RelayCommand(Logout);
            ShowHomePage();
        }

        private void ShowHomePage()
        {
            CurrentPage = new HomePageView();
        }

        private void ShowEmployeePage()
        {
            CurrentPage = new EmployeePageView();
        }
        private void ShowTaskPage()
        {
            CurrentPage = new TaskPageView();
        }
        private void Logout()
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to logout?", "Logout Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                var LoginView = new LoginView();
                LoginView.Show();
                Application.Current.Windows.OfType<MainWindow>().FirstOrDefault()?.Close();

            }
        }
    }
}
