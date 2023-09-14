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

namespace EmployeeTaskAssignmentSystem.ViewModel
{
    public class EditTaskViewModel : ViewModelBase
    {
        private TaskModel _TaskToEdit;
        public TaskModel TaskToEdit
        {
            get => _TaskToEdit;
            set
            {
                if (_TaskToEdit != value)
                {
                    _TaskToEdit = value;
                    OnPropertyChanged(nameof(TaskToEdit));
                }
            }
        }
        public ObservableCollection<TaskModel> _Tasks;
        public AppDbContext appDbContext;

        private Model.TaskStatus _SelectedStatus;
        public Model.TaskStatus SelectedStatus
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
        public List<string> TaskStatusOptions
        {
            get
            {
                return Enum.GetNames(typeof(Model.TaskStatus)).ToList();
            }
        }
        public ICommand UpdateButton { get; }
        public EditTaskViewModel()
        {
            appDbContext = new AppDbContext();
            UpdateButton = new RelayCommand(UpdateTaskEmployee);
        }
        private void UpdateTaskEmployee()
        {
            TaskModel taskModel = new TaskModel();
            TaskToEdit.Status = SelectedStatus;
            TaskToEdit.UpdatedOn = DateTime.Now;
            appDbContext.Tasks.Update(TaskToEdit);
            appDbContext.SaveChanges();
            Application.Current.Windows.OfType<EditModalTask>().FirstOrDefault()?.Close();
            taskModel.Status = SelectedStatus;
        }
    }

}
