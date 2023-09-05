using EmployeeTaskAssignmentSystem.View;
using System.Windows;

namespace EmployeeTaskAssignmentSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new HomePageView());

        }
    }
}
