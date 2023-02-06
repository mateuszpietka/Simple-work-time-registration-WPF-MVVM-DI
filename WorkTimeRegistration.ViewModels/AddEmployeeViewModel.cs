using System;
using System.Windows.Input;
using WorkTimeRegistration.Interfaces.Services;
using WorkTimeRegistration.Interfaces.ViewModels;
using WorkTimeRegistration.Models;

namespace WorkTimeRegistration.ViewModels
{
    public class AddEmployeeViewModel : ViewModelBase, IAddEmployeeViewModel
    {
        private readonly IEmployeeServices _services;
        private string _firstName;
        private string _lastName;
        private string _position;
        public event EventHandler AddedEmployee;

        public AddEmployeeViewModel(IEmployeeServices services)
        {
            AddEmployeeCommand = new RelayCommand(OnAddEmployee, CanAdd);
            _services = services;
        }

        public string FirstName
        {
            get => _firstName;
            set => SetProperty(ref _firstName, value, nameof(AddEmployeeCommand));
        }
        public string LastName
        {
            get => _lastName;
            set => SetProperty(ref _lastName, value, nameof(AddEmployeeCommand));
        }
        public string Postition
        {
            get => _position;
            set => SetProperty(ref _position, value, nameof(AddEmployeeCommand));
        }
        public string SreetName { get; set; }
        public string HouseNumber { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public ICommand AddEmployeeCommand { get; }

        private bool CanAdd(object obj)
        {
            return !string.IsNullOrEmpty(_firstName) && !string.IsNullOrEmpty(_lastName) && !string.IsNullOrEmpty(_position);
        }

        private void OnAddEmployee(object obj)
        {
            var employee = new Employee()
            {
                FirstName = FirstName,
                LastName = LastName,
                Postition = Postition,
                Address = new Address()
                {
                    SreetName = SreetName,
                    City = City,
                    HouseNumber = HouseNumber,
                    PostCode = PostCode,
                }
            };

            _services.Add(employee);
            AddedEmployee?.Invoke(this, new EventArgs());
        }
    }
}
