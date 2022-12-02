using System;
using System.Collections.Generic;

class Jugador
{
    private int vidas;
    private int[] pos;

    private bool pierdeVida;
    private bool gana;

    // Constructor
    public Jugador(int vidas, char[,] grid)
    {
        this.vidas = vidas;
        this.pos = new int[2];

        this.pierdeVida = false;
        this.gana = false;

        // Inicializar posicion jugador
        Random rand = new Random();
        pos[0] = rand.Next(grid.GetLength(0));
        pos[1] = rand.Next(grid.GetLength(1));
        grid[pos[0], pos[1]] = Constantes.PLAYER;
    }

    // Getters y Setters
    public int GetVidas()
    {
        return this.vidas;
    }
    public void SetVidas(int vidas)
    {
        this.vidas = vidas;
    }
    public int[] GetPos()
    {
        return this.pos;
    }
    public void SetPos(int[] pos)
    {
        this.pos = pos;
    }
    public bool GetPierdeVida()
    {
        return this.pierdeVida;
    }
    public void SetPierdeVida(bool pierdeVida)
    {
        this.pierdeVida = pierdeVida;
    }
    public bool GetGana()
    {
        return this.gana;
    }
    public void SetGana(bool gana)
    {
        this.gana = gana;
    }

    public void PedirInput(Tabla tabla)
    {
        // Pedir input jugador, mover con WASD
        // w: arriba, s: abajo, a: izquierda, d: derecha
        char dir = 'z';
        while (dir != 'w' && dir != 's' && dir != 'a' && dir != 'd')
        {
            Console.WriteLine();
            Console.WriteLine("W: arriba\nS: abajo\nA: izquierda\nD: derecha");
            Console.WriteLine("Introduce una dirección a mover: ");

            dir = Convert.ToChar(Console.ReadLine());
        }

        // Comprovar si se puede mover a esta direccion
        bool[] sePuede = this.Check(tabla);
        this.pierdeVida = false;
        this.gana = false;

        switch (dir)
        {
            case 'w': // Arriba
                if (sePuede[0])
                {
                    tabla.ModifTabla(pos, Constantes.EMPTY);
                    pos[0] -= 1;

                    this.Mover(tabla);
                }
                else
                {
                    if (tabla.GetAyudante())
                        Console.WriteLine(Constantes.CANT_FALL + "\n");
                    else // Si no hay ayudante, cae fuera de la tabla y muere 
                    {
                        Console.WriteLine(Constantes.FALL);
                        this.vidas = -1;
                    }
                }
                break;

            case 's': // Abajo
                if (sePuede[1])
                {
                    tabla.ModifTabla(pos, Constantes.EMPTY);
                    pos[0] += 1;

                    this.Mover(tabla);
                }
                else
                {
                    if (tabla.GetAyudante())
                        Console.WriteLine(Constantes.CANT_FALL + "\n");
                    else // Si no hay ayudante, cae fuera de la tabla y muere 
                    {
                        Console.WriteLine(Constantes.FALL);
                        this.vidas = -1;
                    }
                }
                break;

            case 'a': // Izquierda
                if (sePuede[2])
                {
                    tabla.ModifTabla(pos, Constantes.EMPTY);
                    pos[1] -= 1;

                    this.Mover(tabla);
                }
                else
                {
                    if (tabla.GetAyudante())
                        Console.WriteLine(Constantes.CANT_FALL + "\n");
                    else // Si no hay ayudante, cae fuera de la tabla y muere 
                    {
                        Console.WriteLine(Constantes.FALL);
                        this.vidas = -1;
                    }
                }
                break;

            case 'd': // Derecha
                if (sePuede[3])
                {
                    tabla.ModifTabla(pos, Constantes.EMPTY);
                    pos[1] += 1;

                    this.Mover(tabla);
                }
                else
                {
                    if (tabla.GetAyudante())
                        Console.WriteLine(Constantes.CANT_FALL + "\n");
                    else // Si no hay ayudante, cae fuera de la tabla y muere 
                    {
                        Console.WriteLine(Constantes.FALL);
                        this.vidas = -1;
                    }
                }
                break;

            default:
                break;
        }
    }

    private void Mover(Tabla tabla)
    {
        if (tabla.getGridValue(pos) == Constantes.BOMBA) // Si es bomba, perder vida
            this.pierdeVida = true;
        if (tabla.getGridValue(pos) == Constantes.GOAL) // Si gana
            this.gana = true;

        tabla.ModifTabla(pos, Constantes.PLAYER);
    }

    private bool[] Check(Tabla tabla)
    {
        bool[] puedeMover = { false, false, false, false }; // arriba, abajo, izquierda, derecha
        int x = this.pos[0], y = this.pos[1];

        if (tabla.GetGrid()[x, y] == Constantes.PLAYER)
        {
            try
            {
                if (tabla.GetGrid()[x - 1, y] == Constantes.EMPTY || tabla.GetGrid()[x - 1, y] == Constantes.BOMBA || tabla.GetGrid()[x - 1, y] == Constantes.GOAL)
                    puedeMover[0] = true;
            }
            catch { }
            try
            {
                if (tabla.GetGrid()[x + 1, y] == Constantes.EMPTY || tabla.GetGrid()[x + 1, y] == Constantes.BOMBA || tabla.GetGrid()[x + 1, y] == Constantes.GOAL)
                    puedeMover[1] = true;
            }
            catch { }
            try
            {
                if (tabla.GetGrid()[x, y - 1] == Constantes.EMPTY || tabla.GetGrid()[x, y - 1] == Constantes.BOMBA || tabla.GetGrid()[x, y - 1] == Constantes.GOAL)
                    puedeMover[2] = true;
            }
            catch { }
            try
            {
                if (tabla.GetGrid()[x, y + 1] == Constantes.EMPTY || tabla.GetGrid()[x, y + 1] == Constantes.BOMBA || tabla.GetGrid()[x, y + 1] == Constantes.GOAL)
                    puedeMover[3] = true;
            }
            catch { }
        }

        return puedeMover;
    }
}
