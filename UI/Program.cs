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
                
                

                op = int.Parse(Console.ReadLine());

                if (op.Equals(3))
                {
                    try
                    {
                        Console.WriteLine("Nombre");
                        string nombre = Console.ReadLine();

                        Console.WriteLine("CI");
                        string cI = Console.ReadLine();

                        Console.WriteLine("Email");
                        string email = Console.ReadLine();

                        Console.WriteLine("tel");
                        int telefono = int.Parse(Console.ReadLine());

                        Console.WriteLine("contrasenia");
                        string contrasenia = Console.ReadLine();

                        Persona nuevo = new Persona(cI, nombre, email, telefono, contrasenia);


                        s.AltaPersona(nuevo);

                        Console.WriteLine("Alta correcta");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message); //TODO 
                    }

                }
                else if (op.Equals(1))
                {
                    foreach (Activo a in s.GetPersonasYActivos())
                    {
                        Console.WriteLine($"{a.CuentaResponsable.Titular}\n {a.Nombre} - {a.UnActivo}");
                    }

                  
                }
                Console.ReadKey();
            }
        }
    }
}
