using Core;
using Core.Entity;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Interfaces
{
    public interface IPersonaService
    {
        Task<PersonaDTO> GetById(int Id);
        Task<IEnumerable<PersonaDTO>> GetAll();
        int Create(PersonaDTO entity);
        bool Update(int Id, PersonaDTO entity);
        bool Delete(int Id);
    }
}
