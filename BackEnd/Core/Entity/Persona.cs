using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Persona : Entity<int>
    {
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Email { get; set; }
    }
}
