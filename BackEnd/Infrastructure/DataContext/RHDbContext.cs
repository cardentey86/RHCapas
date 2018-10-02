using Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace Infrastructure.DataContext
{
    public class RHDbContext : DbContext
    {
        public RHDbContext(DbContextOptions<RHDbContext> options)
            : base(options)
        {
           
        }

        DbSet<Persona> Personas { get; set; }
        
    }
}
