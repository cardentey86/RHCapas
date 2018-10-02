using Core;
using Infrastructure.DataContext;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.UnitOfWork
{
    public class UnitOfWorkk : IDisposable
    {
        private RHDbContext _context;
        private GenericRepository<Persona, int> _personaRepository;
        //private GenericRepository<Product> _productRepository;



        public UnitOfWorkk(RHDbContext context)
        {
            _context = context;
        }

        public GenericRepository<Persona, int> PersonaRepository
        {
            get
            {
                if (this._personaRepository == null)
                    this._personaRepository = new GenericRepository<Persona, int>(_context);
                return _personaRepository;
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
