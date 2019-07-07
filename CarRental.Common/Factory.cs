using System;
using Microsoft.Extensions.DependencyInjection;

namespace CarRental.Common
{
    internal class Factory<T> : IFactory<T>
    {
        private readonly IServiceProvider _serviceProvider;

        public Factory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public T Create() => _serviceProvider.GetService<T>();
    }
}
