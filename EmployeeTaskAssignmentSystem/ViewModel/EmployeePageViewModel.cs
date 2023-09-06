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
            UpdateButton = new RelayCommand(UpdateEmployee);
            DeleteButton = new RelayCommand(DeleteEmployee);
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
            Application.Current.Windows.OfType<ModalEmployee>().FirstOrDefault()?.Close();

        }

        private EmployeeModel FindEmployeeById(int empId)
        {
            return Employees.FirstOrDefault<EmployeeModel>(x => x.Id == empId);
        }


        private void UpdateEmployee()
        {
            if (Employee != null && Employee.Id != 0) // Check if Employee is not null and has a valid Id
            {
                EmployeeModel employeeModel = FindEmployeeById(Employee.Id);
                if (employeeModel != null)
                {
                    employeeModel.Name = Employee.Name;
                    employeeModel.Email = Employee.Email;
                    employeeModel.Address = Employee.Address;
                    employeeModel.Contact = Employee.Contact;
                    appDbContext.Employees.Update(employeeModel);
                    appDbContext.SaveChanges();
                    Reset();
                    Application.Current.Windows.OfType<ModalEmployee>().FirstOrDefault()?.Close();
                    MessageBox.Show("Employee updated successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);


                }
                else
                {
                    MessageBox.Show("Employee not found");
                }
            }
            else
            {
                MessageBox.Show("Select an employee to update.");
            }
        }

        private void DeleteEmployee()
        {
            if (Employee != null && Employee.Id != 0) // Check if Employee is not null and has a valid Id
            {
                EmployeeModel employeeModel = FindEmployeeById(Employee.Id);
                if (employeeModel != null)
                {
                    // Ask for confirmation
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this employee?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (result == MessageBoxResult.Yes)
                    {
                        // Delete the selected employee
                        appDbContext.Employees.Remove(employeeModel);
                        appDbContext.SaveChanges();
                        Employees.Remove(employeeModel);

                        // Notify user
                        MessageBox.Show("Employee Deleted Successfully");
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

        #region EditCode

        //private void EditEmployee()
        //{
        //    if (SelectedEmployee != null)
        //    {
        //        // Create a copy of the selected employee to avoid modifying it directly
        //        EmployeeModel editEmployee = new EmployeeModel
        //        {
        //            Id = SelectedEmployee.Id,
        //            Name = SelectedEmployee.Name,
        //            Email = SelectedEmployee.Email,
        //            Address = SelectedEmployee.Address,
        //            Contact = SelectedEmployee.Contact
        //        };

        //        // Open the modal with the selected employee data for editing
        //        ModalEmployee modalView = new ModalEmployee();
        //        modalView.DataContext = editEmployee; // Set the DataContext here
        //        modalView.ShowDialog();

        //        // If the modal was closed and changes were saved, update the employee data
        //        if (modalView.DialogResult.HasValue && modalView.DialogResult.Value)
        //        {
        //            SelectedEmployee.Name = editEmployee.Name;
        //            SelectedEmployee.Email = editEmployee.Email;
        //            SelectedEmployee.Address = editEmployee.Address;
        //            SelectedEmployee.Contact = editEmployee.Contact;
        //            appDbContext.SaveChanges();
        //            Reset();
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Employee Id not found");
        //    }
        //}

        //private void EditEmployee()
        //{
        //    if (SelectedEmployee != null)
        //    {
        //        // Create a copy of the selected employee to avoid modifying it directly
        //        EmployeeModel editEmployee = new EmployeeModel
        //        {
        //            Id = SelectedEmployee.Id,
        //            Name = SelectedEmployee.Name,
        //            Email = SelectedEmployee.Email,
        //            Address = SelectedEmployee.Address,
        //            Contact = SelectedEmployee.Contact
        //        };

        //        // Open the modal with the selected employee data for editing
        //        ModalEmployee modalView = new ModalEmployee();
        //        modalView.DataContext = editEmployee; // Set the DataContext here
        //        modalView.ShowDialog();

        //        // If the modal was closed and changes were saved, update the employee data
        //        if (modalView.DialogResult.HasValue && modalView.DialogResult.Value)
        //        {
        //            // Find the employee in the ObservableCollection by Id
        //            EmployeeModel employeeToUpdate = FindEmployeeById(editEmployee.Id);

        //            if (employeeToUpdate != null)
        //            {
        //                employeeToUpdate.Name = editEmployee.Name;
        //                employeeToUpdate.Email = editEmployee.Email;
        //                employeeToUpdate.Address = editEmployee.Address;
        //                employeeToUpdate.Contact = editEmployee.Contact;

        //                // Save changes to the database
        //                appDbContext.SaveChanges();
        //            }
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Employee Id not found");
        //    }
        //}

        //private void DeleteEmployee()
        //{
        //    // Check if a task is selected
        //    if (SelectedEmployee != null)
        //    {
        //        // Ask for confirmation
        //        MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this task?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

        //        if (result == MessageBoxResult.Yes)
        //        {
        //            // Delete the selected task
        //            appDbContext.Employees.Remove(SelectedEmployee);
        //            appDbContext.SaveChanges();
        //            Employees.Remove(SelectedEmployee);

        //            // Notify user
        //            MessageBox.Show("Employee Deleted Successfully");
        //            SelectedEmployee = null;

        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Select a task to delete.");
        //    }
        //}
        #endregion

        public void Reset()
        {
            Employee.Email = string.Empty;
            Employee.Name = string.Empty;
            Employee.Address = string.Empty;
            Employee.Contact = null;
        }
    }
}
