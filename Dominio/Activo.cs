using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Activo
    {
        private static int UltimoId { get; set; } = 1;
        public int Id { get; set; }

        public string Nombre { get; set; }
        public TipoActivo Activo { get; set; }
    }
}
