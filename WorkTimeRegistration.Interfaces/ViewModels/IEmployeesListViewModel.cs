using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WorkTimeRegistration.Models;

namespace WorkTimeRegistration.Interfaces.ViewModels
{
    public interface IEmployeesListViewModel
    {
        event EventHandler DeletedEmployee;
        ObservableCollection<Employee> Employees { get; }
        ICommand DeleteEmployeeCommand { get; }
    }
}
