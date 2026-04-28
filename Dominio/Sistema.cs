using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Sistema
    {
        private List<Cuenta> _cuentas = new List<Cuenta>();
        private List<Persona> _personas = new List<Persona>();
        private List<Activo> _activos = new List<Activo>();
        private List<Incidente> _incidentes = new List<Incidente>();

        public Sistema()
        {
            PrecargarDatos();
        }

        public void AltaCuenta(Cuenta cuenta)
        {
            cuenta.Validar();

            _cuentas.Add(cuenta);


        }

        public void AltaPersona(Persona persona)
        {
            persona.Validar();
            if (_personas.Contains(persona))
            {
                throw new Exception("Ya existe la cedula o el mail");
            }
            _personas.Add(persona);

        }

        public void AltaActivo(Activo activo)
        {
            activo.Validar();
            _activos.Add(activo);
        }

        public void AltaIncidentes(Incidente incidente)
        {
            incidente.Validar();
            _incidentes.Add(incidente);
        }

        public List<Cuenta> GetCuentas()
        {
            return _cuentas;
        }

        public List<Persona> GetPersonas()
        {
            return _personas;
        }

        public List<Activo> GetActivos()
        {
            return _activos;
        }

        public List<Incidente> GetIncidentes()
        {
            return _incidentes;
        }

        //public bool ValidacionAltaPersona(Persona persona)
        //{
        //    foreach (Persona p in _personas)
        //    {
        //        if (p.Cedula == persona.Cedula)
        //        {
        //            return false;
        //        }
        //        if (p.Email == persona.Email)
        //        {
        //            return false;
        //        }

        //    }
        //    return true;
        //}

        private void PrecargarDatos()
        {
            Persona p1 = new Persona("49067314", "Juan", "juan123@gmail.com", 098337697, "xxx");
            Persona p2 = new Persona("51234567", "Nicolas", "nicolas123@gmail.com", 099652456, "xxx");
            Persona p3 = new Persona("18456587", "Camila", "cam123@gmail.com", 096321567, "xxx");
            Persona p4 = new Persona("77841857", "Ramiro", "ramiro123@gmail.com", 097589451, "xxx");
            Persona p5 = new Persona("89745624", "Pedro", "pedro123@gmail.com", 0932564125, "xxx");
            Persona p6 = new Persona("78412354", "Martina", "martina123@gmail.com", 095641245, "xxx");
            Persona p7 = new Persona("89135648", "Isabel", "isabel123@gmail.com", 098656232, "xxx");
            Persona p8 = new Persona("23156545", "Martin", "martin123@gmail.com", 0947812456, "xxx");
            Persona p9 = new Persona("89451634", "Lucas", "luqi123@gmail.com", 092456789, "xxx");
            Persona p10 = new Persona("54905645", "Diego", "die123@gmail.com", 0962345698, "xxx");
            Cuenta c1 = new Cuenta(p1, true, new DateTime(2026, 04, 01));
            Cuenta c2 = new Cuenta(p2, false, new DateTime(2026, 03, 01));
            Cuenta c3 = new Cuenta(p3, false, new DateTime(2026, 02, 01));
            Cuenta c4 = new Cuenta(p4, true, new DateTime(2026, 01, 01));
            Cuenta c5 = new Cuenta(p5, true, new DateTime(2026, 04, 02));
            Cuenta c6 = new Cuenta(p6, true, new DateTime(2026, 03, 11));
            Cuenta c7 = new Cuenta(p7, false, new DateTime(2026, 03, 21));
            Cuenta c8 = new Cuenta(p8, true, new DateTime(2026, 04, 05));
            Cuenta c9 = new Cuenta(p9, false, new DateTime(2026, 02, 11));
            Cuenta c10 = new Cuenta(p10, true, new DateTime(2026, 02, 21));
            Cuenta c11 = new Cuenta(p7, false, new DateTime(2026, 01, 20));
            Cuenta c12 = new Cuenta(p4, true, new DateTime(2026, 03, 31));
            Activo a1 = new Activo("Activo1", TipoActivo.PC, 4, c1, true);
            Activo a2 = new Activo("Activo2", TipoActivo.MOVIL, 4, c2, true);
            Activo a3 = new Activo("Activo3", TipoActivo.SERVER, 2, c3, false);
            Activo a4 = new Activo("Activo4", TipoActivo.PC, 4, c4, true);
            Activo a5 = new Activo("Activo5", TipoActivo.PC, 3, c5, false);
            Activo a6 = new Activo("Activo6", TipoActivo.MOVIL, 4, c6, true);
            Activo a7 = new Activo("Activo7", TipoActivo.MOVIL, 5, c7, false);
            Activo a8 = new Activo("Activo8", TipoActivo.SERVER, 4, c8, false);
            Activo a9 = new Activo("Activo9", TipoActivo.PC, 1, c9, true);
            Activo a10 = new Activo("Activo10", TipoActivo.SERVER, 3, c10, false);
            Activo a11 = new Activo("Activo11", TipoActivo.MOVIL, 4, c11, true);
            Activo a12 = new Activo("Activo12", TipoActivo.SERVER, 5, c12, false);
            Activo a13 = new Activo("Activo13", TipoActivo.SERVER, 4, c9, true);
            Activo a14 = new Activo("Activo14", TipoActivo.PC, 1, c7, false);
            Activo a15 = new Activo("Activo15", TipoActivo.PC, 4, c2, true);
            Incidente i1 = new Phishing(Canal.EMAIL, true, true, new DateTime(2026, 01, 01), a1, "xxx", Estado.ABIERTO, 3, 4);
            Incidente i2 = new Phishing(Canal.WHATSAPP, false, false, new DateTime(2026, 01, 01), a2, "xxx", Estado.ABIERTO, 3, 4);
            Incidente i3 = new Phishing(Canal.REDES_SOCIALES, true, false, new DateTime(2026, 01, 01), a3, "xxx", Estado.CERRADO, 3, 4);
            Incidente i4 = new Phishing(Canal.WHATSAPP, false, true, new DateTime(2026, 01, 01), a4, "xxx", Estado.EN_ANALISIS, 3, 4);
            Incidente i5 = new Phishing(Canal.LLAMADA, true, true, new DateTime(2026, 01, 01), a5, "xxx", Estado.ABIERTO, 3, 4);
            Incidente i6 = new Phishing(Canal.REDES_SOCIALES, false, true, new DateTime(2026, 01, 01), a6, "xxx", Estado.ABIERTO, 3, 4);
            Incidente i7 = new Phishing(Canal.WHATSAPP, true, false, new DateTime(2026, 01, 01), a7, "xxx", Estado.ABIERTO, 3, 4);
            Incidente i8 = new Phishing(Canal.EMAIL, true, true, new DateTime(2026, 01, 01), a8, "xxx", Estado.EN_ANALISIS, 3, 4);
            Incidente i9 = new Phishing(Canal.EMAIL, false, false, new DateTime(2026, 01, 01), a9, "xxx", Estado.ABIERTO, 3, 4);
            Incidente i10 = new Phishing(Canal.WHATSAPP, true, true, new DateTime(2026, 01, 01), a10, "xxx", Estado.CERRADO, 3, 4);
            Incidente i11 = new Phishing(Canal.LLAMADA, false, true, new DateTime(2026, 01, 01), a11, "xxx", Estado.CONTENIDO, 3, 4);
            Incidente i12 = new Phishing(Canal.REDES_SOCIALES, true, false, new DateTime(2026, 01, 01), a12, "xxx", Estado.CONTENIDO, 3, 4);
            Incidente i13 = new Phishing(Canal.EMAIL, true, false, new DateTime(2026, 01, 01), a13, "xxx", Estado.ABIERTO, 3, 4);
            Incidente i14 = new Phishing(Canal.EMAIL, true, true, new DateTime(2026, 01, 01), a14, "xxx", Estado.ABIERTO, 3, 4);
            Incidente i15 = new Phishing(Canal.WHATSAPP, true, true, new DateTime(2026, 01, 01), a15, "xxx", Estado.CERRADO, 3, 4);
            Incidente i16 = new Ramsomware(true, true, new DateTime(2026, 01, 01), a1, "xxx", Estado.ABIERTO, 1, 2);
            Incidente i17 = new Ramsomware(false, true, new DateTime(2026, 01, 01), a3, "xxx", Estado.ABIERTO, 1, 2);
            Incidente i18 = new Ramsomware(true, true, new DateTime(2026, 01, 01), a5, "xxx", Estado.CERRADO, 1, 2);
            Incidente i19 = new Ramsomware(true, true, new DateTime(2026, 01, 01), a6, "xxx", Estado.CONTENIDO, 1, 2);
            Incidente i20 = new Ramsomware(true, false, new DateTime(2026, 01, 01), a2, "xxx", Estado.EN_ANALISIS, 5, 2);
            Incidente i21 = new Ramsomware(true, true, new DateTime(2026, 01, 01), a7, "xxx", Estado.ABIERTO, 1, 2);
            Incidente i22 = new Ramsomware(true, false, new DateTime(2026, 01, 01), a8, "xxx", Estado.ABIERTO, 1, 2);
            Incidente i23 = new Ramsomware(false, false, new DateTime(2026, 01, 01), a1, "xxx", Estado.CERRADO, 3, 2);
            Incidente i24 = new Ramsomware(true, false, new DateTime(2026, 01, 01), a9, "xxx", Estado.ABIERTO, 5, 1);
            Incidente i25 = new Ramsomware(true, true, new DateTime(2026, 01, 01), a10, "xxx", Estado.EN_ANALISIS, 1, 2);
            Incidente i26 = new Ramsomware(true, false, new DateTime(2026, 01, 01), a11, "xxx", Estado.ABIERTO, 1, 2);
            Incidente i27 = new Ramsomware(false, false, new DateTime(2026, 01, 01), a12, "xxx", Estado.ABIERTO, 1, 2);
            Incidente i28 = new Ramsomware(true, true, new DateTime(2026, 01, 01), a13, "xxx", Estado.ABIERTO, 1, 2);
            Incidente i29 = new Ramsomware(false, true, new DateTime(2026, 01, 01), a15, "xxx", Estado.CONTENIDO, 1, 2);
            Incidente i30 = new Ramsomware(true, true, new DateTime(2026, 01, 01), a14, "xxx", Estado.ABIERTO, 1, 2);

            AltaPersona(p1);
            AltaPersona(p2);
            AltaPersona(p3);
            AltaPersona(p4);
            AltaPersona(p5);
            AltaPersona(p6);
            AltaPersona(p7);
            AltaPersona(p8);
            AltaPersona(p9);
            AltaPersona(p10);
            AltaCuenta(c1);
            AltaCuenta(c2);
            AltaCuenta(c3);
            AltaCuenta(c4);
            AltaCuenta(c5);
            AltaCuenta(c6);
            AltaCuenta(c7);
            AltaCuenta(c8);
            AltaCuenta(c9);
            AltaCuenta(c10);
            AltaCuenta(c11);
            AltaCuenta(c12);
            AltaActivo(a1);
            AltaActivo(a2);
            AltaActivo(a3);
            AltaActivo(a4);
            AltaActivo(a5);
            AltaActivo(a6);
            AltaActivo(a7);
            AltaActivo(a8);
            AltaActivo(a9);
            AltaActivo(a10);
            AltaActivo(a11);
            AltaActivo(a12);
            AltaActivo(a13);
            AltaActivo(a14);
            AltaActivo(a15);
            AltaIncidentes(i1);
            AltaIncidentes(i2);
            AltaIncidentes(i3);
            AltaIncidentes(i4);
            AltaIncidentes(i5);
            AltaIncidentes(i6);
            AltaIncidentes(i7);
            AltaIncidentes(i8);
            AltaIncidentes(i9);
            AltaIncidentes(i10);
            AltaIncidentes(i11);
            AltaIncidentes(i12);
            AltaIncidentes(i13);
            AltaIncidentes(i14);
            AltaIncidentes(i15);
            AltaIncidentes(i16);
            AltaIncidentes(i17);
            AltaIncidentes(i18);
            AltaIncidentes(i19);
            AltaIncidentes(i20);
            AltaIncidentes(i21);
            AltaIncidentes(i22);
            AltaIncidentes(i23);
            AltaIncidentes(i24);
            AltaIncidentes(i25);
            AltaIncidentes(i26);
            AltaIncidentes(i27);
            AltaIncidentes(i28);
            AltaIncidentes(i29);
            AltaIncidentes(i30);

        }
    }
}
