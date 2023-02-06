namespace WorkTimeRegistration.Interfaces.ViewModels
{
    public interface IMainWindowsViewModel
    {
        IAddEmployeeViewModel AddEmployeeViewModel { get; }
        IEmployeesListViewModel EmployeesListViewModel { get; }
        IAddStartWorkViewModel AddStartWorkViewModel { get; }
        IAddEndWorkViewModel AddEndWorkViewModel { get; }
        IWorkEventsListViewModel WorkEventsListViewModel { get; }
    }
}
