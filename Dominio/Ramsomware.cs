using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Ramsomware : Incidente
    {
        public bool DatosEncriptados { get; set; }
        public bool HuboExfiltracion { get; set; }

        public Ramsomware(bool datos, bool exfiltracion, DateTime fecha, Activo activo, string descripcion, Estado estado, int impacto, int probabilidad) : base(fecha, activo, descripcion, estado, impacto, probabilidad)
        {
            DatosEncriptados = datos;
            HuboExfiltracion = exfiltracion;
        }

        public override void Validar()
        {
            if (FechaReporte > DateTime.Now)
            {
                throw new Exception("La fecha de reporte no puede ser mayor a la de hoy");
            }

            if (ActivoAfectado == null)
            {
                throw new Exception("No puede no tener activo");
            }

            if (String.IsNullOrEmpty(Descripcion))
            {
                throw new Exception("La descripcion no puede ser vacia");
            }

            if (Impacto < 1 || Impacto > 5)
            {
                throw new Exception("El impacto no puede ser menor a 1 ni mayor a 5");
            }


            if (Probabilidad < 1 || Probabilidad > 5)
            {
                throw new Exception("La probabilidad no puede ser menor a 1 ni mayor a 5");
            }

        }


        public override string ToString()
        {
            return base.ToString() + $" \n Datos Encriptados: {(DatosEncriptados ? "Si" : "No")} \n Exfiltracion: {(HuboExfiltracion ? "Si" : "No")}\n";
        }

        public override double CalcularSeveridad()
        {
            throw new NotImplementedException();
        }
    }
}
