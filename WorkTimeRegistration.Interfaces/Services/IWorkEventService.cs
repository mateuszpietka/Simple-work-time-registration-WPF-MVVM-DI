using System.Collections.Generic;
using WorkTimeRegistration.Models;

namespace WorkTimeRegistration.Interfaces.Services
{
    public interface IWorkEventService
    {
        void Add(WorkEvent workEvent);
        IEnumerable<WorkEvent> GetAll();
    }
}