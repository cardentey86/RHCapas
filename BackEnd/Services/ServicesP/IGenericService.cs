using Core.Entity;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServicesP
{
    public interface IGenericService<TDTO, TEntity>: IServices where TDTO: EntityDTO<int> where TEntity: Entity<int>
    {
        Task<TDTO> GetById(int Id);
        Task<IEnumerable<TDTO>> GetAll();
        Task<TDTO> Create(TDTO entity);
        bool Update(int Id, TDTO entity);
        bool Delete(int Id);
        Task<int> SaveChanges();
    }
}
