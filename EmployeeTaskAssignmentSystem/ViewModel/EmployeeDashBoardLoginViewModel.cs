using EmployeeTaskAssignmentSystem.Command;
using EmployeeTaskAssignmentSystem.Data;
using EmployeeTaskAssignmentSystem.Model;
using EmployeeTaskAssignmentSystem.View;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace EmployeeTaskAssignmentSystem.ViewModel
{
    public class EmployeeDashBoardLoginViewModel : ViewModelBase
    {
        public AppDbContext appDbContext;
        private ObservableCollection<TaskModel> _tasks;
        private ObservableCollection<EmployeeModel> _employees;
        public ObservableCollection<TaskModel> Tasks
        {
            get => _tasks;
            set
            {
                if (_tasks != value)
                {
                    _tasks = value;
                    OnPropertyChanged(nameof(Tasks));
                }
            }
        }
        public ObservableCollection<EmployeeModel> Employees
        {
            get => _employees;
            set
            {
                if (_employees != value)
                {
                    _employees = value;
                    OnPropertyChanged(nameof(Employees));
                }
            }
        }

        private int _empId;
        public int EmpId
        {
            get => _empId;
            set
            {
                if (_empId != value)
                {
                    _empId = value;
                    OnPropertyChanged(nameof(EmpId));
                }
            }
        }

        private string _employeeName;
        public string EmployeeName
        {
            get => _employeeName;
            set
            {
                if (_employeeName != value)
                {
                    _employeeName = value;
                    OnPropertyChanged(nameof(EmployeeName));
                }
            }
        }

        private int _taskId;
        public int TaskId
        {
            get => _taskId;
            set
            {
                if (_taskId != value)
                {
                    _taskId = value;
                    OnPropertyChanged(nameof(TaskId));
                }
            }
        }

        private string _userEmail;
        public string UserEmail
        {
            get => _userEmail;
            set
            {
                if (_userEmail != value)
                {
                    _userEmail = value;
                    OnPropertyChanged(nameof(UserEmail));
                }
            }
        }

        private string _welcomeMessage;
        public string WelcomeMessage
        {
            get => _welcomeMessage;
            set
            {
                if (_welcomeMessage != value)
                {
                    _welcomeMessage = value;
                    OnPropertyChanged(nameof(WelcomeMessage));
                }
            }
        }

        private ObservableCollection<TaskModel> _filteredTasks;
        public ObservableCollection<TaskModel> FilteredTasks
        {
            get => _filteredTasks;
            set
            {
                if (_filteredTasks != value)
                {
                    _filteredTasks = value;
                    OnPropertyChanged(nameof(FilteredTasks));
                }
            }
        }
        public ICommand RetrieveTaskCommand { get; }

        public ICommand LogoutCommand { get; }
        public EmployeeDashBoardLoginViewModel()
        {
            appDbContext = new AppDbContext();
            Tasks = new ObservableCollection<TaskModel>(appDbContext.Tasks);
            Employees = new ObservableCollection<EmployeeModel>(appDbContext.Employees);
            RetrieveTaskCommand = new RelayCommand(RetrieveTask);
            LogoutCommand = new RelayCommand(Logout);
            FilteredTasks = new ObservableCollection<TaskModel>();
        }

        //private void RetrieveTask()
        //{

        //    //EmployeeTaskRetrievalPage employeeTaskRetrievalPage = new EmployeeTaskRetrievalPage();
        //    //employeeTaskRetrievalPage.Show();


        //    // Filter tasks based on UserEmail
        //    var filteredTasks = Tasks.Where(t => t.AssignedTo == UserEmail).ToList();
        //    if (filteredTasks.Count > 0)
        //    {
        //        FilteredTasks = new ObservableCollection<TaskModel>(filteredTasks);
        //        EmployeeTaskRetrievalPage employeeTaskRetrievalPage = new EmployeeTaskRetrievalPage();
        //        employeeTaskRetrievalPage.Show();
        //        //var employeeTaskRetrievalPage = new EmployeeTaskRetrievalPage();
        //        //Application.Current.MainWindow.Content = employeeTaskRetrievalPage;

        //    }
        //    else
        //    {
        //        FilteredTasks.Clear();
        //    }
        //}

        //private void RetrieveTask()
        //{
        //    // Check if UserEmail is valid (e.g., not empty)
        //    if (string.IsNullOrWhiteSpace(UserEmail))
        //    {
        //        MessageBox.Show("Please enter a valid email address.", "Invalid Email", MessageBoxButton.OK, MessageBoxImage.Warning);
        //        return;
        //    }

        //    // Check if UserEmail exists in Employees
        //    bool emailExists = Employees.Any(e => e.Email == UserEmail);

        //    if (!emailExists)
        //    {
        //        MessageBox.Show("The entered email does not exist.", "Email Not Found", MessageBoxButton.OK, MessageBoxImage.Warning);
        //        return;
        //    }

        //    // Filter tasks based on UserEmail
        //    var filteredTasks = Tasks.Where(t => t.AssignedTo == UserEmail).ToList();
        //    if (filteredTasks.Count > 0)
        //    {
        //        FilteredTasks = new ObservableCollection<TaskModel>(filteredTasks);
        //        var employeeTaskRetrievalPage = new EmployeeTaskRetrievalPage();
        //        employeeTaskRetrievalPage.DataContext = this;
        //        employeeTaskRetrievalPage.ShowDialog();
        //    }
        //    else
        //    {
        //        FilteredTasks.Clear();
        //        MessageBox.Show("No task is assigned to you till date.", "No Tasks", MessageBoxButton.OK, MessageBoxImage.Information);
        //    }
        //}
        private void RetrieveTask()
        {
            // Check if UserEmail is valid (e.g., not empty)
            if (string.IsNullOrWhiteSpace(UserEmail))
            {
                MessageBox.Show("Please enter a valid email address.", "Invalid Email", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Check if UserEmail exists in Employees
            var employee = Employees.FirstOrDefault(e => e.Email == UserEmail);
            if (employee != null)
            {
                EmployeeName = $"Welcome {employee.Name}";
            }

            if (employee == null)
            {
                MessageBox.Show("The entered email does not exist.", "Email Not Found", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            // Filter tasks based on UserEmail
            var filteredTasks = Tasks.Where(t => t.AssignedTo == UserEmail).ToList();
            if (filteredTasks.Count > 0)
            {
                FilteredTasks = new ObservableCollection<TaskModel>(filteredTasks);
                var employeeTaskRetrievalPage = new EmployeeTaskRetrievalPage();
                employeeTaskRetrievalPage.DataContext = this;
                employeeTaskRetrievalPage.ShowDialog();
                Application.Current?.MainWindow?.Close();

            }
            else
            {
                FilteredTasks.Clear();
                MessageBox.Show("No task is assigned to you till date.", "No Tasks", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void Logout()
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to logout?", "Logout Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                //Application.Current?.MainWindow?.Close();
                Application.Current.Shutdown();
            }
        }

    }
}

