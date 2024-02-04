using Dapper.Application.Interfaces;
using Dapper.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dapper.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        public UnitOfWork(IMeetingRepository meeting, IUserRepository users, IServiceRepository service,IReportsRepository reports)
        {
            Meeting = meeting;
            Users = users;
            Services = service;
            Report= reports;
        }
        public IMeetingRepository Meeting { get; }
        public IUserRepository Users { get; }
        public IServiceRepository Services { get; }
        public IReportsRepository Report { get; }

    }
}
