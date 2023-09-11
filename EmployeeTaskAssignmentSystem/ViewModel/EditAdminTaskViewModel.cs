using EmployeeTaskAssignmentSystem.Command;
using EmployeeTaskAssignmentSystem.Data;
using EmployeeTaskAssignmentSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using TaskStatus = EmployeeTaskAssignmentSystem.Model.TaskStatus;
using EmployeeTaskAssignmentSystem.View;

namespace EmployeeTaskAssignmentSystem.ViewModel
{
    public class EditAdminTaskViewModel: ViewModelBase
    {
        private TaskModel _task;
        private AppDbContext _appDbContext;
        private TaskStatus _taskStatus;
        public TaskStatus TaskStatus
        {
            get => _taskStatus;
            set
            {
                _taskStatus = value;
                OnPropertyChanged(nameof(TaskStatus));
            }
        }
        public List<string> TaskStatusOptions
        {
            get
            {
                return Enum.GetNames(typeof(TaskStatus)).ToList();
            }
        }

        public List<string> EmployeeEmails { get; set; }
        public string SelectedEmployee { get; set; }
        public TaskModel Task
        {
            get => _task;
            set
            {
                _task = value;
                OnPropertyChanged(nameof(Task));
            }
        }

        private string _assignedTo;
        public string AssignedTo
        {
            get => _assignedTo;
            set
            {
                _assignedTo = value;
                OnPropertyChanged(nameof(AssignedTo));
            }
        }

        public ICommand UpdateButton { get; }
        public EditAdminTaskViewModel()
        {
            UpdateButton = new RelayCommand(UpdateTask);
            _appDbContext = new AppDbContext();
        }
        private void UpdateTask()
        {
            try
            {
                if (Task != null && Task.Id != 0)
                {
                    TaskModel existingTask = _appDbContext.Tasks.Find(Task.Id);
                    if (existingTask != null)
                    {
                        existingTask.Title = Task.Title;
                        existingTask.Description = Task.Description;
                        existingTask.Status = Task.Status;
                        existingTask.AssignedTo = Task.AssignedTo;

                        _appDbContext.SaveChanges();

                        Application.Current.Windows.OfType<EditAdminModalTask>().FirstOrDefault()?.Close();
                        MessageBox.Show("Task updated successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                    else
                    {
                        MessageBox.Show("Task not found");
                    }
                }
                else
                {
                    MessageBox.Show("Select a task to update.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating the task: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

