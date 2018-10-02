using Core;
using Core.Entity;
using Infrastructure.DataContext;
using Infrastructure.Repository;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.UnitOfWork
{
    public class UnitOfWorkk: IDisposable
    {
        private RHDbContext _context;
        private GenericRepository<Persona, int> _genericRepository;
        //private GenericRepository<Product> _productRepository;

        public UnitOfWorkk(RHDbContext context)
        {
            _context = context;
        }

        public GenericRepository<Persona, int> PersonaRepository
        {
            get
            {
                if (this._genericRepository == null)
                    this._genericRepository = new GenericRepository<Persona, int>(_context);
                return _genericRepository;
            }
        }

        public async Task<int> SaveChanges(CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                return await _context.SaveChangesAsync(cancellationToken);
            }
            catch(Exception e)
            {
                throw e;
            }
            
        }       

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
