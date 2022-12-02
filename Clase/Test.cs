using System;
using System.Collections.Generic;
using System.Linq;

class Test
{
    static Dictionary<string, Coche> cochesDic = new Dictionary<string, Coche>();

    public static void Main()
    {
        // Creamos diccionario coches y creamos varios coches
        Coche coche1 = new Coche("63G72", 75, "Seat", "Azul");
        Coche coche2 = new Coche("H4387R", 200, "Volvo", "Gris");
        Coche coche3 = new Coche("8345N4", 150, "Volkswagen", "Amarillo");
        Coche coche4 = new Coche("8374JSD", 50, "Hyundai", "Rojo");
        Coche coche5 = new Coche("983HSD", 90, "Renault", "Blanco");


        // Llenamos el diccionario de coches con Matricula - Coche
        cochesDic.Add(coche1.GetMatricula(), coche1);
        cochesDic.Add(coche2.GetMatricula(), coche2);
        cochesDic.Add(coche3.GetMatricula(), coche3);
        cochesDic.Add(coche4.GetMatricula(), coche4);
        cochesDic.Add(coche5.GetMatricula(), coche5);

        // Mostramos los contenidos del diccionario
        foreach (var item in cochesDic)
        {
            Coche coche = item.Value;

            if (coche.GetColor() == "Rojo")
            {
                coche.GirarDerecha();
                Console.WriteLine(coche.GetMatricula());
            }
        }

        // Menu de busqueda por campo
        char search = 'y';

        while (search == 'y')
        {
            int opt = 0;
            while (opt != 1 && opt != 2 && opt != 3 && opt != 4)
            {
                Console.WriteLine();
                Console.WriteLine("Elija criterio de búsqueda: ");
                Console.WriteLine("1: Matricula\n2: Velocidad\n3: Marca\n4: Color");

                opt = Convert.ToInt32(Console.ReadLine());
            }

            try // Hacemos try/catch para controlar errores
            {
                Buscar(opt);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                search = 'z';
                while (search != 'y' && search != 'n')
                {
                    Console.WriteLine("Hacer nueva busqueda? (y/n)");
                    search = Convert.ToChar(Console.ReadLine());
                }
            }
        }
    }

    public static void Buscar(int opt)
    {
        string input;

        switch (opt)
        {
            case 1:
                Console.WriteLine("Escriba una matrícula a buscar: ");
                input = Console.ReadLine();

                // Usar Linq para la busqueda
                var searchMatricula = cochesDic.Where(coche => coche.Key.Equals(input));
                if (searchMatricula.Count() <= 0)
                    throw new Exception("No hay resultados.");

                Console.WriteLine(searchMatricula.First().Value);
                break;

            case 2:
                Console.WriteLine("Escriba una velocidad a buscar: ");
                int vel = Convert.ToInt32(Console.ReadLine());

                // Usar Linq para la busqueda
                var searchVelocidad = cochesDic.Where(coche => coche.Value.GetVelocidad() == vel);
                if (searchVelocidad.Count() <= 0)
                    throw new Exception("No hay resultados.");

                Console.WriteLine(searchVelocidad.First().Value);
                break;

            case 3:
                Console.WriteLine("Escriba una marca a buscar: ");
                input = Console.ReadLine();

                // Usar Linq para la busqueda
                var searchMarca = cochesDic.Where(coche => coche.Value.GetMarca().Equals(input));
                if (searchMarca.Count() <= 0)
                    throw new Exception("No hay resultados.");

                Console.WriteLine(searchMarca.First().Value);
                break;

            case 4:
                Console.WriteLine("Escriba un color a buscar: ");
                input = Console.ReadLine();

                // Usar Linq para la busqueda
                var searchColor = cochesDic.Where(coche => coche.Value.GetColor().Equals(input));
                if (searchColor.Count() <= 0)
                    throw new Exception("No hay resultados.");

                Console.WriteLine(searchColor.First().Value);
                break;

            default:
                break;
        }
    }
}
