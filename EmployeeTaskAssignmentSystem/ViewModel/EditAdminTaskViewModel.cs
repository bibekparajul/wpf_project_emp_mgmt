using EmployeeTaskAssignmentSystem.Command;
using EmployeeTaskAssignmentSystem.Data;
using EmployeeTaskAssignmentSystem.Model;
using EmployeeTaskAssignmentSystem.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using TaskStatus = EmployeeTaskAssignmentSystem.Model.TaskStatus;

namespace EmployeeTaskAssignmentSystem.ViewModel
{
    public class EditAdminTaskViewModel : ViewModelBase
    {
        private TaskModel _Task;
        private AppDbContext _appDbContext;
        private TaskStatus _TaskStatus;
        public TaskStatus TaskStatus
        {
            get => _TaskStatus;
            set
            {
                _TaskStatus = value;
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
            get => _Task;
            set
            {
                _Task = value;
                OnPropertyChanged(nameof(Task));
            }
        }

        private string _AssignedTo;
        public string AssignedTo
        {
            get => _AssignedTo;
            set
            {
                _AssignedTo = value;
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

