using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Persona
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public int Telefono { get; set; }

        public Persona (string cedula, string nombre, string email, int telefono)
        {
            Cedula = cedula;
            Nombre = nombre;
            Email = email;
            Telefono = telefono;
        }

        public Persona()
        {

        }
    }
}
