using EmployeeTaskAssignmentSystem.Data;
using EmployeeTaskAssignmentSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using EmployeeTaskAssignmentSystem.Command;

namespace EmployeeTaskAssignmentSystem.ViewModel
{
    public class LoginWindowViewModel : ViewModelBase
    {
        public AppDbContext appDbContext { get; set; }
        public ICommand LoginButtonCommand { get; set; }
        private UserModel _user { get; set; }
        public UserModel User
        {
            get => _user;
            set
            {
                if (_user != value)
                {
                    _user = value;
                    OnPropertyChanged(nameof(User));
                }
            }
        }

        public LoginWindowViewModel()
        {
            User = new UserModel();
            appDbContext = new AppDbContext();
            LoginButtonCommand = new RelayCommand(GrantAccess);

        }
        private void GrantAccess()
        {
            //MainWindow mainWindow = new MainWindow();
            //mainWindow.Show();

            bool userFound = appDbContext.Users.Any(user => user.Email == User.Email && user.Password == User.Password);
            if (userFound)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Application.Current.MainWindow.Close();
            }
            else
            {
                MessageBox.Show("Invalid credentials");
            }
        }

    }
}
