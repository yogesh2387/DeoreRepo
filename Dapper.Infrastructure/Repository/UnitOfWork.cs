using Dapper.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dapper.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        public UnitOfWork(IProductRepository productRepository, IUserRepository users)
        {
            Products = productRepository;
            Users = users;
        }
        public IProductRepository Products { get; }
        public IUserRepository Users { get; }
    }
}
