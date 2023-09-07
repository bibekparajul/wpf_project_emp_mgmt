using EmployeeTaskAssignmentSystem.Command;
using EmployeeTaskAssignmentSystem.View;
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
        public MainViewModel()
        {
            // Initialize commands
            HomeButtonCommand = new RelayCommand(ShowHomePage);
            EmployeeButtonCommand = new RelayCommand(ShowEmployeePage);
            TaskButtonCommand = new RelayCommand(ShowTaskPage);
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
    }
}
