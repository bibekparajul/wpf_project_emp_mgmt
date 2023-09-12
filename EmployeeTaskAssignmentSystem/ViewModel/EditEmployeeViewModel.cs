using EmployeeTaskAssignmentSystem.Command;
using EmployeeTaskAssignmentSystem.Data;
using EmployeeTaskAssignmentSystem.Model;
using EmployeeTaskAssignmentSystem.View;
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
        //private void UpdateEmployee()
        //{
        //    try
        //    {
        //        if (Employee != null && Employee.Id != 0)
        //        {
        //            EmployeeModel existingEmployee = _appDbContext.Employees.Find(Employee.Id);
        //            if (existingEmployee != null)
        //            {
        //                // Check if the email is already assigned to another employee
        //                EmployeeModel anotherEmployeeWithEmail = _appDbContext.Employees.FirstOrDefault(e => e.Id != Employee.Id && e.Email == Employee.Email);

        //                if (anotherEmployeeWithEmail == null)
        //                {
        //                    existingEmployee.Name = Employee.Name;
        //                    existingEmployee.Email = Employee.Email;
        //                    existingEmployee.Address = Employee.Address;
        //                    existingEmployee.Contact = Employee.Contact;
        //                    _appDbContext.SaveChanges();

        //                    MessageBox.Show("Employee updated successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        //                    Application.Current.Windows.OfType<EditModalEmployee>().FirstOrDefault()?.Close();

        //                }
        //                else
        //                {
        //                    MessageBox.Show("Email is already assigned to another employee.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //                }
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

        //private void UpdateEmployee()
        //{
        //    try
        //    {
        //        if (Employee != null && Employee.Id != 0)
        //        {
        //            // Check if the contact number is valid
        //            if (!IsValidContact(Employee.Contact))
        //            {
        //                MessageBox.Show("Invalid contact number. Please enter a 10-digit number.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //                return;
        //            }

        //            EmployeeModel existingEmployee = _appDbContext.Employees.Find(Employee.Id);
        //            if (existingEmployee != null)
        //            {
        //                // Check if the email is already assigned to another employee
        //                EmployeeModel anotherEmployeeWithEmail = _appDbContext.Employees.FirstOrDefault(e => e.Id != Employee.Id && e.Email == Employee.Email);

        //                // Check if the contact number is already assigned to another employee
        //                EmployeeModel anotherEmployeeWithContact = _appDbContext.Employees.FirstOrDefault(e => e.Id != Employee.Id && e.Contact == Employee.Contact);

        //                if (anotherEmployeeWithEmail == null)
        //                {
        //                    if (anotherEmployeeWithContact == null)
        //                    {
        //                        existingEmployee.Name = Employee.Name;
        //                        existingEmployee.Email = Employee.Email;
        //                        existingEmployee.Address = Employee.Address;
        //                        existingEmployee.Contact = Employee.Contact;
        //                        _appDbContext.SaveChanges();

        //                        MessageBox.Show("Employee updated successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        //                        Application.Current.Windows.OfType<EditModalEmployee>().FirstOrDefault()?.Close();
        //                    }
        //                    else
        //                    {
        //                        MessageBox.Show("Contact number is already assigned to another employee.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //                    }
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Email is already assigned to another employee.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //                }
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
                    // Check if the contact number is valid
                    if (!IsValidContact(Employee.Contact))
                    {
                        MessageBox.Show("Invalid contact number. Please enter a 10-digit number.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    if (!IsValidEmail(Employee.Email))
                    {
                        MessageBox.Show("Invalid email address format. Please enter a valid email address.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    EmployeeModel existingEmployee = _appDbContext.Employees.Find(Employee.Id);
                    if (existingEmployee != null)
                    {
                        // Check if the email is already assigned to another employee
                        EmployeeModel anotherEmployeeWithEmail = _appDbContext.Employees.FirstOrDefault(e => e.Id != Employee.Id && e.Email == Employee.Email);

                        // Check if the contact number is already assigned to another employee
                        EmployeeModel anotherEmployeeWithContact = _appDbContext.Employees.FirstOrDefault(e => e.Id != Employee.Id && e.Contact == Employee.Contact);

                        if (anotherEmployeeWithEmail == null)
                        {
                            if (anotherEmployeeWithContact == null)
                            {
                                existingEmployee.Name = Employee.Name;
                                existingEmployee.Email = Employee.Email;
                                existingEmployee.Address = Employee.Address;
                                existingEmployee.Contact = Employee.Contact;

                                // Save changes to the database context
                                _appDbContext.SaveChanges();

                                MessageBox.Show("Employee updated successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                                Application.Current.Windows.OfType<EditModalEmployee>().FirstOrDefault()?.Close();
                            }
                            else
                            {
                                MessageBox.Show("Contact number is already assigned to another employee.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
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
            finally
            {
                // Add debugging messages to check the state of the Employee object and DbContext
                Console.WriteLine("Employee object state: " + _appDbContext.Entry(Employee).State);
            }
        }

        private bool IsValidContact(long? contact)
        {
            return contact.HasValue && contact.ToString().Length == 10;
        }
        private bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return System.Text.RegularExpressions.Regex.IsMatch(email, pattern);
        }

    }
}
