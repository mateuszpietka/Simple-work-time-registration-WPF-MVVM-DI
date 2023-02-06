using System.Collections.Generic;
using WorkTimeRegistration.Models;

namespace WorkTimeRegistration.Interfaces.Services
{
    public interface IEmployeeServices 
    {
        void Add(Employee employee);
        IEnumerable<Employee> GetAll();
        void Delete(Employee employee);
    }
}
