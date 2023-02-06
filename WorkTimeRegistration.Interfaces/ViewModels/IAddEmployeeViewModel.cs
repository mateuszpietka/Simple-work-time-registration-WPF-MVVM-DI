using System;
using System.Windows.Input;

namespace WorkTimeRegistration.Interfaces.ViewModels
{
    public interface IAddEmployeeViewModel
    {
        event EventHandler AddedEmployee;
        string FirstName { get; }
        string LastName { get; }
        string Postition { get; }
        string SreetName { get; }
        string HouseNumber { get; }
        string PostCode { get; }
        string City { get; }
        ICommand AddEmployeeCommand { get; }
    }
}