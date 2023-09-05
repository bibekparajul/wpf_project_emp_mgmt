using EmployeeTaskAssignmentSystem.Data;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EmployeeTaskAssignmentSystem
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // To establish the connection 
            DatabaseFacade facade = new DatabaseFacade(new AppDbContext());
            facade.EnsureCreated();
        }
    }
}
