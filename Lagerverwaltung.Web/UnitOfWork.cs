using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Lagerverwaltung.Web.Models;
using Lagerverwaltung.Web.Repositories;
using Lagerverwaltung.Web.Repositories.Interfaces;

namespace Lagerverwaltung.Web
{
    public class UnitOfWork/* : IDisposable*/
    {
       /* private readonly ApplicationDbContext _dbContext = new ApplicationDbContext();

        private IGeschäftsfallRepo _geschäftsfallRepo;

        public IGeschäftsfallRepo GeschäftsfallRepo
        {
            get
            {
                if (_geschäftsfallRepo == null) _geschäftsfallRepo = new GeschäftsfallRepo(_dbContext);
                return _geschäftsfallRepo;
            }
        }


        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }*/
    }
}