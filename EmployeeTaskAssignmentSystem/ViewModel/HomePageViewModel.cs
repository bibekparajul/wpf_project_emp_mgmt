using EmployeeTaskAssignmentSystem.Data;
using EmployeeTaskAssignmentSystem.Model;
using System.Collections.Generic;
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
            ChartData = new List<ChartItem>
            {
                new ChartItem("Total Tasks", TotalTasks),
                new ChartItem("Pending Tasks", PendingTasks),
                new ChartItem("In Progress Tasks", InProgressTasks),
                new ChartItem("Done Tasks", DoneTasks),
                new ChartItem("Not Started Tasks", NotStartedTasks),
                // Add more data items as needed
            };
        }

        private int _TotalEmployees;
        public int TotalEmployees
        {
            get => _TotalEmployees;
            set
            {
                if (_TotalEmployees != value)
                {
                    _TotalEmployees = value;
                    OnPropertyChanged(nameof(TotalEmployees));
                }
            }
        }

        private int _TotalTasks;
        public int TotalTasks
        {
            get => _TotalTasks;
            set
            {
                if (_TotalTasks != value)
                {
                    _TotalTasks = value;
                    OnPropertyChanged(nameof(TotalTasks));
                }
            }
        }
        private int _PendingTasks;
        public int PendingTasks
        {
            get => _PendingTasks;
            set
            {
                if (_PendingTasks != value)
                {
                    _PendingTasks = value;
                    OnPropertyChanged(nameof(PendingTasks));
                }
            }
        }

        private int _InProgressTasks;
        public int InProgressTasks
        {
            get => _InProgressTasks;
            set
            {
                if (_InProgressTasks != value)
                {
                    _InProgressTasks = value;
                    OnPropertyChanged(nameof(InProgressTasks));
                }
            }
        }

        private int _DoneTasks;
        public int DoneTasks
        {
            get => _DoneTasks;
            set
            {
                if (_DoneTasks != value)
                {
                    _DoneTasks = value;
                    OnPropertyChanged(nameof(DoneTasks));
                }
            }
        }

        private int _NotStartedTasks;
        public int NotStartedTasks
        {
            get => _NotStartedTasks;
            set
            {
                if (_NotStartedTasks != value)
                {
                    _NotStartedTasks = value;
                    OnPropertyChanged(nameof(NotStartedTasks));
                }
            }
        }
        public List<ChartItem> ChartData { get; private set; }
        public class ChartItem
        {
            public ChartItem(string label, int value)
            {
                Label = label;
                Value = value;
            }

            public string Label { get; private set; }
            public int Value { get; private set; }
        }

    }
}

