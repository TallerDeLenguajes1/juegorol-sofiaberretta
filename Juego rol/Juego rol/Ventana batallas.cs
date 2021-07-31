using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace Juego_rol
{
    public partial class Ventana_batallas : Form
    {
        static Random random = new Random();
        int izquierdo, derecho, contadorAtaques;
        List<Personaje> competidores; // = new List<Personaje>();
        public Ventana_batallas()
        {
            InitializeComponent();
            competidores = formCrearPersonaje.listaPersonajes; //pongo los personajes creados en una nueva lista

            //sonido de inicio
            SoundPlayer sonidoInicio = new SoundPlayer();
            sonidoInicio.SoundLocation = "efectoEntrada.wav"; 
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
            sonidoInicio.SoundLocation = "efectoInicioBatalla.wav"; 
            sonidoInicio.Play();

            botonPelea.Hide();
            //Muestro los botones de pelea
            btnAtaqueDer.Show();
            btnAtaqueIzq.Show();
            btnAtaqueDer.Enabled = false; // desactivo el boton de ataque derecho
        }


        public void muestraDatosCompetidores(List <Personaje> competidores)
        {
            btnAtaqueDer.Enabled = false;
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
            lblNivelIzq.Text = "Nivel " + competidores[izquierdo].Nivel.ToString();
            mostrarImagenIzq(competidores[izquierdo]);

            //Derecho
            lblNombreDer.Text = competidores[derecho].Nombre;
            lblApodoDer.Text = competidores[derecho].Apodo;
            lblVidaDer.Text = "Vida: " + competidores[derecho].Salud.ToString();
            lblVelocidadDer.Text = "Velocidad: " + competidores[derecho].Velocidad.ToString();
            lblDestrezaDer.Text = "Destreza: " + competidores[derecho].Destreza.ToString();
            lblArmaduraDer.Text = "Armadura: " + competidores[derecho].Armadura.ToString();
            lblFuerzaDer.Text = "Fuerza: " + competidores[derecho].Fuerza.ToString();
            lblNivelDer.Text = "Nivel " + competidores[derecho].Nivel.ToString();
            mostrarImagenDer(competidores[derecho]);

        }


        private void btnAtaqueIzq_Click(object sender, EventArgs e)
        {
            ataque(competidores[izquierdo], competidores[derecho]); //genero el danio de izquierdo a derecho
            btnAtaqueDer.Enabled = true; 
            btnAtaqueIzq.Enabled = false;
            actualizarDatos(competidores);
            chequeoResultados(competidores);
        }

        private void btnAtaqueDer_Click(object sender, EventArgs e)
        {
            ataque(competidores[derecho], competidores[izquierdo]);//genero el danio de derecho a izquierdo
            btnAtaqueDer.Enabled = false;
            btnAtaqueIzq.Enabled = true;
            actualizarDatos(competidores);
            contadorAtaques++;
            chequeoResultados(competidores);
        }

        private void chequeoResultados(List<Personaje> competidores)
        {
            if((competidores[derecho].Salud == 0) || (contadorAtaques == 3 && competidores[izquierdo].Salud > competidores[derecho].Salud))
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

                chequeoGanadorFinal();
                //botonSiguiente.Show();

            }
            else if ((competidores[izquierdo].Salud == 0) || (contadorAtaques == 3 && competidores[derecho].Salud > competidores[izquierdo].Salud))
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

                chequeoGanadorFinal();
                //botonSiguiente.Show();

            }
            else if (contadorAtaques == 3 && competidores[derecho].Salud == competidores[izquierdo].Salud)
            {
                lblResultadoIzq.Text = "EMPATE";
                lblResultadoDer.Text = "EMPATE";
                limpiarPantalla();
                lblResultadoDer.Show();
                lblResultadoIzq.Show();
                imagenVS.Hide();

                contadorAtaques = 0;

                chequeoGanadorFinal();
                //botonSiguiente.Show();
            }

        }

        private void chequeoGanadorFinal()
        {
            if (competidores.Count == 1)
            {
                MessageBox.Show(competidores[0].Apodo + " " + competidores[0].Nombre + " ha ganado!", "VICTORIA");
                guardarGanadorJson(competidores[0]);
                Close();
                competidores.Clear();
            }
            else
            {
                botonSiguiente.Show();
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
            if(enemigo.Salud < 0)
            {
                enemigo.Salud = 0;
            }

        }

        private void asignaPremioGanador(Personaje ganador)
        {
            ganador.Salud = 100;
            ganador.Nivel += 1;
            int opcion = random.Next(0, 4);
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
            muestraDatosCompetidores(competidores);
            imagenVS.Show();
            btnAtaqueDer.Show();
            btnAtaqueIzq.Show();
        }


        private void guardarGanadorJson(Personaje ganador)
        {
            List<Personaje> listaGanadores = leerJson();

            int i;
            for (i = 0; i < listaGanadores.Count; i++)
            {
                if (listaGanadores[i].Nivel < ganador.Nivel)
                {
                    listaGanadores.Insert(i, ganador);
                }
            }

            if (listaGanadores.Count > 10)
            {
                listaGanadores.RemoveAt(10);
            }

            
            string ganadoresStr = JsonSerializer.Serialize(ganador);
            FileStream archivo = new FileStream("Ganadores.json", FileMode.Create);
            using (StreamWriter strWriter = new StreamWriter(archivo))
            {
                strWriter.WriteLine("{0}", ganadoresStr);
                strWriter.Close();
            }
            
        }

        public static List<Personaje> leerJson()
        {
            List<Personaje> listaGanadores;
            string rutaArchivo = @"Ganadores.json";

            try
            {
                using (StreamReader leerJson = File.OpenText(rutaArchivo))
                {
                    var Json = leerJson.ReadToEnd();
                    listaGanadores = JsonSerializer.Deserialize<List<Personaje>>(Json);
                }
            }
            catch (FileNotFoundException)
            {
                listaGanadores = new List<Personaje>();
            }

            return listaGanadores;
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

        public void cambiarFondo(string provinciaElegida)
        {
            switch (provinciaElegida)
            {
                case "Buenos Aires":
                    this.BackgroundImage = Image.FromFile("Buenos_Aires.jpg");
                    break;
                case "Ciudad Autónoma de Buenos Aires":
                    this.BackgroundImage = Image.FromFile("CABA.jpg");
                    break;
                case "Misiones":
                    this.BackgroundImage = Image.FromFile("Misiones.jpg");
                    break;
                case "San Luis":
                    this.BackgroundImage = Image.FromFile("San_Luis.jpg");
                    break;
                case "San Juan":
                    this.BackgroundImage = Image.FromFile("San_Juan.jpg");
                    break;
                case "Entre Ríos":
                    this.BackgroundImage = Image.FromFile("Entre_Rios.jpg");
                    break;
                case "Santa Cruz":
                    this.BackgroundImage = Image.FromFile("Santa_Cruz.jpg");
                    break;
                case "Río Negro":
                    this.BackgroundImage = Image.FromFile("Rio_Negro.jpg");
                    break;
                case "Chubut":
                    this.BackgroundImage = Image.FromFile("Chubut.jpg");
                    break;
                case "Córdoba":
                    this.BackgroundImage = Image.FromFile("Cordoba.jpg");
                    break;
                case "Mendoza":
                    this.BackgroundImage = Image.FromFile("Mendoza.jpg");
                    break;
                case "La Rioja":
                    this.BackgroundImage = Image.FromFile("La_Rioja.jpg");
                    break;
                case "Catamarca":
                    this.BackgroundImage = Image.FromFile("Catamarca.jpg");
                    break;
                case "La Pampa":
                    this.BackgroundImage = Image.FromFile("La_Pampa.jpg");
                    break;
                case "Santiago del Estero":
                    this.BackgroundImage = Image.FromFile("Sgo_del_Estero.jpg");
                    break;
                case "Corrientes":
                    this.BackgroundImage = Image.FromFile("Corrientes.jpg");
                    break;
                case "Santa Fe":
                    this.BackgroundImage = Image.FromFile("Santa_Fe.jpeg");
                    break;
                case "Tucumán":
                    this.BackgroundImage = Image.FromFile("Tucuman.jpg");
                    break;
                case "Neuquén":
                    this.BackgroundImage = Image.FromFile("Neuquen.jpg");
                    break;
                case "Chaco":
                    this.BackgroundImage = Image.FromFile("Chaco.jpg");
                    break;
                case "Formosa":
                    this.BackgroundImage = Image.FromFile("Formosa.jpg");
                    break;
                case "Jujuy":
                    this.BackgroundImage = Image.FromFile("Jujuy.jpg");
                    break;
                case "Tierra del Fuego, Antártida e Islas del Atlántico":
                    this.BackgroundImage = Image.FromFile("Tierra_del_Fuego.jpg");
                    break;
                case "Salta":
                    this.BackgroundImage = Image.FromFile("Salta.jpg");
                    break;
                case "Predeterminado":
                    this.BackgroundImage = Image.FromFile("Fondo.png");
                    break;
            }
                  
        }
    }
}
