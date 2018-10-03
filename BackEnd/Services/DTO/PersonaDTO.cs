using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.DTO
{
    public class PersonaDTO: EntityDTO<int>
    {
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Email { get; set; }
    }
}
