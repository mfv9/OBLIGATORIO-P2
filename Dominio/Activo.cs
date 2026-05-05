using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Dominio
{
    public class Activo
    {
        private static int UltimoId { get; set; } = 1;
        public string CodigoAlfanumerico { get; set; }

        public string Nombre { get; set; }
        public TipoActivo UnActivo { get; set; }
        public int Criticidad { get; set; }
        public Cuenta CuentaResponsable { get; set; }
        public bool TieneBackup { get; set; }



        public Activo(string nombre, TipoActivo activo, int criticidad, Cuenta cuenta, bool backup)
        {

            Nombre = nombre;
            UnActivo = activo;
            Criticidad = criticidad;
            CuentaResponsable = cuenta;
            TieneBackup = backup;
            CodigoAlfanumerico = CalcularCodigo();
        }

        public string CalcularCodigo()
        {
            string nuevoId;
            if (UltimoId > 99)
            {
               nuevoId = Nombre + "0" +  UltimoId++;
            }else if(UltimoId > 9)
            {
                nuevoId = Nombre + "00" + UltimoId++;
            }
            else
            {
                nuevoId = Nombre + "000" + UltimoId++;
            }
            return nuevoId;
        }

        public void Validar()
        {
            if (String.IsNullOrEmpty(Nombre))
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

        public override string ToString()
        {
            return $"{Nombre} - Criticidad: {Criticidad} - Tipo de activo: {UnActivo} - Cuenta Responsable: {CuentaResponsable} \n ";
        }



        public Activo()
        {
            CodigoAlfanumerico = CalcularCodigo();
        }
    }
}
