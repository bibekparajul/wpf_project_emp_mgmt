using EmployeeTaskAssignmentSystem.ViewModel;
using System.ComponentModel.DataAnnotations;

namespace EmployeeTaskAssignmentSystem.Model
{
    public class UserModel : ViewModelBase
    {
        private int _id { get; set; }
        private string _email { get; set; }
        private string _password { get; set; }

        [Key]
        public int Id
        {
            get => _id;
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }

    }
}
