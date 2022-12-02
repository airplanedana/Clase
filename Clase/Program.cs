using System;

class Clase
{

    public const String CONSTANT = "Hello";

    public static void Main1()
    {
        int a = 4;

        Console.WriteLine("Hello, World!");

        while (a > 0)
        {
            Console.WriteLine("{0}", a);
            a = a - 1;
        }

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("{0}", i);
        }


        for (int num = Convert.ToInt32(Console.ReadLine()); num >= 0; num--)
        {
            Console.WriteLine(num);
        }

        // Lectura array 10 numeros
        int[] array = new int[10];
        Console.WriteLine("Escribe 10 nums: ");
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = Convert.ToInt32(Console.ReadLine());
        }

        Console.WriteLine("Resultado: ");
        foreach (int num in array)
        {
            Console.WriteLine(num);
        }

        // Ordenar array y comprovar nums duplicados
        int temp = 0;
        for (int i = 0; i < array.Length; i++) // Comprovar el primer valor
        {
            for (int j = i + 1; j < array.Length; j++) // Comprovar los siguientes valores
            {
                if (array[i] > array[j]) // Si es mayor que el siguiente, almacenar en temp, asignamos el valor menor y asignamos temp al siguiente
                {
                    temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }
        }
        Console.WriteLine("Array ordenado: ");
        foreach (int num in array)
        {
            Console.WriteLine(num);
        }

        if (array.Length != array.Distinct().Count())
            Console.WriteLine("Tiene repetidos");

        int[] q = array.Distinct().ToArray();
        Console.WriteLine("Array ordenado sin repetidos: ");
        foreach (int num in q)
        {
            Console.WriteLine(num);
        }
    }

    static void Muestra(int a)
    {
        Console.Write($"Salida: {a}");
    }
}