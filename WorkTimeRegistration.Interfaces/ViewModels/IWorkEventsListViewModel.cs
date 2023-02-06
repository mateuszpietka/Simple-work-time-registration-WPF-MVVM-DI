using System.Collections.ObjectModel;
using WorkTimeRegistration.Models;

namespace WorkTimeRegistration.Interfaces.ViewModels
{
    public interface IWorkEventsListViewModel
    {
        ObservableCollection<WorkEvent> WorkEvents { get; }
    }
}
