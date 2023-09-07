using EmployeeTaskAssignmentSystem.Command;
using EmployeeTaskAssignmentSystem.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EmployeeTaskAssignmentSystem.ViewModel
{
    public class LandingWindowViewModel: ViewModelBase
    {
        public ICommand LoginWindowButtonCommand { get; set; }
        public ICommand EmployeeWindowViewButtonCommand { get; set; }

        public LandingWindowViewModel() {
            LoginWindowButtonCommand = new RelayCommand(OpenLoginWindow);
            EmployeeWindowViewButtonCommand = new RelayCommand(OpenEmployeeWindow);
        }

        private void OpenLoginWindow()
        {
            LoginView mainWindow = new LoginView();
            mainWindow.Show();
            Application.Current.MainWindow.Close();
        }

        private void OpenEmployeeWindow()
        {
            EmployeeDashBoardLoginView employeeDashBoardLoginView = new EmployeeDashBoardLoginView();
            employeeDashBoardLoginView.Show();
            Application.Current.MainWindow.Close();
        }

    }
}
