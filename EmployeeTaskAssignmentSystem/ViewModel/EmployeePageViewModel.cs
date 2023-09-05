using EmployeeTaskAssignmentSystem.Command;
using EmployeeTaskAssignmentSystem.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EmployeeTaskAssignmentSystem.ViewModel
{
    public class EmployeePageViewModel: ViewModelBase
    {
        private ICommand _openEmployeeModalCommand;
        public ICommand OpenEmployeeModelCommand
        {
            get
            {
                if (_openEmployeeModalCommand == null)
                {
                    _openEmployeeModalCommand = new RelayCommand(OpenEmployeeModal);
                }
                return _openEmployeeModalCommand;
            }
        }
        private void OpenEmployeeModal()
        {
            ModalEmployee modalView = new ModalEmployee();
            modalView.ShowDialog();
        }
    }
}
