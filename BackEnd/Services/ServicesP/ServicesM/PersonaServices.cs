using Core;
using Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Services.UnitOfWork;
using AutoMapper;
using Services.DTO;
using System.Threading.Tasks;
using System.Linq;

namespace Services.ServicesP.ServicesM
{
    public class PersonaService: IPersonaService
    {
        private readonly UnitOfWorkk _unitOfWork;
        protected readonly IMapper _mapper;

        public PersonaService(UnitOfWorkk unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public int CreatePersona(PersonaDTO persona)
        {
            throw new NotImplementedException();
        }

        public bool DeletePersona(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PersonaDTO>> GetAllPersons()
        {
            var person = await _unitOfWork.PersonaRepository.GetAll();
            if (person.Any())
            {
                return _mapper.Map<List<PersonaDTO>>(person).ToList();
            }
            return null;
        }

        public async Task<PersonaDTO> GetPersonById(int Id)
        {
            var person = await _unitOfWork.PersonaRepository.GetById(Id);
            if (person != null)
            {
                return _mapper.Map<PersonaDTO>(person);
            }
            return null;
        }

        public bool UpdatePersona(int Id, PersonaDTO persona)
        {
            throw new NotImplementedException();
        }
    }
}
