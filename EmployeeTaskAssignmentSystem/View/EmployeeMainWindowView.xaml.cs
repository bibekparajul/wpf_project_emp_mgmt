using EmployeeTaskAssignmentSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EmployeeTaskAssignmentSystem.View
{
    /// <summary>
    /// Interaction logic for EmployeeMainWindowView.xaml
    /// </summary>
    public partial class EmployeeMainWindowView : Window
    {
        public EmployeeMainWindowView()
        {
            InitializeComponent();
            MainFrame.Navigate(new EmployeeHomePage());
        }
    }
}
