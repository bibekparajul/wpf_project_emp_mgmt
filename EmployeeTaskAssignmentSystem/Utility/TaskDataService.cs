using EmployeeTaskAssignmentSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTaskAssignmentSystem.Utility
{
    public class TaskDataService
    {
        private TaskModel _SharedTasks;
        public TaskModel GetSharedTask()
        {
            return _SharedTasks;
        }
        public void SetSharedTask(TaskModel task)
        {
            _SharedTasks = task;
        }
    }
}
