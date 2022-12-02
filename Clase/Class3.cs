using System;
using System.Collections.Generic;

class Class3
{
    public void Start(String[] args)
    {
        // Elegir dificultad y poner num de bombas y vidas
        int dif = 0;
        while (dif != 1 && dif != 2 && dif != 3 && dif != 4)
        {
            Console.WriteLine();
            Console.WriteLine("1: facil\n2: intermedio\n3: dificil");
            Console.WriteLine("Elige dificultad: ");

            dif = Convert.ToInt32(Console.ReadLine());
        }

        int vidas = 0, bombas = 0;

        switch (dif)
        {
            case 1:
                Console.WriteLine("Has elegido dificultad facil");
                vidas = 3;
                bombas = 4;
                break;

            case 2:
                Console.WriteLine("Has elegido dificultad intermedia");
                vidas = 2;
                bombas = 6;
                break;

            case 3:
                Console.WriteLine("Has elegido dificultad dificil");
                vidas = 1;
                bombas = 8;
                break;

            default:
                break;
        }

        Console.WriteLine();
        Iniciar(bombas, vidas);
    }

    private void Iniciar(int bombas, int vidas)
    {
        // Crear e inicializar tabla 5x5
        char[,] tabla = new char[5, 5] { { 'o', 'o', 'o', 'o', 'o' }, { 'o', 'o', 'o', 'o', 'o' }, { 'o', 'o', 'o', 'o', 'o' }, { 'o', 'o', 'o', 'o', 'o' }, { 'o', 'o', 'o', 'o', 'o' } };
        int[] pos = new int[2];

        // Inicializar posicion jugador y victoria random
        Random rand = new Random();

        pos[0] = rand.Next(tabla.GetLength(0));
        pos[1] = rand.Next(tabla.GetLength(1));
        tabla[pos[0], pos[1]] = 'x';

        int x = pos[0];
        int y = pos[1];
        while (x == pos[0] && y == pos[1]) // Que la victoria no reemplaze al jugador
        {
            x = rand.Next(tabla.GetLength(0));
            y = rand.Next(tabla.GetLength(1));
            tabla[x, y] = '$';
        }

        // Colocar bombas
        PonerBombas(tabla, bombas);

        Console.WriteLine("Posición inicial: ");

        while (vidas >= 0)
        {
            VerTabla(tabla, vidas);

            // Mover jugador
            int resultado = PedirInput(tabla, pos, vidas);
            if (resultado == 0)
            {
                Console.WriteLine("Pierde vida");
                vidas--;
            }
            else if (resultado == 1)
            {
                Console.WriteLine("Ganas!");
                return;
            }
        }

        if (vidas < 0)
        {
            Console.WriteLine("Muerto");
            return;
        }
    }

    private int PedirInput(char[,] tabla, int[] pos, int vidas)
    {
        // Pedir input jugador
        // 1: arriba, 2: abajo, 3: izquierda, 4: derecha
        int dir = 0;
        while (dir != 1 && dir != 2 && dir != 3 && dir != 4)
        {
            Console.WriteLine();
            Console.WriteLine("1: arriba\n2: abajo\n3: izquierda\n4: derecha");
            Console.WriteLine("Introduce una dirección a mover: ");

            dir = Convert.ToInt32(Console.ReadLine());
        }

        // Comprovar si se puede mover a esta direccion
        bool[] sePuede = Check(tabla, pos);
        bool pierdeVida = false;
        bool gana = false;

        switch (dir)
        {
            case 1: // Arriba
                if (sePuede[0])
                {
                    tabla[pos[0], pos[1]] = 'o';
                    pos[0] -= 1;

                    if (tabla[pos[0], pos[1]] == '%') // Si es bomba, perder vida
                        pierdeVida = true;
                    if (tabla[pos[0], pos[1]] == '$') // Si gana
                        gana = true;

                    tabla[pos[0], pos[1]] = 'x';
                }
                else
                    Console.WriteLine("No se puede\n");
                break;

            case 2: // Abajo
                if (sePuede[1])
                {
                    tabla[pos[0], pos[1]] = 'o';
                    pos[0] += 1;

                    if (tabla[pos[0], pos[1]] == '%') // Si es bomba, perder vida
                        pierdeVida = true;
                    if (tabla[pos[0], pos[1]] == '$') // Si gana
                        gana = true;

                    tabla[pos[0], pos[1]] = 'x';
                }
                else
                    Console.WriteLine("No se puede\n");
                break;

            case 3: // Izquierda
                if (sePuede[2])
                {
                    tabla[pos[0], pos[1]] = 'o';
                    pos[1] -= 1;

                    if (tabla[pos[0], pos[1]] == '%') // Si es bomba, perder vida
                        pierdeVida = true;
                    if (tabla[pos[0], pos[1]] == '$') // Si gana
                        gana = true;

                    tabla[pos[0], pos[1]] = 'x';
                }
                else
                    Console.WriteLine("No se puede\n");
                break;

            case 4: // Derecha
                if (sePuede[3])
                {
                    tabla[pos[0], pos[1]] = 'o';
                    pos[1] += 1;

                    if (tabla[pos[0], pos[1]] == '%') // Si es bomba, perder vida
                        pierdeVida = true;
                    if (tabla[pos[0], pos[1]] == '$') // Si gana
                        gana = true;

                    tabla[pos[0], pos[1]] = 'x';
                }
                else
                    Console.WriteLine("No se puede\n");
                break;

            default:
                break;
        }

        if (pierdeVida)
            return 0;

        if (gana)
            return 1;

        return 2;
    }

    private void PonerBombas(char[,] tabla, int bombas)
    {
        for (int i = 0; i < bombas; i++)
        {
            Random rand = new Random();
            int posX = rand.Next(tabla.GetLength(0));
            int posY = rand.Next(tabla.GetLength(1));

            if (tabla[posX, posY] != 'x')
                tabla[posX, posY] = '%';
        }
    }

    private void VerTabla(char[,] tabla, int vidas)
    {
        for (int i = 0; i < tabla.GetLength(0); i++)
        {
            for (int j = 0; j < tabla.GetLength(1); j++)
            {
                Console.Write(tabla[i, j] + "\t");
            }
            Console.WriteLine();
        }
        Console.WriteLine("Vidas: " + vidas);
    }

    private bool[] Check(char[,] tabla, int[] pos)
    {
        bool[] puedeMover = {false, false, false, false}; // arriba, abajo, izquierda, derecha
        int x = pos[0], y = pos[1];

        if (tabla[x, y] == 'x')
        {
            try
            {
                if (tabla[x - 1, y] == 'o' || tabla[x - 1, y] == '%' || tabla[x - 1, y] == '$')
                    puedeMover[0] = true;
            }
            catch { }
            try
            {
                if (tabla[x + 1, y] == 'o' || tabla[x + 1, y] == '%' || tabla[x + 1, y] == '$')
                    puedeMover[1] = true;
            }
            catch { }
            try
            {
                if (tabla[x, y - 1] == 'o' || tabla[x, y - 1] == '%' || tabla[x, y - 1] == '$')
                    puedeMover[2] = true;
            }
            catch { }
            try
            {
                if (tabla[x, y + 1] == 'o' || tabla[x, y + 1] == '%' || tabla[x, y + 1] == '$')
                    puedeMover[3] = true;
            }
            catch { }
        }

        return puedeMover;
    }
}
