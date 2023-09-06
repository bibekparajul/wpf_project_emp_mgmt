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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EmployeeTaskAssignmentSystem.View
{
    /// <summary>
    /// Interaction logic for EmployeePageView.xaml
    /// </summary>
    public partial class EmployeePageView : Page
    {
        public EmployeePageView()
        {
            InitializeComponent();
        }

        private void Grid_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            // Check if the mouse click occurred outside of the ListView
            if (!IsMouseInsideListView(EmployeeItemList, e.GetPosition(EmployeeItemList)))
            {
                // Clear the selection by setting SelectedItem to null
                EmployeeItemList.SelectedItem = null;
            }
        }

        // Helper method to check if the mouse click occurred inside the ListView
        private bool IsMouseInsideListView(ListView listView, Point mousePosition)
        {
            var listViewBounds = VisualTreeHelper.GetDescendantBounds(listView);
            return listViewBounds.Contains(mousePosition);
        }

    }
}
