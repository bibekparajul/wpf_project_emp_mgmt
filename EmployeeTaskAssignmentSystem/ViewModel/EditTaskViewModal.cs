using EmployeeTaskAssignmentSystem.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EmployeeTaskAssignmentSystem.ViewModel
{
    public class EditTaskViewModel : ViewModelBase
    {
        private TaskModel _taskToEdit;
        public TaskModel TaskToEdit
        {
            get => _taskToEdit;
            set
            {
                if (_taskToEdit != value)
                {
                    _taskToEdit = value;
                    OnPropertyChanged(nameof(TaskToEdit));
                }
            }
        }
        public ObservableCollection<TaskModel> _Tasks;

        private Model.TaskStatus _selectedStatus;
        public Model.TaskStatus SelectedStatus
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
        public List<string> TaskStatusOptions
        {
            get
            {
                return Enum.GetNames(typeof(Model.TaskStatus)).ToList();
            }
        }


    }

}
