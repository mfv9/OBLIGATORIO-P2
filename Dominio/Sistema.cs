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

        #region
        private Sistema()
        {
            PrecargarDatos();
        }

        private static Sistema instancia = null;
        public static Sistema getInstance()
        {
            if (instancia == null)
            {
                instancia = new Sistema();
            }
            return instancia;
        }

        #endregion

        public void AltaCuenta(Cuenta cuenta)
        {
            cuenta.Validar();

            _cuentas.Add(cuenta);


        }

        public void AltaPersona(Persona persona)
        {
            persona.Validar();
            if (!_personas.Contains(persona))
            {
                _personas.Add(persona);

            }
            else
            {
                throw new Exception("Ya existe la cedula o el mail");
            }



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


        public List<Incidente> GetIncidentesPorPersona(string cedula)
        {
            List<Incidente> ret = new List<Incidente>();
            foreach (Incidente i in _incidentes)
            {
                if (i.ActivoAfectado.CuentaResponsable.Titular.Cedula.Equals(cedula))
                {
                    ret.Add(i);
                }

            }
            return ret;
        }



        public List<Activo> ActivoCarecienteDeBackup()
        {
            List<Activo> ret = new List<Activo>();
            foreach (Activo a in _activos)
            {
                if (!a.TieneBackup)
                {
                    ret.Add(a);
                }
            }
            return ret;
        }

        public List<Activo> GetActivos()
        {

            return _activos;
        }

        public List<Incidente> GetIncidentes()
        {
            return _incidentes;
        }

        //METODOS WEBAPP

        public Persona VerificarExistencia(string mail, string pass)
        {
            foreach (Persona p in _personas)
            {
                if (p.Email == mail && p.Password == pass)
                {
                    return p;
                }
            }
            return null;
        }

        public Persona FindPersonaById(int id)
        {
            foreach (Persona persona in _personas)
            {
                if (persona.Id == id)
                {
                    return persona;
                }
            }
            return null;
        }

        public List<Activo> FindActivosById(int personaId)
        {
            List<Activo> resultado = new List<Activo>();
            foreach (Activo a in _activos)
            {
                if (a.CuentaResponsable != null &&
                    a.CuentaResponsable.Titular != null &&
                    a.CuentaResponsable.Titular.Id == personaId)
                {
                    resultado.Add(a);
                }
            }
            _activos.Sort();
            return resultado;
        }
     

        public List<Activo> GetActivosById(int id)
        {
            List<Activo> ret = new List<Activo>();
            foreach (Activo a in _activos)
            {
                if (a.CuentaResponsable != null && a.CuentaResponsable.Titular.Id == id  )
                {
                    ret.Add(a);
                }

            }

            return ret;
        }


        public Activo FindActivoById(int id)
        {

            foreach (Activo a in _activos)
            {
                if (a.CuentaResponsable.Id == id)
                {
                    return a;
                }
            }

            return null;
        }

        public Activo FindActivoByCodigo(string Codigo)
        {

            foreach (Activo a in _activos)
            {
                if (a.CodigoAlfanumerico == Codigo)
                {
                    return a;
                }
            }

            return null;
        }
        public List<Cuenta> GetCuentasPorId(int id)
        {
            List<Cuenta> ret = new List<Cuenta>();
            foreach (Cuenta c in _cuentas)
            {
                if (c.Titular.Id == id)
                {
                    ret.Add(c);
                }

            }
            return ret;
        }

        public void ActualizarActivo(Activo a)
        {
            Activo buscado = FindActivoByCodigo(a.CodigoAlfanumerico);

            if (buscado != null)
            {
                buscado.CuentaResponsable = null;
            }


        }



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
            Persona p11 = new Persona("54238253", "Alex", "Alexanderdaniel10silva@gmail.com", 095119802, "xxx");
            Persona p12 = new Persona("54238251", "Mateo", "mateofv99@gmail.com", 098337697, "xxx");
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
            Cuenta c11 = new Cuenta(p12, false, new DateTime(2026, 01, 20));
            Cuenta c12 = new Cuenta(p11, true, new DateTime(2026, 03, 31));
            Activo a1 = new Activo("PC-MVD-2026-001 | Lenovo Legion LOQ (IBM)", TipoActivo.PC, 4, c1, true);
            Activo a2 = new Activo("MOV-MVD-2026-001 | iPhone 12", TipoActivo.MOVIL, 4, c2, true);
            Activo a3 = new Activo("SRV-USA-2026-001 | Servidor Físico Datacenter USA", TipoActivo.SERVER, 2, c3, false);
            Activo a4 = new Activo("PC-MVD-2026-002 | Gigabyte G6", TipoActivo.PC, 4, c4, true);
            Activo a5 = new Activo("PC-MVD-2026-003 | Asus Infinite", TipoActivo.PC, 3, c5, false);
            Activo a6 = new Activo("MOV-MVD-2026-002 | Samsung Galaxy S21", TipoActivo.MOVIL, 4, c6, true);
            Activo a7 = new Activo("MOV-MVD-2026-003 | Xiaomi Redmi Note 10", TipoActivo.MOVIL, 5, c7, false);
            Activo a8 = new Activo("SRV-CLD-2026-001 | Instancia AWS EC2 Producción", TipoActivo.SERVER, 4, c8, false);
            Activo a9 = new Activo("PC-MVD-2026-004 | HP Pavilion", TipoActivo.PC, 1, c9, true);
            Activo a10 = new Activo("SRV-CLD-2026-002 | Servicio Microsoft Azure", TipoActivo.SERVER, 3, c10, false);
            Activo a11 = new Activo("MOV-MVD-2026-004 | Motorola Edge 20", TipoActivo.MOVIL, 4, c11, true);
            Activo a12 = new Activo("SRV-CLD-2026-003 | Servicio Google Cloud Platform", TipoActivo.SERVER, 5, c12, false);
            Activo a13 = new Activo("SRV-MVD-2026-002 | Servidor Backup Local", TipoActivo.SERVER, 4, c9, true);
            Activo a14 = new Activo("PC-MVD-2026-005 | Dell Inspiron", TipoActivo.PC, 1, c7, false);
            Activo a15 = new Activo("PC-MVD-2026-006 | Lenovo ThinkCentre", TipoActivo.PC, 4, c2, true);
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

            //PRECARGA CONSTRUCTORES VACIOS WEBAPP
            Persona admin1 = new Persona();
            admin1.Nombre = "Admin";
            admin1.Id = 20;
            admin1.Cedula = "123456789410";
            admin1.Email = "admin@gmail";
            admin1.Telefono = 123456789;
            admin1.Password = "admin1234";
            admin1.Rol = "Administrador";

            Persona op1 = new Persona();
            op1.Nombre = "Pepe";
            op1.Id = 21;

            op1.Email = "pepe@gmail.com";
            op1.Password = "persona1234";
            op1.Cedula = "123456789";
            op1.Telefono = 12345678;
            op1.Rol = "Operador";

            Cuenta c13 = new Cuenta();
            {
                c13.Titular = op1;
                c13.TieneMfa = true;
            }
            Cuenta c14 = new Cuenta();
            {
                c14.Titular = op1;
                c14.TieneMfa = false;

            }

            Activo a30 = new Activo();
            a30.CodigoAlfanumerico = "PC-MVD-2026-001";
            a30.Nombre = "Lenovo Legion LOQ (IBM)";
            a30.UnActivo = TipoActivo.PC;
            a30.Criticidad = 5;
            a30.CuentaResponsable = c13;
            a30.TieneBackup = true;

            Activo a31 = new Activo();
            a31.CodigoAlfanumerico = "TABLET-CANELONES-2026-001";
            a31.Nombre = "Samsung Galaxy Tab S9";
            a31.UnActivo = TipoActivo.MOVIL;
            a31.Criticidad = 3;
            a31.CuentaResponsable = c14;
            a31.TieneBackup = false;

            AltaActivo(a30);
            AltaActivo(a31);




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
            AltaPersona(p11);
            AltaPersona(p12);
            AltaPersona(admin1);
            AltaPersona(op1);


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
            AltaCuenta(c13);
            AltaCuenta(c14);

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
