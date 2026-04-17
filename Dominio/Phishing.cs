using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Phishing:Incidente
    {
        public Canal CanalUsado { get; set; }
        public bool EntregoCredenciales { get; set; }

        public bool TransferenciaDatos { get; set; }

        public Phishing(Canal canalUsado, bool entregoCredenciales, bool transferenciaDatos, DateTime fecha, Activo activo, string descripcion, Estado estado, int impacto, int probabilidad):base(fecha,activo,descripcion,estado,impacto,probabilidad)
        {
            CanalUsado = canalUsado;
            EntregoCredenciales = entregoCredenciales;
            TransferenciaDatos = transferenciaDatos;
        }


    }
}
