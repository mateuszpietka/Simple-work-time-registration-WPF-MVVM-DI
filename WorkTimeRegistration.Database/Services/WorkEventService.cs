using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WorkTimeRegistration.Database.Context;
using WorkTimeRegistration.Interfaces.Services;
using WorkTimeRegistration.Models;

namespace WorkTimeRegistration.Database.Services
{
    public class WorkEventService : IWorkEventService
    {
        private readonly WorkTimeRegistrationContext _context;

        public WorkEventService(WorkTimeRegistrationContext context)
        {
            _context = context;
        }

        public void Add(WorkEvent workEvent)
        {
            _context.WorkEvents.Add(workEvent);
            _context.SaveChanges();
        }

        public IEnumerable<WorkEvent> GetAll()
        {
            return _context.WorkEvents.Include(x => x.Employee).ToList();
        }
    }
}