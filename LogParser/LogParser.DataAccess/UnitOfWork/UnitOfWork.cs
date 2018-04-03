using System;
using System.Threading.Tasks;
using LogParser.DataAccess.Entities;
using LogParser.DataAccess.Repository;

namespace LogParser.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private LogParserContext context;
        private IRepository<ServerEntity> _serverRepository;
        private IRepository<RequestEntity> _requestRepository;
        private IRepository<RequestParameterEntity> _requestParameterRepository;

        public IRepository<RequestEntity> RequestRepository
        {
            get
            {
                return this._requestRepository;
            }
        }

        public IRepository<RequestParameterEntity> RequestParameterRepository
        {
            get
            {
                return this._requestParameterRepository;
            }
        }

        public IRepository<ServerEntity> ServerRepository
        {
            get
            {
                return this._serverRepository;
            }
        }

        public UnitOfWork(LogParserContext context,
            IRepository<RequestEntity> requestRepository,
            IRepository<RequestParameterEntity> requestParameterRepository,
            IRepository<ServerEntity> serverRepository)
        {
            this.context = context;

            this._requestRepository = requestRepository;
            this._requestParameterRepository = requestParameterRepository;
            this._serverRepository = serverRepository;
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
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
