using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Persona
    {
        private static int UltimoId { get; set; } = 1;
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public int Telefono { get; set; }
        public string Password { get; set; }
        public string Rol {  get; set; }

        public Persona(string cedula, string nombre, string email, int telefono, string pass)
        {
            Id = UltimoId++;
            Cedula = cedula.Trim();
            Nombre = nombre;
            Email = email.Trim();
            Telefono = telefono;
            Password = pass;
            Rol = "Operador";
        }

        public Persona()
        {
            Id = UltimoId++;
            Rol = "Anonimo";
        }

        public void Validar()
        {
            if (String.IsNullOrEmpty(Nombre))
            {
                throw new Exception("No puedes tener el nombre vacio");
            }
            if (!ValidarEmail(Email))
            {
                throw new Exception($"El mail debe contener el arroba (@)");
            }
            if (Cedula == "" || Cedula.Length < 8 || int.Parse(Cedula) < 0)
            {
                throw new Exception("La cedula no puede estar vacia y debe tener mas de 8 caracteres");
            }
            if (String.IsNullOrEmpty(Email))
            {
                throw new Exception("El mail no puede estar vacio");
            }
            if (Telefono < 0)
            {
                throw new Exception("El telefono debe tener 9 numeros y no puede ser negativo");
            }
            if (Cedula.Contains(" ") || Email.Contains(" "))
            {
                throw new Exception("No pueden haber espacios");
            }
            

        }

        public bool ValidarEmail(string email)
        {
            int posArroba = email.IndexOf("@");
            if (posArroba != -1 && posArroba != 0 && posArroba != email.Length - 1)
            {
                return true;
            }
            return false;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Persona)
            {
                Persona p = (Persona)obj;
                return Cedula == p.Cedula ||
                   Email.ToUpper() == p.Email.ToUpper();
            }

            return false;
        }

        public override string ToString()
        {
            return $"{Nombre}";
        }

        
    }
}
