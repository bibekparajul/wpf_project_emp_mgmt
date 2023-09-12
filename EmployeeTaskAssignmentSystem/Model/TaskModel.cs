using EmployeeTaskAssignmentSystem.ViewModel;
using System;

namespace EmployeeTaskAssignmentSystem.Model
{
    public enum TaskStatus
    {
        Pending,
        InProgress,
        Done,
        NotStarted
    }
    public class TaskModel : ViewModelBase
    {
        private int _id;
        private string _title;
        private string _description;
        private TaskStatus _status;
        private string _assignedTo;
        private DateTime _createdOn;
        public DateTime CreatedOn
        {
            get => _createdOn;
            set
            {
                if (_createdOn != value)
                {
                    _createdOn = value;
                    OnPropertyChanged(nameof(CreatedOn));
                }
            }
        }     
        
        private DateTime? _updatedOn;
        public DateTime? UpdatedOn
        {
            get => _updatedOn;
            set
            {
                if (_updatedOn != value)
                {
                    _updatedOn = value;
                    OnPropertyChanged(nameof(UpdatedOn));
                }
            }
        }
        public int Id
        {
            get => _id;
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }

        public string Title
        {
            get => _title;
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnPropertyChanged(nameof(Title));
                }
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        public TaskStatus Status
        {
            get => _status;
            set
            {
                if (_status != value)
                {
                    _status = value;
                    OnPropertyChanged(nameof(Status));
                }
            }
        }

        public string AssignedTo
        {
            get => _assignedTo;
            set
            {
                if (_assignedTo != value)
                {
                    _assignedTo = value;
                    OnPropertyChanged(nameof(AssignedTo));
                }
            }
        }
    }
}