using Dominio;

namespace UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sistema s = new Sistema();

            int op = -1;

            while (op != 0)
            {
                Console.Clear();
                Console.WriteLine("1 - Listar personas con activo");
                Console.WriteLine("2 - Listar incidentes por persona");
                Console.WriteLine("3 - Alta persona");
                Console.WriteLine("4 - Listar activos carecientes de backup");
                Console.WriteLine("0 - Salir");



                op = int.Parse(Console.ReadLine());


                if (op.Equals(1))
                {
                    foreach (Persona p in s.GetPersonas())
                    {
                        Console.WriteLine($"{p.Nombre} ({p.Cedula})");

                        foreach (Activo a in s.GetActivos())
                        {
                            if (a.CuentaResponsable.Titular.Equals(p))
                            {
                                Console.WriteLine($"{a.Nombre} - {a.UnActivo}\n");
                            }
                        }
                    }

                }
                else if (op.Equals(2))
                {
                    foreach (Cuenta c in s.GetCuentas())
                    {
                        Console.WriteLine($"ID: {c.Id} - CI : {c.Titular.Cedula} - {c.Titular.Email} \n");
                    }

                    Console.WriteLine($"Seleccione el ID de la cuenta a la que quiere inspeccionar");

                    int iDPersona = int.Parse(Console.ReadLine());
                    Console.Clear();

                    foreach (Incidente i in s.GetIncidentesPorPersona(iDPersona))
                    {
                        Console.WriteLine(i);
                    }
                }
                else if (op.Equals(3))
                {
                    try
                    {
                        Console.WriteLine("Ingrese el nombre");
                        string nombre = Console.ReadLine();

                        Console.WriteLine("Ingrese la cedula");
                        string cI = Console.ReadLine();

                        Console.WriteLine("Ingrese el email");
                        string email = Console.ReadLine();

                        Console.WriteLine("Ingrese un telefono");
                        int telefono = int.Parse(Console.ReadLine());

                        Console.WriteLine("Ingrese contraseña");
                        string contrasenia = Console.ReadLine();

                        Persona nuevo = new Persona(cI, nombre, email, telefono, contrasenia);


                        s.AltaPersona(nuevo);

                        Console.WriteLine("Alta correcta");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message); 
                    }

                }
                else if (op.Equals(4))
                {
                    foreach (Activo a in s.ActivoCarecienteDeBackup())
                    {
                        Console.WriteLine(a);
                    }
                }


                if (op != 0)
                {
                    Console.WriteLine("Presione una tecla para continuar");
                }
                if (op.Equals(0))
                {
                    Console.WriteLine("Presione una tecla para salir");
                }
                Console.ReadKey();
            }
        }
    }
}
