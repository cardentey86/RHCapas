using AutoMapper;
using Core;
using Core.Entity;
using Core.Interfaces;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Text;



namespace Services.Mapping
{
    public class Mapping: Profile
    {
        public Mapping()
        {
            CreateMap<Persona, PersonaDTO>().ReverseMap();
            CreateMap<PersonaDTO, Persona>().ReverseMap();
            //CreateMap<Entity<int>, EntityDTO<int>>().ReverseMap();
        }

       
    }
}
