using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Juego_rol
{
    public partial class Ventana_mostrador : Form
    {
        static Random random = new Random();
        public Ventana_mostrador(Personaje personaje)
        {
            InitializeComponent();
            mostrarPersonaje(personaje);
        }

        private void mostrarPersonaje(Personaje personaje)
        {
            lblNombrePersonaje.Text = personaje.Nombre;
            label1.Text = personaje.Apodo;
            label2.Text = Convert.ToString(personaje.Tipo);
            label3.Text = Convert.ToString(personaje.Edad);
            DateTime fechaSola = personaje.FechaNac.Date;
            label4.Text = fechaSola.ToString("d");
            label5.Text = Convert.ToString(personaje.Salud);
            label6.Text = Convert.ToString(personaje.Velocidad);
            label7.Text = Convert.ToString(personaje.Destreza);
            label8.Text = Convert.ToString(personaje.Armadura);
            label9.Text = Convert.ToString(personaje.Nivel);
            label10.Text = Convert.ToString(personaje.Fuerza);

            switch (personaje.Tipo)
            {
                case tipoDePersonaje.Elfo:
                    pbPersonaje.Image = Image.FromFile("elfo.png");
                    break;
                case tipoDePersonaje.Hada:
                    pbPersonaje.Image = Image.FromFile("hada.png");
                    break;
                case tipoDePersonaje.Humano:
                    int personas = random.Next(0, 2);
                    if(personas == 1)
                    {
                        pbPersonaje.Image = Image.FromFile("Humano.png");
                    }
                    else
                    {
                        pbPersonaje.Image = Image.FromFile("Humano2.png");
                    }
                    break;
                case tipoDePersonaje.Mago:
                    pbPersonaje.Image = Image.FromFile("Mago.png");
                    break;
                case tipoDePersonaje.Orco:
                    pbPersonaje.Image = Image.FromFile("orco.png");
                    break;
            }
        }
    }
}
