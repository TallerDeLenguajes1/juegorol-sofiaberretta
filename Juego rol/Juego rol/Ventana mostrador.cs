using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Juego_rol
{
    public partial class Ventana_mostrador : Form
    {
        static Random random = new Random();
        public Ventana_mostrador(Personaje personaje)
        {
            InitializeComponent();
            inicializarComboBox();
            if (formCrearPersonaje.listaPersonajes.Count < 2)
            {
                comboBoxProvincias.Hide();
            }
            else
            {
                comboBoxProvincias.Show();
            }
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

            mostrarImagenTipo(personaje);
            
        }

        public void mostrarImagenTipo(Personaje personaje)
        {
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
                    if (personas == 1)
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

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(formCrearPersonaje.listaPersonajes.Count < 2)
            {
                MessageBox.Show("Debe tener al menos 2 personajes creados.");
                Close();
            }
            else
            {
                if (comboBoxProvincias.SelectedItem == null)
                {
                    MessageBox.Show("Debe elegir un mapa.");
                }
                else
                {
                    Ventana_batallas ventanaBatallaNueva = new Ventana_batallas();
                    ventanaBatallaNueva.cambiarFondo(comboBoxProvincias.SelectedItem.ToString());
                    ventanaBatallaNueva.Show();
                    Close();
                }
                
            }

        }

        
        //-------------------------parte de API----------------------------------

        private void inicializarComboBox()
        {
            ProvinciasArgentina listaProvincias;
            listaProvincias = ObtieneProvincias();

            foreach (Provincia Prov in listaProvincias.Provincias)
            {
                comboBoxProvincias.Items.Add(Prov.Nombre);
            }

            comboBoxProvincias.Items.Add("Predeterminado");
            
        }


        private static ProvinciasArgentina ObtieneProvincias()
        {
            var url = $"https://apis.datos.gob.ar/georef/api/provincias?campos=id,nombre";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            ProvinciasArgentina ProvinciasArg;
            ProvinciasArg = null;
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader != null)
                        {
                            using (StreamReader objReader = new StreamReader(strReader))
                            {
                                string responseBody = objReader.ReadToEnd();
                                ProvinciasArg = JsonSerializer.Deserialize<ProvinciasArgentina>(responseBody);
                            }
                        }
                    }
                }
            }
            catch (WebException)
            {
                // Handle error
            }
            return ProvinciasArg;
        }

        // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
        public class Parametros
        {
            [JsonPropertyName("campos")]
            public List<string> Campos { get; set; }
        }

        public class Provincia
        {
            [JsonPropertyName("id")]
            public string Id { get; set; }

            [JsonPropertyName("nombre")]
            public string Nombre { get; set; }
        }

        public class ProvinciasArgentina
        {
            [JsonPropertyName("cantidad")]
            public int Cantidad { get; set; }

            [JsonPropertyName("inicio")]
            public int Inicio { get; set; }

            [JsonPropertyName("parametros")]
            public Parametros Parametros { get; set; }

            [JsonPropertyName("provincias")]
            public List<Provincia> Provincias { get; set; }

            [JsonPropertyName("total")]
            public int Total { get; set; }
        }
    }
}
