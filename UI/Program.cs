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
                Console.WriteLine("1-Alta persona");
                Console.WriteLine("2 - Listar personas");

                op = int.Parse(Console.ReadLine());

                if (op.Equals(1))
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
                else if (op.Equals(2))
                {

                    foreach (Persona p in s.GetPersonas())
                    {
                        Console.WriteLine(p.Nombre);
                    }
                }
                Console.ReadKey();
            }
        }
    }
}
