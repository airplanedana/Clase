using System;
using System.Collections.Generic;

class Tabla
{
    private int bombas;
    private char[,] grid;
    private bool ayudante;

    // Constructor
    public Tabla(int bombas)
    {
        this.bombas = bombas;
        this.ayudante = false;

        // Crear e inicializar tabla 5x5
        this.grid = new char[5, 5];
        for (int i = 0; i < 5; i++)
            for (int j = 0; j < 5; j++)
                this.grid[i, j] = Constantes.EMPTY;

        // Crear victoria
        Random rand = new Random();
        int x = rand.Next(this.grid.GetLength(0));
        int y = rand.Next(this.grid.GetLength(1));
        this.grid[x, y] = Constantes.GOAL;

        // Colocar bombas
        this.PonerBombas();

    }

    // Getters y Setters
    public int GetBombas()
    {
        return this.bombas;
    }
    public void SetBombas(int bombas)
    {
        this.bombas = bombas;
    }
    public char[,] GetGrid()
    {
        return this.grid;
    }
    public void SetGrid(char[,] grid)
    {
        this.grid = grid;
    }
    public bool GetAyudante()
    {
        return this.ayudante;
    }
    public void SetAyudante(bool ayudante)
    {
        this.ayudante = ayudante;
    }

    private void PonerBombas()
    {
        for (int i = 0; i < bombas; i++)
        {
            Random rand = new Random();
            int posX = rand.Next(this.grid.GetLength(0));
            int posY = rand.Next(this.grid.GetLength(1));

            if (this.grid[posX, posY] != Constantes.PLAYER)
                this.grid[posX, posY] = Constantes.BOMBA;
        }
    }

    public void VerTabla(int vidas)
    {
        for (int i = 0; i < this.grid.GetLength(0); i++)
        {
            for (int j = 0; j < this.grid.GetLength(1); j++)
            {
                Console.Write(this.grid[i, j] + "\t");
            }
            Console.WriteLine();
        }
        Console.WriteLine("Vidas: " + vidas);
    }

    public void ModifTabla(int[] pos, char valor)
    {
        this.grid[pos[0], pos[1]] = valor;
    }
    public char getGridValue(int[] pos)
    {
        return this.grid[pos[0], pos[1]];
    }
}
