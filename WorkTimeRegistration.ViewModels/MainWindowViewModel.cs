using WorkTimeRegistration.Interfaces.ViewModels;

namespace WorkTimeRegistration.ViewModels
{
    public class MainWindowViewModel : IMainWindowsViewModel
    {
        public MainWindowViewModel(
            IAddEmployeeViewModel addEmployeeViewModel,
            IEmployeesListViewModel employeesListViewModel,
            IAddStartWorkViewModel addStartWorkViewModel,
            IAddEndWorkViewModel addEndWorkViewModel,
            IWorkEventsListViewModel workEventsListViewModel)
        {
            AddEmployeeViewModel = addEmployeeViewModel;
            EmployeesListViewModel = employeesListViewModel;
            AddStartWorkViewModel = addStartWorkViewModel;
            AddEndWorkViewModel = addEndWorkViewModel;
            WorkEventsListViewModel = workEventsListViewModel;
        }

        public IAddEmployeeViewModel AddEmployeeViewModel { get; }
        public IEmployeesListViewModel EmployeesListViewModel { get; }
        public IAddStartWorkViewModel AddStartWorkViewModel { get; }
        public IAddEndWorkViewModel AddEndWorkViewModel { get; }
        public IWorkEventsListViewModel WorkEventsListViewModel { get; }
    }
}