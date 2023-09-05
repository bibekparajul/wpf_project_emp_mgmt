﻿using EmployeeTaskAssignmentSystem.Command;
using EmployeeTaskAssignmentSystem.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EmployeeTaskAssignmentSystem.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private object currentPage; 
        public object CurrentPage
        {
            get { return currentPage; }
            set
            {
                currentPage = value;
                OnPropertyChanged(nameof(CurrentPage));
            }
        }

        public ICommand HomeButtonCommand { get; }
        public ICommand EmployeeButtonCommand { get; }

        public MainViewModel()
        {
            // Initialize commands
            HomeButtonCommand = new RelayCommand(ShowHomePage);
            EmployeeButtonCommand = new RelayCommand(ShowEmployeePage);

            ShowHomePage();
        }

        private void ShowHomePage()
        {
            CurrentPage = new HomePageView();
        }

        private void ShowEmployeePage()
        {
            CurrentPage = new EmployeePageView();
        }
    }
}
