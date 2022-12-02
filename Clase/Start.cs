using System;
using System.Collections.Generic;

class Start
{
    public static void Main3(String[] args)
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
                Console.WriteLine(Constantes.DIF_FACIL);
                vidas = 3;
                bombas = 4;
                break;

            case 2:
                Console.WriteLine(Constantes.DIF_INTERMEDIO);
                vidas = 2;
                bombas = 6;
                break;

            case 3:
                Console.WriteLine(Constantes.DIF_DIFICIL);
                vidas = 1;
                bombas = 8;
                break;

            default:
                break;
        }

        Tabla tabla = new Tabla(bombas);
        Jugador jugador = new Jugador(vidas, tabla.GetGrid());

        // Preguntar ayudante
        int opt = 0;
        while (opt != 1 && opt != 2)
        {
            Console.WriteLine();
            Console.WriteLine("Quieres ayudante?");
            Console.WriteLine("1: Si\n2: No");

            opt = Convert.ToInt32(Console.ReadLine());
        }
        if (opt == 1)
        {
            Console.WriteLine(Constantes.HELP_ON);
            tabla.SetAyudante(true);
        }
        else
            Console.WriteLine(Constantes.HELP_OFF);

        Console.WriteLine();
        Iniciar(tabla, jugador);
    }

    private static void Iniciar(Tabla tabla, Jugador jugador)
    {
        Console.WriteLine("Posición inicial: ");

        while (jugador.GetVidas() >= 0)
        {
            tabla.VerTabla(jugador.GetVidas());

            // Mover jugador
            jugador.PedirInput(tabla);

            if (jugador.GetPierdeVida())
            {
                Console.WriteLine(Constantes.LOSE_LIFE);
                jugador.SetVidas(jugador.GetVidas() - 1);
            }
            else if (jugador.GetGana())
            {
                Console.WriteLine(Constantes.WIN);
                return;
            }
        }

        if (jugador.GetVidas() < 0)
        {
            Console.WriteLine(Constantes.DEATH);
            return;
        }
    }
}
