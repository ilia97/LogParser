using System;
using System.Threading.Tasks;
using LogParser.DataAccess.Entities;
using LogParser.DataAccess.Repository;

namespace LogParser.DataAccess.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<RequestEntity> RequestRepository { get; }

        IRepository<RequestParameterEntity> RequestParameterRepository { get; }

        IRepository<ServerEntity> ServerRepository { get; }

        Task Save();
    }
}
