using System;
using System.Collections;

class Class2
{
    public static void Main1(String[] args)
    {
        int longitud = 10;

        if (args.Length != 0)
            longitud = int.Parse(args[0]);

        Inicio(longitud);
    }

    static void Inicio(int longitud)
    {
        // Declarar y llenar array
        int[] array = new int[longitud];
        Console.WriteLine("Escribe 10 nums: ");
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = Convert.ToInt32(Console.ReadLine());
        }

        // Switch 
        char opcion = 'x';
        while (opcion != 'a' && opcion != 'b')
        {
            Console.WriteLine("Elige opcion: \na) Ordenar \nb) Ver pares e impares");
            opcion = Convert.ToChar(Console.ReadLine());
        }

        Menu(opcion, array);
        
    }

    static void Menu(char opcion, int[] array)
    {
        switch (opcion)
        {
            case 'a':
                // Llamar a funcion ordenar
                Ordenamiento(array);

                // Llamar a funcion visualizar
                Console.WriteLine("Array ordenado:");
                Visualizar(array);

                break;

            case 'b':
                List<int> pares = new List<int>();
                List<int> impares = new List<int>();
                List<int> primos = new List<int>();

                foreach (int num in array)
                {
                    if (num % 2 == 0) // Separar numeros pares en nuevo array
                        pares.Add(num);
                    else // Separar numeros impares en nuevo array
                    {
                        impares.Add(num);

                        // Separar numeros primos en nuevo array
                        bool primo = false;
                        for (int i = 2; i < num; i++)
                        {
                            if ((num % i) != 0)
                                primo = true;
                        }
                        if (primo) primos.Add(num);
                    }
                }

                Console.WriteLine("Pares:");
                Visualizar(pares.ToArray());

                Console.WriteLine("Impares:");
                Visualizar(impares.ToArray());

                Console.WriteLine("Primos:");
                Visualizar(primos.ToArray());

                break;

            default:
                break;
        }
    }

    static void Ordenamiento(int[] array)
    {
        // Ordena array
        int temp = 0;
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[i] > array[j])
                {
                    temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }
        }
    }

    static void Visualizar(int[] array)
    {
        foreach (int num in array)
        {
            Console.WriteLine(num);
        }
    }
}
