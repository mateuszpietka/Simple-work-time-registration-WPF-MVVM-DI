using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WorkTimeRegistration.Interfaces.Services;
using WorkTimeRegistration.Interfaces.ViewModels;
using WorkTimeRegistration.Models;

namespace WorkTimeRegistration.ViewModels
{
    public class EmployeesListViewModel : ViewModelBase, IEmployeesListViewModel
    {
        private ObservableCollection<Employee> _employees;
        private readonly IEmployeeServices _employeeServices;
        public event EventHandler DeletedEmployee;

        public EmployeesListViewModel(IEmployeeServices employeeServices, IAddEmployeeViewModel addEmployeeViewModel)
        {
            _employeeServices = employeeServices;
            addEmployeeViewModel.AddedEmployee += OnAddedEmployee;
            _employees = new ObservableCollection<Employee>(_employeeServices.GetAll());
            DeleteEmployeeCommand = new RelayCommand(OnDeleteEmployeeCommand);
        }

        public ObservableCollection<Employee> Employees
        {
            get
            {
                return _employees;
            }
            set
            {
                SetProperty(ref _employees, value);
            }
        }

        public ICommand DeleteEmployeeCommand { get; }

        private void OnAddedEmployee(object? sender, EventArgs e)
        {
            Employees = new ObservableCollection<Employee>(_employeeServices.GetAll());
        }

        private void OnDeleteEmployeeCommand(object obj)
        {
            if (obj is Employee employee)
            {
                _employeeServices.Delete(employee);
                Employees.Remove(employee);
                DeletedEmployee?.Invoke(this, EventArgs.Empty);

            }
        }
    }
}
