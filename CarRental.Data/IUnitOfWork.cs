using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CarRental.Data.Repositories.Interfaces;

namespace CarRental.Data
{
    public interface IUnitOfWork
    {
        Task CommitAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
