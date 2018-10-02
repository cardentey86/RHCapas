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
using Core.Entity;
using Core.Interfaces;

namespace Services.ServicesP.ServicesM
{
    public class PersonaService : IPersonaService
    {
        private readonly UnitOfWorkk _unitOfWork;
        protected readonly IMapper _mapper;

        public PersonaService(UnitOfWorkk unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<PersonaDTO> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PersonaDTO>> GetAll()
        {
            var person = await _unitOfWork.PersonaRepository.GetAll();
            if (person.Any())
            {
                return _mapper.Map<List<PersonaDTO>>(person).ToList();
            }
            return null;
        }

        public int Create(DTO.PersonaDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(int Id, DTO.PersonaDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int Id)
        {
            throw new NotImplementedException();
        }

        //public Task<TEntity> GetById(int Id)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<IEnumerable<PersonaDTO>> GetAll()
        //{
        //    var person = await _unitOfWork.PersonaRepository.GetAll();
        //    if (person.Any())
        //    {
        //        return _mapper.Map<List<PersonaDTO>>(person).ToList();
        //    }
        //    return null;
        //}

        //public int Create(TEntity entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool Update(int Id, TEntity entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool Delete(int Id)
        //{
        //    throw new NotImplementedException();
        //}


        //public int Create(PersonaDTO persona)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool Delete(int Id)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<IEnumerable<PersonaDTO>> GetAll()
        //{
        //    var person = await _unitOfWork.PersonaRepository.GetAll();
        //    if (person.Any())
        //    {
        //        return _mapper.Map<List<PersonaDTO>>(person).ToList();
        //    }
        //    return null;
        //}

        //public async Task<PersonaDTO> GetById(int Id)
        //{
        //    var person = await _unitOfWork.PersonaRepository.GetById(Id);
        //    if (person != null)
        //    {
        //        return _mapper.Map<PersonaDTO>(person);
        //    }
        //    return default(PersonaDTO);
        //}

        //public bool Update(int Id, PersonaDTO entity)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
