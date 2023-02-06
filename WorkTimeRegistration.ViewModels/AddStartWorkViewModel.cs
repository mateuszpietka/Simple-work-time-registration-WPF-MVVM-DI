using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WorkTimeRegistration.Interfaces.Services;
using WorkTimeRegistration.Interfaces.ViewModels;
using WorkTimeRegistration.Models;

namespace WorkTimeRegistration.ViewModels
{
    public class AddStartWorkViewModel : ViewModelBase, IAddStartWorkViewModel
    {
        private readonly IWorkEventService _workEventService;
        private readonly IEmployeeServices _employeeServices;
        private Employee _selectedEmployee;
        public event EventHandler AddedWorkEvent;

        public AddStartWorkViewModel(
            IWorkEventService workEventService,
            IEmployeeServices employeeServices,
            IAddEmployeeViewModel addEmployeeViewModel,
            IEmployeesListViewModel employeesListViewModel)
        {
            _workEventService = workEventService;
            _employeeServices = employeeServices;
            addEmployeeViewModel.AddedEmployee += OnChangedEmployeeList;
            employeesListViewModel.DeletedEmployee += OnChangedEmployeeList;
            StartWorkCommand = new RelayCommand(OnStartWorkCommand, CanAddStartWork);
            Employees = new ObservableCollection<Employee>(employeeServices.GetAll());
        }

        public ObservableCollection<Employee> Employees { get; set; }
        public Employee SelectedEmployee
        {
            get { return _selectedEmployee; }
            set { SetProperty(ref _selectedEmployee, value, nameof(StartWorkCommand)); }
        }
        public ICommand StartWorkCommand { get; set; }

        private bool CanAddStartWork(object obj)
        {
            return SelectedEmployee != null;
        }

        private void OnStartWorkCommand(object obj)
        {
            var workEvent = new WorkEvent()
            {
                WorkEventType = WorkEventType.Enter,
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