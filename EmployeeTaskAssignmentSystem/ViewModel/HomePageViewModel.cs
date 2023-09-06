using EmployeeTaskAssignmentSystem.Data;
using EmployeeTaskAssignmentSystem.Model;
using System.Linq;

namespace EmployeeTaskAssignmentSystem.ViewModel
{
    public class HomePageViewModel : ViewModelBase
    {
        private readonly AppDbContext appDbContext;

        public HomePageViewModel()
        {
            appDbContext = new AppDbContext();

            // Calculate the total counts from the database
            TotalEmployees = appDbContext.Employees.Count();
            TotalTasks = appDbContext.Tasks.Count();
            PendingTasks = appDbContext.Tasks.Count(t => t.Status == TaskStatus.Pending);
            InProgressTasks = appDbContext.Tasks.Count(t => t.Status == TaskStatus.InProgress);
            DoneTasks = appDbContext.Tasks.Count(t => t.Status == TaskStatus.Done);
            NotStartedTasks = appDbContext.Tasks.Count(t => t.Status == TaskStatus.NotStarted);
        }

        private int _totalEmployees;
        public int TotalEmployees
        {
            get => _totalEmployees;
            set
            {
                if (_totalEmployees != value)
                {
                    _totalEmployees = value;
                    OnPropertyChanged(nameof(TotalEmployees));
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
    }
}

