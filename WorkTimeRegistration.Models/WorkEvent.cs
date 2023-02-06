using System;

namespace WorkTimeRegistration.Models
{
    public class WorkEvent
    {
        public int Id { get; set; }
        public WorkEventType WorkEventType { get; set; }
        public DateTime DateTime { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}