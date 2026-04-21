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
        public string Password { get; set; }

        public Persona(string cedula, string nombre, string email, int telefono, string pass)
        {
            Cedula = cedula;
            Nombre = nombre;
            Email = email;
            Telefono = telefono;
            Password = pass;
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
            if (Cedula == "" || Cedula.Length < 8)
            {
                throw new Exception("La cedula no puede estar vacia y debe tener mas de 8 caracteres");
            }
            if (String.IsNullOrEmpty(Email))
            {
                throw new Exception("El mail no puede estar vacio");
            }
            if (Telefono < 0 || !ValidarNumero(Telefono)) {
                throw new Exception("El telefono debe tener 9 numeros y no puede ser negativo");
            }
            
            
        }

        private bool ValidarEmail(string email)
        {
            int posArroba = email.IndexOf("@");
            if (posArroba != -1 && posArroba != 0 && posArroba != email.Length - 1)
            {
                return true;
            }
            return false;
        }

        private bool ValidarNumero(int numero)
        {
            string aux = numero.ToString();
            if (aux[-1] != '0' && aux[0] != '9')
            {
                if (aux.Length > 8)
                {
                    return true;
                }
            }
            return false;
        }

        public Persona()
        {

        }
    }
}
