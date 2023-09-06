using EmployeeTaskAssignmentSystem.Model;
using System.Collections.ObjectModel;
using System.Linq;

namespace EmployeeTaskAssignmentSystem.ViewModel
{
    public class HomePageViewModel : ViewModelBase
    {
        private ObservableCollection<EmployeeModel> _employees;
        private ObservableCollection<TaskModel> _tasks;

        public ObservableCollection<EmployeeModel> Employees
        {
            get => _employees;
            set
            {
                if (_employees != value)
                {
                    _employees = value;
                    OnPropertyChanged(nameof(Employees));
                }
            }
        }

        public ObservableCollection<TaskModel> Tasks
        {
            get => _tasks;
            set
            {
                if (_tasks != value)
                {
                    _tasks = value;
                    OnPropertyChanged(nameof(Tasks));
                }
            }
        }

        public ObservableCollection<CardItem> CardItems { get; set; }

        public HomePageViewModel()
        {
            // Assuming Employees and Tasks are populated from your data source
            Employees = new ObservableCollection<EmployeeModel>();
            Tasks = new ObservableCollection<TaskModel>();

            // Initialize CardItems with data based on Employees and Tasks collections
            CardItems = new ObservableCollection<CardItem>
            {
                new CardItem { Icon = "\xE77B", Title = "Total Employee:", Value = Employees.Count.ToString() },
                new CardItem { Icon = "\xE8D8", Title = "Total Task:", Value = Tasks.Count.ToString() }
                // Add more CardItem objects as needed
            };
        }
    }
}
