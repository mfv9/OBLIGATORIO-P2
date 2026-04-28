using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Cuenta
    {
        private static int UltimoId { get; set; } = 1;
        public int Id { get; set; }

        public Persona Titular { get; set; }
        public bool  TieneMfa { get; set; }
        public DateTime FechaCambioPass {  get; set; }

        public Cuenta(Persona titular, bool tieneMfa, DateTime fechaCambioPass)
        {
            Id = UltimoId++;
            Titular = titular;
            TieneMfa = tieneMfa;
            FechaCambioPass = fechaCambioPass;
        }
        public void Validar()
        {
            if(Titular == null)
            {
                throw new Exception("El titular no puede estar vacio");
            }
            if(FechaCambioPass > DateTime.Now)
            {
                throw new Exception("La fecha no puede ser mayor a la de hoy");
            }
        }
        public Cuenta()
        {
            Id = UltimoId++;
        }

        public override string ToString()
        {
            return $"{Titular}";
        }
    }
}
