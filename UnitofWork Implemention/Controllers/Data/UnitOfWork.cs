using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using UnitofWork_Implemention.Core.IConfiguration;
using UnitofWork_Implemention.Core.IRepositories;
using UnitofWork_Implemention.Core.Repositories;

namespace UnitofWork_Implemention.Controllers.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDBContext _context;
        private readonly ILogger _logger;

        public IUserRepository Users { get; private set; }

        public UnitOfWork(AppDBContext context, ILoggerFactory logger)
        {
            _context = context;
            _logger = logger.CreateLogger("logs");

            Users = new UserRepository(_context, _logger);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
