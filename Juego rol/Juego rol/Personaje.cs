using System;
using System.Collections.Generic;
using System.Text;

namespace Juego_rol
{
    public enum tipoDePersonaje
    {
        Elfo,
        Hada,
        Humano,
        Mago,
        Orco
    }

    public class Personaje
    {
        //Datos
        private tipoDePersonaje tipo;
        private string nombre, apodo;
        private DateTime fechaNac;
        private int edad;
        private float salud;

        //Caracteristicas
        private int velocidad, destreza, fuerza, nivel, armadura;
        
        public Personaje()
        {
            Salud = 100;
            nivel = 1;
        }


        public tipoDePersonaje Tipo { get => tipo; set => tipo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apodo { get => apodo; set => apodo = value; }
        public DateTime FechaNac { get => fechaNac; set => fechaNac = value; }
        public int Edad { get => edad; set => edad = value; }
        public float Salud{ get => salud; set => salud = value; }
        public int Velocidad { get => velocidad; set => velocidad = value; }
        public int Destreza { get => destreza; set => destreza = value; }
        public int Fuerza { get => fuerza; set => fuerza = value; }
        public int Nivel { get => nivel; set => nivel = value; }
        public int Armadura { get => armadura; set => armadura = value; }
    }
}
