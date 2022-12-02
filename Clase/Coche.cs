using System;
using System.Collections.Generic;

class Coche
{
    private string matricula;
    private int velocidad;
    private string marca;
    private string color;
    private bool parado;
    private int orientacion; // 0: arriba, 1: derecha, 2: izquierda

    public Coche(string matricula, int velocidad, string marca, string color)
    {
        this.matricula = matricula;
        this.velocidad = velocidad;
        this.marca = marca;
        this.color = color;
        this.parado = true;
        this.orientacion = 0;
    }

    public string GetMatricula()
    {
        return this.matricula;
    }
    public void SetMatricula(string matricula)
    {
        this.matricula = matricula;
    }
    public int GetVelocidad()
    {
        return this.velocidad;
    }
    public void SetVelocidad(int velocidad)
    {
        this.velocidad = velocidad;
    }
    public string GetMarca()
    {
        return this.marca;
    }
    public void SetMarca(string marca)
    {
        this.marca = marca;
    }
    public string GetColor()
    {
        return this.color;
    }
    public void SetColor(string color)
    {
        this.color = color;
    }
    public bool GetParado()
    {
        return this.parado;
    }
    public void SetParado(bool parado)
    {
        this.parado = parado;
    }
    public int GetOrientacion()
    {
        return this.orientacion;
    }
    public void SetOrientacion(int orientacion)
    {
        this.orientacion = orientacion;
    }

    public void Acelerar(int velocidad)
    {
        this.parado = false;
        this.velocidad += velocidad;
    }

    public void Frenar(int velocidad)
    {
        this.velocidad -= velocidad;

        if (this.velocidad <= 0)
        {
            this.velocidad = 0;
            this.parado = true;
        }
    }

    public void GirarArriba()
    {
        this.orientacion = 0;
        Console.WriteLine("Orientacion arriba");
    }
    public void GirarDerecha()
    {
        this.orientacion = 1;
        Console.WriteLine("Orientacion derecha");
    }
    public void GirarIzquierda()
    {
        this.orientacion = 2;
        Console.WriteLine("Orientacion izquierda");
    }

    public override string ToString()
    {
        return "Este coche con matricula: " + this.matricula + " es un: " + this.marca + ", con velocidad: " + this.velocidad + ", de color: " + this.color;
    }
}
