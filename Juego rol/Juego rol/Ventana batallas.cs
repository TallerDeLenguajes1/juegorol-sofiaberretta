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
        int izquierdo, derecho, contadorAtaques;
        List<Personaje> competidores = new List<Personaje>();
        public Ventana_batallas()
        {
            InitializeComponent();
            competidores = formCrearPersonaje.listaPersonajes; //pongo los personajes creados en una nueva lista

            //sonido de inicio
            SoundPlayer sonidoInicio = new SoundPlayer();
            sonidoInicio.SoundLocation = "D:/Descargas/efectoEntrada.wav"; // ToDo: cambiar la direccion del archivo a relativa
            sonidoInicio.Play();

            //oculto los botones
            botonSiguiente.Hide();
            btnAtaqueDer.Hide();
            btnAtaqueIzq.Hide();
            lblResultadoDer.Hide();
            lblResultadoIzq.Hide();

            //empiezo la pelea mostrando los datos
            muestraDatosCompetidores(competidores);
        }

        private void botonPelea_Click(object sender, EventArgs e)
        {
            //sonido de que empieza pelea
            SoundPlayer sonidoInicio = new SoundPlayer();
            sonidoInicio.SoundLocation = "D:/Descargas/efectoInicioBatalla.wav"; // ToDo: cambiar la direccion del archivo a relativa
            sonidoInicio.Play();

            botonPelea.Hide();
            //Muestro los botones de pelea
            btnAtaqueDer.Show();
            btnAtaqueIzq.Show();
            btnAtaqueDer.Enabled = false; // desactivo el boton de ataque derecho
        }


        public void muestraDatosCompetidores(List <Personaje> competidores)
        {
            btnAtaqueDer.Enabled = true;
            btnAtaqueIzq.Enabled = true;
            lblResultadoDer.Hide();
            lblResultadoIzq.Hide();
            botonSiguiente.Hide();
            //Genero valores para que elija dos personajes randoms para pelear
            generarPersonajesAleatorios();

            //Izquierdo
            lblNombreIzq.Text = competidores[izquierdo].Nombre;
            lblApodoIzq.Text = competidores[izquierdo].Apodo;
            lblVidaIzq.Text = "Vida: " + competidores[izquierdo].Salud.ToString();
            lblVelocidadIzq.Text = "Velocidad: " + competidores[izquierdo].Velocidad.ToString();
            lblDestrezaIzq.Text = "Destreza: " + competidores[izquierdo].Destreza.ToString();
            lblArmaduraIzq.Text = "Armadura: " + competidores[izquierdo].Armadura.ToString();
            lblFuerzaIzq.Text = "Fuerza: " + competidores[izquierdo].Fuerza.ToString();
            mostrarImagenIzq(competidores[izquierdo]);

            //Derecho
            lblNombreDer.Text = competidores[derecho].Nombre;
            lblApodoDer.Text = competidores[derecho].Apodo;
            lblVidaDer.Text = "Vida: " + competidores[derecho].Salud.ToString();
            lblVelocidadDer.Text = "Velocidad: " + competidores[derecho].Velocidad.ToString();
            lblDestrezaDer.Text = "Destreza: " + competidores[derecho].Destreza.ToString();
            lblArmaduraDer.Text = "Armadura: " + competidores[derecho].Armadura.ToString();
            lblFuerzaDer.Text = "Fuerza: " + competidores[derecho].Fuerza.ToString();
            mostrarImagenDer(competidores[derecho]);

        }


        private void btnAtaqueIzq_Click(object sender, EventArgs e)
        {
            ataque(competidores[izquierdo], competidores[derecho]); //genero el danio de izquierdo a derecho
            btnAtaqueDer.Enabled = true; 
            btnAtaqueIzq.Enabled = false;
            actualizarDatos(competidores);
            chequeoGanador(competidores);
        }

        private void btnAtaqueDer_Click(object sender, EventArgs e)
        {
            ataque(competidores[derecho], competidores[izquierdo]);//genero el danio de derecho a izquierdo
            btnAtaqueDer.Enabled = false;
            btnAtaqueIzq.Enabled = true;
            actualizarDatos(competidores);
            contadorAtaques++;
            chequeoGanador(competidores);
        }

        private void chequeoGanador(List<Personaje> competidores)
        {
            if((competidores[derecho].Salud < 0) || (contadorAtaques == 3 && competidores[izquierdo].Salud > competidores[derecho].Salud))
            {
                lblResultadoIzq.Text = "GANADOR";
                lblResultadoDer.Text = "PERDEDOR";
                limpiarPantalla();
                lblResultadoDer.Show();
                lblResultadoIzq.Show();
                imagenVS.Hide();
                
                asignaPremioGanador(competidores[izquierdo]);
                competidores.RemoveAt(derecho);//elimina al perdedor de la lista

                contadorAtaques = 0;

                botonSiguiente.Show();

            } else if ((competidores[izquierdo].Salud < 0) || (contadorAtaques == 3 && competidores[derecho].Salud > competidores[izquierdo].Salud))
            {
                lblResultadoIzq.Text = "PERDEDOR";
                lblResultadoDer.Text = "GANADOR";
                limpiarPantalla();
                lblResultadoDer.Show();
                lblResultadoIzq.Show();
                imagenVS.Hide();

                asignaPremioGanador(competidores[derecho]);
                competidores.RemoveAt(izquierdo);//elimina al perdedor de la lista

                contadorAtaques = 0;

                botonSiguiente.Show();

            } else if (contadorAtaques == 3 && competidores[derecho].Salud == competidores[izquierdo].Salud)
            {
                lblResultadoIzq.Text = "EMPATE";
                lblResultadoDer.Text = "EMPATE";
                limpiarPantalla();
                lblResultadoDer.Show();
                lblResultadoIzq.Show();
                imagenVS.Hide();

                contadorAtaques = 0;

                botonSiguiente.Show();
            }

        }

        private void chequeoCantidadCompetidores()
        {
            if (competidores.Count == 1)
            {
                MessageBox.Show(competidores[0].Apodo + " " + competidores[0].Nombre + " ha ganado!", "VICTORIA");
                Close();
                competidores.Clear();
            }
            else
            {
                muestraDatosCompetidores(competidores);
            }
            
        }

        private void generarPersonajesAleatorios()
        {
            izquierdo = random.Next(0, competidores.Count);
            derecho = random.Next(0, competidores.Count);
            while (izquierdo == derecho)
            {
                derecho = random.Next(0, competidores.Count);
            }
        }

        private void actualizarDatos(List<Personaje> competidores)
        {
            if(competidores[izquierdo].Salud < 0)
            {
                chequeoGanador(competidores);
                competidores[izquierdo].Salud = 0;
            }
            else if(competidores[derecho].Salud < 0)
            {
                chequeoGanador(competidores);
                competidores[derecho].Salud = 0;
            }

            lblVidaIzq.Text = "Vida: " + competidores[izquierdo].Salud.ToString();
            lblVidaDer.Text = "Vida: " + competidores[derecho].Salud.ToString();
        }

        private void ataque(Personaje personaje, Personaje enemigo)
        {
            int efectividadDisparo, poderDisparo, valorAtaque, poderDefensa, danioProvocado;
            efectividadDisparo = random.Next(0, 100) + 1;

            poderDisparo = personaje.Destreza * personaje.Fuerza * personaje.Nivel;
            valorAtaque = poderDisparo * efectividadDisparo;
            poderDefensa = enemigo.Armadura * enemigo.Velocidad * enemigo.Nivel;
            danioProvocado = ((valorAtaque * efectividadDisparo) - poderDefensa) / 5000;

            enemigo.Salud -= danioProvocado;

        }

        private void asignaPremioGanador(Personaje ganador)
        {
            ganador.Salud = 100;
            int opcion = random.Next(0, 5);
            switch (opcion)
            {
                case 0:
                    ganador.Armadura += 3;
                    break;
                case 1:
                    ganador.Destreza += 3;
                    break;
                case 2:
                    ganador.Fuerza += 3;
                    break;
                case 3:
                    ganador.Nivel += 1;
                    break;
                case 4:
                    ganador.Velocidad += 3;
                    break;
            }
        }

        private void limpiarPantalla()
        {
            btnAtaqueDer.Hide();
            btnAtaqueIzq.Hide();
            lblArmaduraDer.Text = "";
            lblArmaduraIzq.Text = "";
            lblDestrezaDer.Text = "";
            lblDestrezaIzq.Text = "";
            lblFuerzaDer.Text = "";
            lblFuerzaIzq.Text = "";
            lblVelocidadDer.Text = "";
            lblVelocidadIzq.Text = "";
            lblVidaDer.Text = "";
            lblVidaIzq.Text = "";
        }

        private void botonSiguiente_Click(object sender, EventArgs e)
        {
            chequeoCantidadCompetidores();
            btnAtaqueDer.Show();
            btnAtaqueIzq.Show();
        }


        //--------------Imagenes----------------------------
        private void mostrarImagenIzq(Personaje personaje)
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
