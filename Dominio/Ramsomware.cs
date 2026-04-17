using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Ramsomware:Incidente
    {
        public bool DatosEncriptados {  get; set; }
        public bool HuboExfiltracion { get; set; }

        public Ramsomware(bool datos, bool exfiltracion, DateTime fecha, Activo activo, string descripcion, Estado estado, int impacto, int probabilidad) : base(fecha, activo, descripcion, estado, impacto, probabilidad)
        {
            DatosEncriptados = datos;
            HuboExfiltracion = exfiltracion;
        }
        
    }
}
