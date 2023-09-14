using EmployeeTaskAssignmentSystem.Command;
using EmployeeTaskAssignmentSystem.Data;
using EmployeeTaskAssignmentSystem.Model;
using EmployeeTaskAssignmentSystem.Utility;
using EmployeeTaskAssignmentSystem.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using TaskStatus = EmployeeTaskAssignmentSystem.Model.TaskStatus;

namespace EmployeeTaskAssignmentSystem.ViewModel
{
    public class TaskPageViewModel : ViewModelBase
    {
        public AppDbContext appDbContext;
        public ObservableCollection<TaskModel> _Tasks;
        public ObservableCollection<EmployeeModel> Employees { get; set; }
        public string SelectedEmployee { get; set; }
        public List<string> TaskStatusOptions
        {
            get
            {
                return Enum.GetNames(typeof(TaskStatus)).ToList();
            }
        }
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

        private ICommand _OpenTaskModalCommand;
        public ICommand OpenTaskModalCommand
        {
            get
            {
                if (_OpenTaskModalCommand == null)
                {
                    _OpenTaskModalCommand = new RelayCommand(OpenTaskModal);
                }
                return _OpenTaskModalCommand;
            }
        }

        private ICommand _EditTaskCommand;
        public ICommand EditTaskCommand
        {
            get
            {
                if (_EditTaskCommand == null)
                {
                    _EditTaskCommand = new RelayCommand(OpenEditTaskModal);
                }
                return _EditTaskCommand;
            }
        }
        private EditAdminTaskViewModel _editTaskViewModel;
        private void OpenTaskModal()
        {
            Task = new TaskModel();
            ModalTask modalView = new ModalTask();
            modalView.DataContext = this;
            modalView.ShowDialog();
        }
        private TaskModel _Task { get; set; }
        public TaskModel Task
        {
            get => _Task;
            set
            {
                if (_Task != value)
                {
                    _Task = value;
                    OnPropertyChanged(nameof(Task));
                }
            }
        }

        private TaskModel _SelectedTask;
        public TaskModel SelectedTask
        {
            get => _SelectedTask;
            set
            {
                if (_SelectedTask != value)
                {
                    _SelectedTask = value;
                    OnPropertyChanged(nameof(SelectedTask));
                    if (_SelectedTask != null)
                    {
                        Task.Title = _SelectedTask.Title;
                        Task.Description = _SelectedTask.Description;
                        Task.Status = _SelectedTask.Status;
                        Task.AssignedTo = _SelectedTask.AssignedTo;

                    }
                }
            }
        }

        private TaskStatus _SelectedStatus;
        public TaskStatus SelectedStatus
        {
            get => _SelectedStatus;
            set
            {
                if (_SelectedStatus != value)
                {
                    _SelectedStatus = value;
                    OnPropertyChanged(nameof(SelectedStatus));
                }
            }
        }

        private string _AssignedToSearchText;
        public string AssignedToSearchText
        {
            get => _AssignedToSearchText;
            set
            {
                if (_AssignedToSearchText != value)
                {
                    _AssignedToSearchText = value;
                    OnPropertyChanged(nameof(AssignedToSearchText));
                    UpdateFilteredTasks();
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
        private void UpdateFilteredTasks()
        {
            if (string.IsNullOrWhiteSpace(AssignedToSearchText))
            {
                FilteredTasks = new ObservableCollection<TaskModel>(Tasks);
            }
            else
            {
                FilteredTasks = new ObservableCollection<TaskModel>(
                    Tasks.Where(task => task.AssignedTo.IndexOf(AssignedToSearchText, StringComparison.OrdinalIgnoreCase) >= 0)
                );
            }
        }
        private void OpenEditTaskModal()
        {
            if (SelectedTask != null)
            {
                _editTaskViewModel.Task = SelectedTask;
                _editTaskViewModel.EmployeeEmails = EmployeeEmails;
                _editTaskViewModel.SelectedEmployee = SelectedTask.AssignedTo;
                _editTaskViewModel.TaskStatus = SelectedTask.Status;
                EditAdminModalTask editTaskView = new EditAdminModalTask();
                editTaskView.DataContext = _editTaskViewModel;
                editTaskView.ShowDialog();
                if (editTaskView.DialogResult == true)
                {
                    Tasks = new ObservableCollection<TaskModel>(appDbContext.Tasks);
                }
            }
            else
            {
                MessageBox.Show("Select a task to edit.");
            }
        }
        public List<string> EmployeeEmails { get; set; }

        private readonly EmailService _emailService;
        public TaskPageViewModel()
        {
            Task = new TaskModel();
            appDbContext = new AppDbContext();
            Tasks = new ObservableCollection<TaskModel>(appDbContext.Tasks);
            Employees = new ObservableCollection<EmployeeModel>(appDbContext.Employees);
            CreateButton = new RelayCommand(CreateTask);
            EmployeeEmails = Employees.Select(employee => employee.Email).ToList();
            DeleteButton = new RelayCommand(DeleteTask);
            FilteredTasks = new ObservableCollection<TaskModel>(Tasks);
            _editTaskViewModel = new EditAdminTaskViewModel();
            SelectedStatus = TaskStatus.Pending;
            _emailService = new EmailService("smtp.gmail.com", 587, "trafficfine11@gmail.com", "etdytbbrihvhkzbo");


        }
        private void CreateTask()
        {
            if (string.IsNullOrWhiteSpace(Task.Title))
            {
                MessageBox.Show("Please enter a title for the task.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(Task.Description))
            {
                MessageBox.Show("Please enter a description for the task.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(SelectedEmployee))
            {
                MessageBox.Show("Please select an employee to assign the task to.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            // Create a new task
            TaskModel newTask = new TaskModel
            {
                Title = Task.Title,
                Description = Task.Description,
                Status = SelectedStatus,
                AssignedTo = SelectedEmployee,
                CreatedOn = DateTime.Now,

            };

            // Add the new task to the database and collection
            appDbContext.Tasks.Add(newTask);

            // Save changes to the database
            appDbContext.SaveChanges();
            Tasks.Add(newTask);
            FilteredTasks.Add(newTask);
            MessageBox.Show("Task Added Successfully");
            Reset();
            Application.Current.Windows.OfType<ModalTask>().FirstOrDefault()?.Close();
            try
            {
                // Sending email to the assigned employee 
                var assignedEmployee = Tasks.FirstOrDefault(t => t.AssignedTo == newTask.AssignedTo);
                if (assignedEmployee != null)
                {
                    string emailSubject = "New Task Assigned";
                    string emailBody = $"A new task with ID {newTask.Id} and title '{newTask.Title}' has been assigned to you.";

                    // Send the email
                    _emailService.SendEmail(assignedEmployee.AssignedTo, emailSubject, emailBody);
                }
                else
                {
                    MessageBox.Show("Assigned employee not found.");
                }
            }
            catch
            {
                MessageBox.Show("Couldn't send the email");
            }

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
                    FilteredTasks.Remove(SelectedTask);
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
