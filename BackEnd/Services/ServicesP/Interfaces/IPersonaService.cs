using Core;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Interfaces
{
    public interface IPersonaService
    {
        Task<PersonaDTO> GetPersonById(int Id);
        Task<IEnumerable<PersonaDTO>> GetAllPersons();
        int CreatePersona(PersonaDTO persona);
        bool UpdatePersona(int Id, PersonaDTO persona);
        bool DeletePersona(int Id);
    }
}
