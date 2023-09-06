using EmployeeTaskAssignmentSystem.Command;
using EmployeeTaskAssignmentSystem.Data;
using EmployeeTaskAssignmentSystem.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using EmployeeTaskAssignmentSystem.View;
using TaskStatus = EmployeeTaskAssignmentSystem.Model.TaskStatus;

namespace EmployeeTaskAssignmentSystem.ViewModel
{
    public class TaskPageViewModel : ViewModelBase
    {
        public AppDbContext appDbContext;
        public ObservableCollection<TaskModel> _Tasks;
        public ObservableCollection<EmployeeModel> Employees { get; set; }

        public string SelectedEmployee { get; set; }
        public ObservableCollection<TaskModel> Tasks
        {
            get => _Tasks;
            set
            {
                if (_Tasks != value)
                {
                    _Tasks = value;
                    OnPropertyChanged(nameof(Tasks));
                }
            }
        }
        public ICommand CreateButton { get; }
        public ICommand UpdateButton { get; }
        public ICommand DeleteButton { get; }

        private ICommand _openTaskModalCommand;
        public ICommand OpenTaskModalCommand
        {
            get
            {
                if (_openTaskModalCommand == null)
                {
                    _openTaskModalCommand = new RelayCommand(OpenTaskModal);
                }
                return _openTaskModalCommand;
            }
        }
        private void OpenTaskModal()
        {
            ModalTask modalView = new ModalTask();
            modalView.DataContext = this;
            modalView.ShowDialog();
        }

        private TaskModel _task { get; set; }
        public TaskModel Task
        {
            get => _task;
            set
            {
                if (_task != value)
                {
                    _task = value;
                    OnPropertyChanged(nameof(Task));
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
                    if (_selectedTask != null)
                    {
                        Task.Title = _selectedTask.Title;
                        Task.Description = _selectedTask.Description;
                        Task.Status = _selectedTask.Status;
                        Task.AssignedTo = _selectedTask.AssignedTo;

                    }
                }
            }
        }
        
        private TaskStatus _selectedStatus;
        public TaskStatus SelectedStatus
        {
            get => _selectedStatus;
            set
            {
                if (_selectedStatus != value)
                {
                    _selectedStatus = value;
                    OnPropertyChanged(nameof(SelectedStatus));
                }
            }
        }



        public List<string> EmployeeEmails { get; set; }
        public TaskPageViewModel()
        {
            Task = new TaskModel();
            appDbContext = new AppDbContext();
            Tasks = new ObservableCollection<TaskModel>(appDbContext.Tasks);
            Employees = new ObservableCollection<EmployeeModel>(appDbContext.Employees);
            CreateButton = new RelayCommand(CreateTask);
            EmployeeEmails = Employees.Select(employee => employee.Email).ToList();
            DeleteButton = new RelayCommand(DeleteTask);
        }
 
        private void CreateTask()
        {
            // Create a new task
            TaskModel newTask = new TaskModel
            {
                Title = Task.Title,
                Description = Task.Description,
                Status = SelectedStatus,
                AssignedTo = SelectedEmployee,
            };

            // Add the new task to the database and collection
            appDbContext.Tasks.Add(newTask);

            // Save changes to the database
            appDbContext.SaveChanges();
            Tasks.Add(newTask);
            MessageBox.Show("Task Added Successfully");
            Reset();
            Application.Current.Windows.OfType<ModalTask>().FirstOrDefault()?.Close();
        }

        private void DeleteTask()
        {
            if (SelectedTask != null)
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this task?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    appDbContext.Tasks.Remove(SelectedTask);
                    appDbContext.SaveChanges();
                    Tasks.Remove(SelectedTask);
                    MessageBox.Show("Task deleted successfully.");
                    SelectedTask = null;
                }
            }
            else
            {
                MessageBox.Show("Select a task to delete.");
            }
        }

        public void Reset()
        {
            Task.Title = string.Empty;
            Task.Description = string.Empty;
            Task.AssignedTo = string.Empty;
        }

    }
}
