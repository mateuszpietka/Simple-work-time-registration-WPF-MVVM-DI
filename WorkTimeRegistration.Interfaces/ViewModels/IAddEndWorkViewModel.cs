using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WorkTimeRegistration.Models;

namespace WorkTimeRegistration.Interfaces.ViewModels
{
    public interface IAddEndWorkViewModel
    {
        event EventHandler AddedWorkEvent;
        ObservableCollection<Employee> Employees { get; }
        Employee SelectedEmployee { get; set; }
        ICommand EndWorkCommand { get; set; }
    }
}
