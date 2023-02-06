using System;
using System.Collections.ObjectModel;
using WorkTimeRegistration.Interfaces.Services;
using WorkTimeRegistration.Interfaces.ViewModels;
using WorkTimeRegistration.Models;

namespace WorkTimeRegistration.ViewModels
{
    public class WorkEventsListViewModel : ViewModelBase, IWorkEventsListViewModel
    {
        private readonly IWorkEventService _workEventService;
        private ObservableCollection<WorkEvent> _workEvents;

        public WorkEventsListViewModel(
            IWorkEventService workEventService,
            IAddStartWorkViewModel addStartWorkViewModel,
            IAddEndWorkViewModel addEndWorkViewModel,
            IEmployeesListViewModel employeesListViewModel)
        {
            _workEvents = new ObservableCollection<WorkEvent>(workEventService.GetAll());
            _workEventService = workEventService;
            addStartWorkViewModel.AddedWorkEvent += OnWorkEventListChanged;
            addEndWorkViewModel.AddedWorkEvent += OnWorkEventListChanged;
            employeesListViewModel.DeletedEmployee += OnWorkEventListChanged;
        }

        public ObservableCollection<WorkEvent> WorkEvents
        {
            get
            {
                return _workEvents;
            }
            set
            {
                SetProperty(ref _workEvents, value);
            }
        }

        private void OnWorkEventListChanged(object? sender, EventArgs e)
        {
            WorkEvents = new ObservableCollection<WorkEvent>(_workEventService.GetAll());
        }
    }
}
