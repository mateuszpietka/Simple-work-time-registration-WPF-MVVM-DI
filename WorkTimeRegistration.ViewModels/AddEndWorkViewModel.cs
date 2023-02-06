using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WorkTimeRegistration.Interfaces.Services;
using WorkTimeRegistration.Interfaces.ViewModels;
using WorkTimeRegistration.Models;

namespace WorkTimeRegistration.ViewModels
{
    public class AddEndWorkViewModel : ViewModelBase, IAddEndWorkViewModel
    {
        private readonly IWorkEventService _workEventService;
        private readonly IEmployeeServices _employeeServices;
        private Employee _selectedEmployee;
        public event EventHandler AddedWorkEvent;

        public AddEndWorkViewModel(
             IWorkEventService workEventService,
             IEmployeeServices employeeServices,
             IAddEmployeeViewModel addEmployeeViewModel,
             IEmployeesListViewModel employeesListViewModel)
        {
            _workEventService = workEventService;
            _employeeServices = employeeServices;
            addEmployeeViewModel.AddedEmployee += OnChangedEmployeeList;
            employeesListViewModel.DeletedEmployee += OnChangedEmployeeList;
            EndWorkCommand = new RelayCommand(OnEndWorkCommand, CanAddEndWork);
            Employees = new ObservableCollection<Employee>(employeeServices.GetAll());
        }

        public ObservableCollection<Employee> Employees { get; set; }
        public Employee SelectedEmployee
        {
            get { return _selectedEmployee; }
            set { SetProperty(ref _selectedEmployee, value, nameof(EndWorkCommand)); }
        }
        public ICommand EndWorkCommand { get; set; }

        private bool CanAddEndWork(object obj)
        {
            return SelectedEmployee != null;
        }

        private void OnEndWorkCommand(object obj)
        {
            var workEvent = new WorkEvent()
            {
                WorkEventType = WorkEventType.Exit,
                DateTime = DateTime.Now,
                EmployeeId = SelectedEmployee.Id,
                Employee = SelectedEmployee,
            };

            _workEventService.Add(workEvent);
            AddedWorkEvent?.Invoke(this, EventArgs.Empty);
        }

        private void OnChangedEmployeeList(object? sender, EventArgs e)
        {
            Employees = new ObservableCollection<Employee>(_employeeServices.GetAll());
            OnPropertyChanged(nameof(Employees));
        }
    }
}