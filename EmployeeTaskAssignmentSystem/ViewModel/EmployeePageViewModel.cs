using EmployeeTaskAssignmentSystem.Command;
using EmployeeTaskAssignmentSystem.Data;
using EmployeeTaskAssignmentSystem.Model;
using EmployeeTaskAssignmentSystem.View;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EmployeeTaskAssignmentSystem.ViewModel
{
    public class EmployeePageViewModel : ViewModelBase
    {
        public AppDbContext appDbContext;
        public ObservableCollection<EmployeeModel> _employees;
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
        private ICommand _openEmployeeModalCommand;
        public ICommand OpenEmployeeModelCommand
        {
            get
            {
                if (_openEmployeeModalCommand == null)
                {
                    _openEmployeeModalCommand = new RelayCommand(OpenEmployeeModal);
                }
                return _openEmployeeModalCommand;
            }
        }
        private ICommand _editEmployeeCommand;
        public ICommand EditEmployeeCommand
        {
            get
            {
                if (_editEmployeeCommand == null)
                {
                    _editEmployeeCommand = new RelayCommand(OpenEditEmployeeModal);
                }
                return _editEmployeeCommand;
            }
        }
        private EditEmployeeViewModel _editEmployeeViewModel;
        private void OpenEmployeeModal()
        {
            Employee = new EmployeeModel();
            ModalEmployee modalView = new ModalEmployee();
            modalView.DataContext = this;
            modalView.ShowDialog();
        }
        public ICommand CreateButton { get; }
        public ICommand UpdateButton { get; }
        public ICommand DeleteButton { get; }
        public ObservableCollection<TaskModel> _Tasks;
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
        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    OnPropertyChanged(nameof(SearchText));
                    FilterEmployees();
                }
            }
        }

        private ObservableCollection<EmployeeModel> _filteredEmployees;
        public ObservableCollection<EmployeeModel> FilteredEmployees
        {
            get => _filteredEmployees;
            set
            {
                if (_filteredEmployees != value)
                {
                    _filteredEmployees = value;
                    OnPropertyChanged(nameof(FilteredEmployees));
                }
            }
        }
        private void FilterEmployees()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                // If search text is empty, show all employees
                FilteredEmployees = new ObservableCollection<EmployeeModel>(Employees);
            }
            else
            {
                // Otherwise, filter employees by name or email containing the search text
                string searchText = SearchText.Trim().ToLower();
                FilteredEmployees = new ObservableCollection<EmployeeModel>(
                    Employees.Where(e =>
                        e.Name.ToLower().Contains(searchText) ||
                        e.Email.ToLower().Contains(searchText)
                    )
                );
            }
        }
        private EmployeeModel _employee { get; set; }
        public EmployeeModel Employee
        {
            get => _employee;
            set
            {
                if (_employee != value)
                {
                    _employee = value;
                    OnPropertyChanged(nameof(Employee));
                }
            }
        }

        private EmployeeModel _selectedEmployee;
        public EmployeeModel SelectedEmployee
        {
            get => _selectedEmployee;
            set
            {
                if (_selectedEmployee != value)
                {
                    _selectedEmployee = value;
                    OnPropertyChanged(nameof(SelectedEmployee));
                    if (_selectedEmployee != null)
                    {
                        Employee.Name = _selectedEmployee.Name;
                        Employee.Email = _selectedEmployee.Email;
                        Employee.Address = _selectedEmployee.Address;
                        Employee.Contact = _selectedEmployee.Contact;
                        Employee.Id = _selectedEmployee.Id;
                    }
                }
            }
        }
        public EmployeePageViewModel()
        {
            Employee = new EmployeeModel();
            appDbContext = new AppDbContext();
            Employees = new ObservableCollection<EmployeeModel>(appDbContext.Employees);
            Tasks = new ObservableCollection<TaskModel>(appDbContext.Tasks);
            FilteredTasks = new ObservableCollection<TaskModel>(Tasks);
            CreateButton = new RelayCommand(CreateEmployee);
            //UpdateButton = new RelayCommand(UpdateEmployee);
            DeleteButton = new RelayCommand(DeleteEmployee);
            FilteredEmployees = new ObservableCollection<EmployeeModel>(Employees);
            _editEmployeeViewModel = new EditEmployeeViewModel();

        }

        //private void CreateEmployee()
        //{
        //    if (string.IsNullOrWhiteSpace(Employee.Email))
        //    {
        //        MessageBox.Show("Please enter an email address.");
        //        return;
        //    }

        //    if (Employees.Any(e => e.Email.Equals(Employee.Email, StringComparison.OrdinalIgnoreCase)))
        //    {
        //        MessageBox.Show("An employee with this email already exists.");
        //        return;
        //    }

        //    if (Employee.Contact.HasValue && Employees.Any(e => e.Contact == Employee.Contact))
        //    {
        //        MessageBox.Show("An employee with this contact number already exists.");
        //        return;
        //    }

        //    if (!IsValidContact(Employee.Contact))
        //    {
        //        MessageBox.Show("Invalid contact number. Please enter a 10-digit number.");
        //        return;
        //    }

        //    EmployeeModel newEmployee = new EmployeeModel
        //    {
        //        Name = Employee.Name,
        //        Email = Employee.Email,
        //        Address = Employee.Address,
        //        Contact = Employee.Contact
        //    };

        //    appDbContext.Employees.Add(newEmployee);
        //    appDbContext.SaveChanges(); // Save changes to the database first
        //    Employees.Add(newEmployee);
        //    FilteredEmployees.Add(newEmployee);
        //    OnPropertyChanged(nameof(Employees)); // Notify the UI about the change
        //    MessageBox.Show("Employee Added Successfully");

        //    Reset();
        //    Application.Current.Windows.OfType<ModalEmployee>().FirstOrDefault()?.Close();
        //}

        private void CreateEmployee()
        {
            if (string.IsNullOrWhiteSpace(Employee.Name) || string.IsNullOrWhiteSpace(Employee.Address) 
                || string.IsNullOrWhiteSpace(Employee.Email))
            {
                MessageBox.Show("Please all field properly");
                return;
            }
            if (string.IsNullOrWhiteSpace(Employee.Email))
            {
                MessageBox.Show("Please enter an email address.");
                return;
            }
            if (!IsValidEmail(Employee.Email))
            {
                MessageBox.Show("Invalid email address format. Please enter a valid email address.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (Employees.Any(e => e.Email.Equals(Employee.Email, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("An employee with this email already exists.");
                return;
            }
            if (Employee.Contact.HasValue && Employees.Any(e => e.Contact == Employee.Contact))
            {
                MessageBox.Show("An employee with this contact number already exists.");
                return;
            }
            if (!IsValidContact(Employee.Contact))
            {
                MessageBox.Show("Invalid contact number. Please enter a 10-digit number.");
                return;
            }
            EmployeeModel newEmployee = new EmployeeModel
            {
                Name = Employee.Name,
                Email = Employee.Email,
                Address = Employee.Address,
                Contact = Employee.Contact
            };

            appDbContext.Employees.Add(newEmployee);
            appDbContext.SaveChanges(); // Save changes to the database first
            Employees.Add(newEmployee);
            FilteredEmployees.Add(newEmployee);
            OnPropertyChanged(nameof(Employees)); // Notify the UI about the change
            MessageBox.Show("Employee Added Successfully");

            Reset();
            Application.Current.Windows.OfType<ModalEmployee>().FirstOrDefault()?.Close();
        }
        private bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return System.Text.RegularExpressions.Regex.IsMatch(email, pattern);
        }
        private bool IsValidContact(long? contact)
        {
            return contact.HasValue && contact.ToString().Length == 10;
        }
        private EmployeeModel FindEmployeeById(int empId)
        {
            return Employees.FirstOrDefault<EmployeeModel>(x => x.Id == empId);
        }

        #region Commented Update
        //private void UpdateEmployee()
        //{
        //    if (Employee != null && Employee.Id != 0) // Check if Employee is not null and has a valid Id
        //    {
        //        EmployeeModel employeeModel = FindEmployeeById(Employee.Id);
        //        if (employeeModel != null)
        //        {
        //            employeeModel.Name = Employee.Name;
        //            employeeModel.Email = Employee.Email;
        //            employeeModel.Address = Employee.Address;
        //            employeeModel.Contact = Employee.Contact;
        //            appDbContext.Employees.Update(employeeModel);
        //            appDbContext.SaveChanges();
        //            Reset();
        //            Application.Current.Windows.OfType<ModalEmployee>().FirstOrDefault()?.Close();
        //            MessageBox.Show("Employee updated successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);


        //        }
        //        else
        //        {
        //            MessageBox.Show("Employee not found");
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Select an employee to update.");
        //    }
        //}
        #endregion

        #region Commented Delete
        //private void DeleteEmployee()
        //{
        //    if (Employee != null && Employee.Id != 0) // Check if Employee is not null and has a valid Id
        //    {
        //        EmployeeModel employeeModel = FindEmployeeById(Employee.Id);
        //        if (employeeModel != null)
        //        {
        //            // Ask for confirmation
        //            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this employee?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

        //            if (result == MessageBoxResult.Yes)
        //            {
        //                // Delete the selected employee
        //                appDbContext.Employees.Remove(employeeModel);
        //                appDbContext.SaveChanges();
        //                Employees.Remove(employeeModel);
        //                FilteredEmployees.Remove(employeeModel);

        //                // Notify user
        //                MessageBox.Show("Employee Deleted Successfully");
        //                Reset();
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Employee not found");
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Select an employee to delete.");
        //    }
        //}

        #endregion 
        private void DeleteEmployee()
        {
            if (Employee != null && Employee.Id != 0)
            {
                EmployeeModel employeeModel = FindEmployeeById(Employee.Id);
                if (employeeModel != null)
                {
                    // Ask for confirmation
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this employee?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (result == MessageBoxResult.Yes)
                    {
                        // Remove tasks associated with the employee
                        var tasksToRemove = appDbContext.Tasks.Where(task => task.AssignedTo == employeeModel.Email).ToList();
                        appDbContext.Tasks.RemoveRange(tasksToRemove);

                        // Remove the selected employee
                        appDbContext.Employees.Remove(employeeModel);
                        appDbContext.SaveChanges();

                        // Update the Employees collection
                        Employees.Remove(employeeModel);

                        // Update the FilteredEmployees collection
                        FilteredEmployees.Remove(employeeModel);

                        // Update the Tasks collection
                        foreach (var task in tasksToRemove)
                        {
                            Tasks.Remove(task);
                            FilteredTasks.Remove(task);
                        }

                        MessageBox.Show("Employee and associated tasks deleted successfully.");
                        Reset();
                    }
                }
                else
                {
                    MessageBox.Show("Employee not found");
                }
            }
            else
            {
                MessageBox.Show("Select an employee to delete.");
            }
        }
        private void OpenEditEmployeeModal()
        {
            if (SelectedEmployee != null)
            {
                _editEmployeeViewModel.Employee = SelectedEmployee;
                EditModalEmployee editEmployeeView = new EditModalEmployee();
                editEmployeeView.DataContext = _editEmployeeViewModel;
                editEmployeeView.ShowDialog();
                if (editEmployeeView.DialogResult == true)
                {
                    Employees = new ObservableCollection<EmployeeModel>(appDbContext.Employees);
                }
            }
            else
            {
                MessageBox.Show("Select an employee to edit.");
            }
        }
        public void Reset()
        {
            Employee.Email = string.Empty;
            Employee.Name = string.Empty;
            Employee.Address = string.Empty;
            Employee.Contact = null;
        }
    }
}
