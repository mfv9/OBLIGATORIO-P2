using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Activo
    {
        private static int UltimoId { get; set; } = 0001;
        public int Id { get; set; }

        public string Nombre { get; set; }
        public TipoActivo UnActivo { get; set; }
        public int Criticidad { get; set; }
        public Cuenta CuentaResponsable { get; set; }
        public bool TieneBackup { get; set; }
        

        public Activo(string nombre, TipoActivo activo, int criticidad, Cuenta cuenta, bool backup)
        {
            Id = UltimoId++;
            Nombre = nombre;
            UnActivo = activo;
            Criticidad = criticidad;
            CuentaResponsable = cuenta;
            TieneBackup = backup;

        }

        //TODO
        public void CalcularCodigo()
        {
            
        }

        public void Validar()
        {
            if (Nombre == "")
            {
                throw new Exception("No puedes tener el nombre vacio");
            }
            if (Criticidad < 1 || Criticidad > 5)
            {
                throw new Exception("La criticidad debe ser un numero del 1 al 5");
            }
            if (CuentaResponsable == null)
            {
                throw new Exception("La cuenta no puede estar vacia");

            }
        }

        public Activo()
        {
            Id = UltimoId++;
        }
    }
}
