using EmployeeTaskAssignmentSystem.Data;
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
    }
}

