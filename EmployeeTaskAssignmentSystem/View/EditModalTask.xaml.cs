using EmployeeTaskAssignmentSystem.Model;
using EmployeeTaskAssignmentSystem.Utility;
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
    /// Interaction logic for EditModalTask.xaml
    /// </summary>
    public partial class EditModalTask : Window
    {
        private TaskDataService _taskDataService;
        public TaskModel taskModel { get; set; }

        public EditModalTask()
        {
            _taskDataService = new TaskDataService();
            taskModel = new TaskModel();
            taskModel = _taskDataService.GetSharedTask();
            InitializeComponent();
        }
    }
}
