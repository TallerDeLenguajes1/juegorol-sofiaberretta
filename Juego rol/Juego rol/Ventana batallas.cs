using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace Juego_rol
{
    public partial class Ventana_batallas : Form
    {
        static Random random = new Random();
        List<Personaje> competidores = new List<Personaje>();
        public Ventana_batallas()
        {
            InitializeComponent();
            competidores = formCrearPersonaje.listaPersonajes;
            SoundPlayer sonidoInicio = new SoundPlayer();
            sonidoInicio.SoundLocation = "D:/Descargas/efectoEntrada.wav";
            sonidoInicio.Play();
            btnAtaqueDer.Hide();
            btnAtaqueIzq.Hide();

            
            generarPelea(competidores);
        }

        private void botonPelea_Click(object sender, EventArgs e)
        {
            SoundPlayer sonidoInicio = new SoundPlayer();
            sonidoInicio.SoundLocation = "D:/Descargas/efectoInicioBatalla.wav";
            sonidoInicio.Play();
            botonPelea.Hide();
            btnAtaqueDer.Show();
            btnAtaqueIzq.Show();
        }


        private void generarPelea(List <Personaje> competidores)
        {
            //Genero valores randoms para las peleas
            int primero = random.Next(0, competidores.Count);
            int segundo = random.Next(0, competidores.Count);
            while (primero == segundo)
            {
                segundo = random.Next(0, competidores.Count);
            }
            //generarCompetidoresRandom(primero, segundo);

            //Izquierdo
            lblNombreIzq.Text = competidores[primero].Nombre;
            lblApodoIzq.Text = competidores[primero].Apodo;
            lblVidaIzq.Text = "Vida: " + competidores[primero].Salud.ToString();
            lblVelocidadIzq.Text = "V: " + competidores[primero].Velocidad.ToString();
            lblDestrezaIzq.Text = "D: " + competidores[primero].Destreza.ToString();
            lblArmaduraIzq.Text = "A: " + competidores[primero].Armadura.ToString();
            lblFuerzaIzq.Text = "F: " + competidores[primero].Fuerza.ToString();
            mostrarImagenIzq(competidores[primero]);

            //Derecho
            lblNombreDer.Text = competidores[segundo].Nombre;
            lblApodoDer.Text = competidores[segundo].Apodo;
            lblVidaDer.Text = "Vida: " + competidores[segundo].Salud.ToString();
            lblVelocidadDer.Text = "V: " + competidores[segundo].Velocidad.ToString();
            lblDestrezaDer.Text = "D: " + competidores[segundo].Destreza.ToString();
            lblArmaduraDer.Text = "A: " + competidores[segundo].Armadura.ToString();
            lblFuerzaDer.Text = "F: " + competidores[segundo].Fuerza.ToString();
            mostrarImagenDer(competidores[segundo]);
        }

        /*
        private void generarCompetidoresRandom(int primero, int segundo)
        {
            primero = random.Next(0, competidores.Count);
            segundo = random.Next(0, competidores.Count);

            while (primero == segundo)
            {
                segundo = random.Next(0, competidores.Count);
            }

        }
        */

        public void mostrarImagenIzq(Personaje personaje)
        {
            switch (personaje.Tipo)
            {
                case tipoDePersonaje.Elfo:
                    pbPersonajeIzq.Image = Image.FromFile("elfo.png");
                    break;
                case tipoDePersonaje.Hada:
                    pbPersonajeIzq.Image = Image.FromFile("hada.png");
                    break;
                case tipoDePersonaje.Humano:
                    int personas = random.Next(0, 2);
                    if (personas == 1)
                    {
                        pbPersonajeIzq.Image = Image.FromFile("Humano.png");
                    }
                    else
                    {
                        pbPersonajeIzq.Image = Image.FromFile("Humano2.png");
                    }
                    break;
                case tipoDePersonaje.Mago:
                    pbPersonajeIzq.Image = Image.FromFile("Mago.png");
                    break;
                case tipoDePersonaje.Orco:
                    pbPersonajeIzq.Image = Image.FromFile("orco.png");
                    break;
            }
        }

        public void mostrarImagenDer(Personaje personaje)
        {
            switch (personaje.Tipo)
            {
                case tipoDePersonaje.Elfo:
                    pbPersonajeDer.Image = Image.FromFile("elfo.png");
                    break;
                case tipoDePersonaje.Hada:
                    pbPersonajeDer.Image = Image.FromFile("hada.png");
                    break;
                case tipoDePersonaje.Humano:
                    int personas = random.Next(0, 2);
                    if (personas == 1)
                    {
                        pbPersonajeDer.Image = Image.FromFile("Humano.png");
                    }
                    else
                    {
                        pbPersonajeDer.Image = Image.FromFile("Humano2.png");
                    }
                    break;
                case tipoDePersonaje.Mago:
                    pbPersonajeDer.Image = Image.FromFile("Mago.png");
                    break;
                case tipoDePersonaje.Orco:
                    pbPersonajeDer.Image = Image.FromFile("orco.png");
                    break;
            }
        }
    }
}
