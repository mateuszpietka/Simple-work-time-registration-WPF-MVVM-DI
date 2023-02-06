using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WorkTimeRegistration.Database.Context;
using WorkTimeRegistration.Interfaces.Services;
using WorkTimeRegistration.Models;

namespace WorkTimeRegistration.Database.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly WorkTimeRegistrationContext _context;

        public EmployeeServices(WorkTimeRegistrationContext context)
        {
            _context = context;
        }

        public void Add(Employee employee)
        {
            _context.Add(employee);
            _context.SaveChanges();
        }

        public void Delete(Employee employee)
        {
            _context.Remove(employee);
            _context.SaveChanges();
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees.Include(x => x.Address).ToList();
        }
    }
}