using EmployeeTaskAssignmentSystem.Model;

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
