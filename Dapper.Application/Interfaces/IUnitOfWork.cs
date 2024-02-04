using System;
using System.Collections.Generic;
using System.Text;

namespace Dapper.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IMeetingRepository Meeting { get; }

        IServiceRepository Services { get; }

        IUserRepository Users { get; }

        IReportsRepository Report { get; }
    }
}
