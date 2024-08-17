using Dario.Robles.Store.Service.Domain.Orders.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dario.Robles.Store.Service.Infraestructure.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        public UnitOfWork(DbContext context)
        {
            _context = context;
        }
        public async Task<bool> SaveAsync()
        {
            return ((await _context.SaveChangesAsync()) >= 0);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
