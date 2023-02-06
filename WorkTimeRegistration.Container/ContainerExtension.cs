using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WorkTimeRegistration.Database.Context;
using WorkTimeRegistration.Database.Initialize;
using WorkTimeRegistration.Database.Services;
using WorkTimeRegistration.Interfaces.Database;
using WorkTimeRegistration.Interfaces.Services;
using WorkTimeRegistration.Interfaces.ViewModels;
using WorkTimeRegistration.ViewModels;

namespace WorkTimeRegistration.Container
{
    public static class ContainerExtension
    {
        public static void AddContainer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<WorkTimeRegistrationContext>
                (options => options.UseSqlServer(configuration.GetConnectionString("WorkTimeRegistration")));

            services.AddScoped<IInitializerDataBase, InitializerDataBase>();
            services.AddScoped<IMainWindowsViewModel, MainWindowViewModel>();
            services.AddScoped<IAddEmployeeViewModel, AddEmployeeViewModel>();
            services.AddScoped<IEmployeeServices, EmployeeServices>();
            services.AddScoped<IEmployeesListViewModel, EmployeesListViewModel>();
            services.AddScoped<IWorkEventService, WorkEventService>();
            services.AddScoped<IAddStartWorkViewModel, AddStartWorkViewModel>();
            services.AddScoped<IAddEndWorkViewModel, AddEndWorkViewModel>();
            services.AddScoped<IWorkEventsListViewModel, WorkEventsListViewModel>();
        }
    }
}
