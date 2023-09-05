using EmployeeTaskAssignmentSystem.Command;
using EmployeeTaskAssignmentSystem.Data;
using EmployeeTaskAssignmentSystem.Model;
using EmployeeTaskAssignmentSystem.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
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
        private void OpenEmployeeModal()
        {
            ModalEmployee modalView = new ModalEmployee();
            modalView.DataContext = this;
            modalView.ShowDialog();
        }
       
        public ICommand CreateButton { get; }
        public ICommand UpdateButton { get; }
        public ICommand DeleteButton { get; }

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
            CreateButton = new RelayCommand(CreateEmployee);
        }
        private void CreateEmployee()
        {
            EmployeeModel newEmployee = new EmployeeModel
            {
                Name = Employee.Name,
                Email = Employee.Email,
                Address = Employee.Address,
                Contact = Employee.Contact
            };

            appDbContext.Employees.Add(newEmployee);
            appDbContext.SaveChanges(); // Save changes to the database first
            Employees.Add(newEmployee); // Add to the ObservableCollection
            OnPropertyChanged(nameof(Employees)); // Notify the UI about the change
            MessageBox.Show("Employee Added Successfully");
            Reset();
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
