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

        public Cuenta()
        {
            Id = UltimoId++;
        }
    }
}
