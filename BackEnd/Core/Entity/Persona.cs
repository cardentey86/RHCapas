using System;

namespace Core.Entity;

public class Persona : Entity<int>
{
    public string Nombre { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public string Email { get; set; }
	public string DevelopD { get; set; }
	public string MasterM { get; set; }
}

