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

        private Visibility _taskListVisibility;
        public Visibility TaskListVisibility
        {
            get => _taskListVisibility;
            set
            {
                if (_taskListVisibility != value)
                {
                    _taskListVisibility = value;
                    OnPropertyChanged(nameof(TaskListVisibility));
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

        public EmployeeDashBoardLoginViewModel()
        {
            appDbContext = new AppDbContext();
            Tasks = new ObservableCollection<TaskModel>(appDbContext.Tasks); 
            Employees = new ObservableCollection<EmployeeModel>(appDbContext.Employees); 
            RetrieveTaskCommand = new RelayCommand(RetrieveTask);
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

        private void RetrieveTask()
        {
            // Filter tasks based on UserEmail
            var filteredTasks = Tasks.Where(t => t.AssignedTo == UserEmail).ToList();
            if (filteredTasks.Count > 0)
            {
                FilteredTasks = new ObservableCollection<TaskModel>(filteredTasks);
                var employeeTaskRetrievalPage = new EmployeeTaskRetrievalPage();
                employeeTaskRetrievalPage.DataContext = this; 
                employeeTaskRetrievalPage.ShowDialog();
            }
            else
            {
                FilteredTasks.Clear();

                // Show a MessageBox when no tasks are assigned
                MessageBox.Show("No task is assigned to you till date.", "No Tasks", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }



    }
}

