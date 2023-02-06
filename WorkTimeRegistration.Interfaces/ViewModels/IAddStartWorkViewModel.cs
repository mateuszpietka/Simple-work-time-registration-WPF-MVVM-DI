using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WorkTimeRegistration.Models;

namespace WorkTimeRegistration.Interfaces.ViewModels
{
    public interface IAddStartWorkViewModel
    {
        event EventHandler AddedWorkEvent;
        ObservableCollection<Employee> Employees { get; }
        Employee SelectedEmployee { get; set; }
        ICommand StartWorkCommand { get; set; }
    }
}
