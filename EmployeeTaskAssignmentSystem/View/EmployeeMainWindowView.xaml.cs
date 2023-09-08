using System.Windows;

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
