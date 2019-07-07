using System;
using System.Threading;
using System.Threading.Tasks;
using CarRental.Data.Context;

namespace CarRental.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EntityContext _context;

        public UnitOfWork(EntityContext context)
        {
            _context = context;
        }
        
        public virtual Task CommitAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (_context == null)
            {
                throw new InvalidOperationException();
            }
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}