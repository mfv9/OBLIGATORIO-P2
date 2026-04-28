using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public abstract class Incidente
    {
        private static int UltimoId { get; set; } = 1;
        public int Id { get; set; }
        public DateTime FechaReporte { get; set; }
        public Activo ActivoAfectado { get; set; }
        public string Descripcion { get; set; }
        public Estado Estado {  get; set; }
        public int Impacto { get; set; }
        public int Probabilidad { get; set; }

        public Incidente(DateTime fecha, Activo activo, string descripcion, Estado estado, int impacto, int probabilidad)
        {
            Id = UltimoId++;
            FechaReporte = fecha;
            ActivoAfectado = activo;
            Descripcion = descripcion;
            Estado = estado;
            Impacto = impacto;
            Probabilidad = probabilidad;
        }

        public abstract void Validar();

        public Incidente()
        {
            Id = UltimoId++;

        }

        public override string ToString()
        {
            return $"{ActivoAfectado} - {Estado} - {Impacto} - {Probabilidad}";
        }
    }
}
