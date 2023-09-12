using EmployeeTaskAssignmentSystem.Command;
using EmployeeTaskAssignmentSystem.Data;
using EmployeeTaskAssignmentSystem.Model;
using EmployeeTaskAssignmentSystem.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using static EmployeeTaskAssignmentSystem.ViewModel.HomePageViewModel;

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

        private int _pendingTasks;
        public int PendingTasks
        {
            get => _pendingTasks;
            set
            {
                if (_pendingTasks != value)
                {
                    _pendingTasks = value;
                    OnPropertyChanged(nameof(PendingTasks));
                }
            }
        }
        private int _inProgressTasks;
        public int InProgressTasks
        {
            get => _inProgressTasks;
            set
            {
                if (_inProgressTasks != value)
                {
                    _inProgressTasks = value;
                    OnPropertyChanged(nameof(InProgressTasks));
                }
            }
        }
        private int _doneTasks;
        public int DoneTasks
        {
            get => _doneTasks;
            set
            {
                if (_doneTasks != value)
                {
                    _doneTasks = value;
                    OnPropertyChanged(nameof(DoneTasks));
                }
            }
        }

        private int _notStartedTasks;
        public int NotStartedTasks
        {
            get => _notStartedTasks;
            set
            {
                if (_notStartedTasks != value)
                {
                    _notStartedTasks = value;
                    OnPropertyChanged(nameof(NotStartedTasks));
                }
            }
        }
        private int _totalTasks;
        public int TotalTasks
        {
            get => _totalTasks;
            set
            {
                if (_totalTasks != value)
                {
                    _totalTasks = value;
                    OnPropertyChanged(nameof(TotalTasks));
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
        public ICommand ShowTaskPage { get; }
        public ICommand HomeButtonCommand { get; }
        public ICommand EmployeeViewTaskButtonCommand { get; }


        private ICommand _openEditModalCommand;
        public ICommand OpenEditModalCommand
        {
            get
            {
                if (_openEditModalCommand == null)
                {
                    _openEditModalCommand = new RelayCommand(OpenTaskEditModalCommand);
                }
                return _openEditModalCommand;
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
        private string searchKeyword;
        public string SearchKeyword
        {
            get { return searchKeyword; }
            set
            {
                if (searchKeyword != value)
                {
                    searchKeyword = value;
                    OnPropertyChanged(nameof(SearchKeyword));
                    UpdateFilteredTasks();
                }
            }
        }
        // Serarching Filter
        private void UpdateFilteredTasks()
        {
            if (string.IsNullOrWhiteSpace(SearchKeyword))
            {
                FilteredTasks = new ObservableCollection<TaskModel>(Tasks.Where(task => task.AssignedTo == UserEmail));
            }
            else
            {
                FilteredTasks = new ObservableCollection<TaskModel>(
                    Tasks.Where(task =>
                        task.AssignedTo == UserEmail &&
                        (task.Title.Contains(SearchKeyword, StringComparison.OrdinalIgnoreCase) ||
                         task.Description.Contains(SearchKeyword, StringComparison.OrdinalIgnoreCase))));
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
            EmployeeViewTaskButtonCommand = new RelayCommand(ShowEmployeeTaskPage);
            HomeButtonCommand = new RelayCommand(ShowHomeDashBoard);
            FilteredTasks = new ObservableCollection<TaskModel>();
            EmployeeRetrieve();
        }
        #region comment
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
        //private void RetrieveTask()
        //{
        //    // Check if UserEmail is valid (e.g., not empty)
        //    if (string.IsNullOrWhiteSpace(UserEmail))
        //    {
        //        MessageBox.Show("Please enter a valid email address.", "Invalid Email", MessageBoxButton.OK, MessageBoxImage.Warning);
        //        return;
        //    }

        //    // Check if UserEmail exists in Employees
        //    var employee = Employees.FirstOrDefault(e => e.Email == UserEmail);
        //    if (employee != null)
        //    {
        //        EmployeeName = $"Welcome {employee.Name}";
        //    }

        //    if (employee == null)
        //    {
        //        MessageBox.Show("The entered email does not exist.", "Email Not Found", MessageBoxButton.OK, MessageBoxImage.Warning);
        //        return;
        //    }
        //    // Filter tasks based on UserEmail
        //    var filteredTasks = Tasks.Where(t => t.AssignedTo == UserEmail).ToList();
        //    if (filteredTasks.Count > 0)
        //    {
        //        FilteredTasks = new ObservableCollection<TaskModel>(filteredTasks);
        //        //var employeeTaskRetrievalPage = new EmployeeTaskRetrievalPage();
        //        //employeeTaskRetrievalPage.DataContext = this;
        //        //employeeTaskRetrievalPage.ShowDialog();
        //        var employeeHomePage = new EmployeeMainWindowView();
        //        employeeHomePage.DataContext = this;
        //        employeeHomePage.Show();

        //    }
        //    else
        //    {
        //        FilteredTasks.Clear();
        //        MessageBox.Show("No task is assigned to you till date.", "No Tasks", MessageBoxButton.OK, MessageBoxImage.Information);
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
        //    var employee = Employees.FirstOrDefault(e => e.Email == UserEmail);
        //    if (employee != null)
        //    {
        //        EmployeeName = $"Welcome {employee.Name}";
        //    }

        //    if (employee == null)
        //    {
        //        MessageBox.Show("The entered email does not exist.", "Email Not Found", MessageBoxButton.OK, MessageBoxImage.Warning);
        //        return;
        //    }

        //    // Calculate the task counts
        //    //TotalTasks = Tasks.Count;
        //    PendingTasks = Tasks.Count(t => t.Status == TaskStatus.Pending);
        //    InProgressTasks = Tasks.Count(t => t.Status == TaskStatus.InProgress);
        //    DoneTasks = Tasks.Count(t => t.Status == TaskStatus.Done);
        //    NotStartedTasks = Tasks.Count(t => t.Status == TaskStatus.NotStarted);

        //    // Filter tasks based on UserEmail
        //    var userTasks = Tasks.Where(t => t.AssignedTo == UserEmail).ToList();

        //    // Separate tasks into different collections based on status
        //    PendingTasks = userTasks.Count(t => t.Status == TaskStatus.Pending);
        //    DoneTasks = userTasks.Count(t => t.Status == TaskStatus.Done);
        //    NotStartedTasks = userTasks.Count(t => t.Status == TaskStatus.NotStarted);
        //    InProgressTasks = userTasks.Count(t => t.Status == TaskStatus.InProgress);

        //    if (userTasks.Count > 0)
        //    {
        //        FilteredTasks = new ObservableCollection<TaskModel>(userTasks);
        //        var employeeHomePage = new EmployeeMainWindowView();
        //        employeeHomePage.DataContext = this;
        //        employeeHomePage.Show();
        //    }
        //    else
        //    {
        //        FilteredTasks.Clear();
        //        MessageBox.Show("No task is assigned to you till date.", "No Tasks", MessageBoxButton.OK, MessageBoxImage.Information);
        //    }
        //}
        #endregion
        private void OpenTaskEditModalCommand()
        {
            if (SelectedTask != null)
            {
                EditTaskViewModel = new EditTaskViewModel
                {
                    TaskToEdit = SelectedTask
                };
                var modal = new EditModalTask
                {
                    DataContext = EditTaskViewModel
                };
                modal.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a task to edit.", "Task Selection Required", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private EditTaskViewModel _editTaskViewModel;
        public EditTaskViewModel EditTaskViewModel
        {
            get => _editTaskViewModel;
            set
            {
                if (_editTaskViewModel != value)
                {
                    _editTaskViewModel = value;
                    OnPropertyChanged(nameof(EditTaskViewModel));
                }
            }
        }

        private TaskModel _selectedTask;
        public TaskModel SelectedTask
        {
            get => _selectedTask;
            set
            {
                if (_selectedTask != value)
                {
                    _selectedTask = value;
                    OnPropertyChanged(nameof(SelectedTask));
                }
            }
        }

        public List<ChartItem> ChartData { get; private set; }
        public void EmployeeRetrieve()
        {
            // Filter tasks based on UserEmail
            var userTasks = Tasks.Where(t => t.AssignedTo == UserEmail).ToList();

            // Calculate the task counts for the filtered tasks
            PendingTasks = userTasks.Count(t => t.Status == TaskStatus.Pending);
            DoneTasks = userTasks.Count(t => t.Status == TaskStatus.Done);
            NotStartedTasks = userTasks.Count(t => t.Status == TaskStatus.NotStarted);
            InProgressTasks = userTasks.Count(t => t.Status == TaskStatus.InProgress);
            TotalTasks = userTasks.Count();
            ChartData = new List<ChartItem>
            {
                new ChartItem("Total Tasks", TotalTasks),
                new ChartItem("Pending Tasks", PendingTasks),
                new ChartItem("In Progress Tasks", InProgressTasks),
                new ChartItem("Done Tasks", DoneTasks),
                new ChartItem("Not Started Tasks", NotStartedTasks),
                // Add more data items as needed
            };



            if (userTasks.Count > 0)
            {
                FilteredTasks = new ObservableCollection<TaskModel>(userTasks);
                var employeeHomePage = new EmployeeHomePage();
                employeeHomePage.DataContext = this;
                CurrentPage = employeeHomePage;
            }
        }
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
            var userTasks = Tasks.Where(t => t.AssignedTo == UserEmail).ToList();

            if (userTasks.Count > 0)
            {
                FilteredTasks = new ObservableCollection<TaskModel>(userTasks);
                var employeeHomePage = new EmployeeMainWindowView();
                employeeHomePage.DataContext = this;
                EmployeeRetrieve();
                employeeHomePage.Show();
                Application.Current.Windows.OfType<EmployeeDashBoardLoginView>().FirstOrDefault()?.Close();

            }
            else
            {
                FilteredTasks.Clear();
                MessageBox.Show("No task is assigned to you till date.", "No Tasks", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        //private void RetrieveTask()
        //{
        //    // Check if EmpId is valid
        //    if (EmpId <= 0)
        //    {
        //        MessageBox.Show("Please enter a valid Employee ID.", "Invalid Employee ID", MessageBoxButton.OK, MessageBoxImage.Warning);
        //        return;
        //    }

        //    // Check if UserEmail is valid (e.g., not empty)
        //    if (string.IsNullOrWhiteSpace(UserEmail))
        //    {
        //        MessageBox.Show("Please enter a valid email address.", "Invalid Email", MessageBoxButton.OK, MessageBoxImage.Warning);
        //        return;
        //    }

        //    // Check if EmpId and UserEmail exist in Employees
        //    var employee = Employees.FirstOrDefault(e => e.Id == EmpId && e.Email == UserEmail);
        //    if (employee != null)
        //    {
        //        EmployeeName = $"Welcome {employee.Name}";
        //    }
        //    if (employee == null)
        //    {
        //        MessageBox.Show("The entered Employee ID and/or email do not match our records.", "Employee Not Found", MessageBoxButton.OK, MessageBoxImage.Warning);
        //        return;
        //    }

        //    // Filter tasks based on EmpId and UserEmail
        //    var userTasks = Tasks.Where(t => t.AssignedTo == UserEmail && t.Id == EmpId).ToList();

        //    // Calculate the task counts for the filtered tasks
        //    PendingTasks = userTasks.Count(t => t.Status == TaskStatus.Pending);
        //    DoneTasks = userTasks.Count(t => t.Status == TaskStatus.Done);
        //    NotStartedTasks = userTasks.Count(t => t.Status == TaskStatus.NotStarted);
        //    InProgressTasks = userTasks.Count(t => t.Status == TaskStatus.InProgress);

        //    if (userTasks.Count > 0)
        //    {
        //        FilteredTasks = new ObservableCollection<TaskModel>(userTasks);
        //        var employeeHomePage = new EmployeeMainWindowView();
        //        employeeHomePage.DataContext = this;
        //        EmployeeRetrieve();
        //        employeeHomePage.Show();
        //        Application.Current.Windows.OfType<EmployeeDashBoardLoginView>().FirstOrDefault()?.Close();
        //    }
        //    else
        //    {
        //        FilteredTasks.Clear();
        //        MessageBox.Show("No task is assigned to you with the provided Employee ID and email.", "No Tasks", MessageBoxButton.OK, MessageBoxImage.Information);
        //    }
        //}

        private void ShowEmployeeTaskPage()
        {
            var filteredTasks = Tasks.Where(t => t.AssignedTo == UserEmail).ToList();
            if (filteredTasks.Count > 0)
            {
                FilteredTasks = new ObservableCollection<TaskModel>(filteredTasks);
            }

            EmployeeTaskRetrievalPage employeeTaskRetrievalPage = new EmployeeTaskRetrievalPage();
            employeeTaskRetrievalPage.DataContext = this;

            // Set the EmployeeTaskRetrievalPage as the content of the MainFrame
            CurrentPage = employeeTaskRetrievalPage;
        }
        private void Logout()
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to logout?", "Logout Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                var employeeDashboardLoginView = new EmployeeDashBoardLoginView();
                employeeDashboardLoginView.Show();

                // Close the current window (EmployeeMainWindowView)
                Application.Current.Windows.OfType<EmployeeMainWindowView>().FirstOrDefault()?.Close();
            }
        }

        private void ShowHomeDashBoard()
        {
            EmployeeRetrieve();
        }

    }
}

