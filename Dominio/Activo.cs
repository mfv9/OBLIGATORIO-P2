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

        public Activo()
        {
            Id = UltimoId++;
        }
    }
}
