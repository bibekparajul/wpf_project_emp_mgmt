using EmployeeTaskAssignmentSystem.Command;
using EmployeeTaskAssignmentSystem.Data;
using EmployeeTaskAssignmentSystem.Model;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace EmployeeTaskAssignmentSystem.ViewModel
{
    public class EditEmployeeViewModel : ViewModelBase
    {
        private EmployeeModel _employee;
        private AppDbContext _appDbContext;
        public EmployeeModel Employee
        {
            get => _employee;
            set
            {
                _employee = value;
                OnPropertyChanged(nameof(Employee));
            }
        }
        public ICommand UpdateButton { get; }
        public EditEmployeeViewModel()
        {
            UpdateButton = new RelayCommand(UpdateEmployee);
            _appDbContext = new AppDbContext();
        }

        //private void UpdateEmployee()
        //{
        //    try
        //    {
        //        if (Employee != null && Employee.Id != 0)
        //        {
        //            EmployeeModel existingEmployee = _appDbContext.Employees.Find(Employee.Id);
        //            if (existingEmployee != null)
        //            {
        //                existingEmployee.Name = Employee.Name;
        //                existingEmployee.Email = Employee.Email;
        //                existingEmployee.Address = Employee.Address;
        //                existingEmployee.Contact = Employee.Contact;
        //                _appDbContext.SaveChanges();

        //                MessageBox.Show("Employee updated successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        //            }
        //            else
        //            {
        //                MessageBox.Show("Employee not found");
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Select an employee to update.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("An error occurred while updating the employee: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }
        //}
        private void UpdateEmployee()
        {
            try
            {
                if (Employee != null && Employee.Id != 0)
                {
                    EmployeeModel existingEmployee = _appDbContext.Employees.Find(Employee.Id);
                    if (existingEmployee != null)
                    {
                        // Check if the email is already assigned to another employee
                        EmployeeModel anotherEmployeeWithEmail = _appDbContext.Employees.FirstOrDefault(e => e.Id != Employee.Id && e.Email == Employee.Email);

                        if (anotherEmployeeWithEmail == null)
                        {
                            existingEmployee.Name = Employee.Name;
                            existingEmployee.Email = Employee.Email;
                            existingEmployee.Address = Employee.Address;
                            existingEmployee.Contact = Employee.Contact;
                            _appDbContext.SaveChanges();

                            MessageBox.Show("Employee updated successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            MessageBox.Show("Email is already assigned to another employee.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
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
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating the employee: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
