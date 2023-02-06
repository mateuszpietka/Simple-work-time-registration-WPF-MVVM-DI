using Microsoft.EntityFrameworkCore;
using System.Linq;
using WorkTimeRegistration.Database.Context;
using WorkTimeRegistration.Interfaces.Database;

namespace WorkTimeRegistration.Database.Initialize
{
    public class InitializerDataBase : IInitializerDataBase
    {
        private readonly WorkTimeRegistrationContext _context;

        public InitializerDataBase(WorkTimeRegistrationContext context)
        {
            _context = context;
        }

        public void Initialize()
        {
            var pendingMigrations = _context.Database.GetPendingMigrations();

            if (pendingMigrations != null && pendingMigrations.Any())
            {
                _context.Database.Migrate();
            }
        }
    }
}
