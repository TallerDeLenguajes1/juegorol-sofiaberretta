using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Juego_rol
{
    public partial class formCrearPersonaje : Form
    {
        static Random random = new Random();
        public static List<Personaje> listaPersonajes = new List<Personaje>();
        public formCrearPersonaje()
        {
            InitializeComponent();
        }

        private void btCrearPersonaje_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApodo.Text))
            {
                MessageBox.Show("Faltan rellenar datos.", "ERROR");
            }
            else
            {
                Personaje nuevoPersonaje = new Personaje();
                crearPersonaje(nuevoPersonaje);
                listaPersonajes.Add(nuevoPersonaje);

                mostrarPersonajeCreado(nuevoPersonaje);
                limpiarDatos();
            }
            
        }

        private void crearPersonaje(Personaje nuevoPersonaje)
        {
            nuevoPersonaje.Nombre = txtNombre.Text;
            nuevoPersonaje.Apodo = txtApodo.Text;
            nuevoPersonaje.Tipo = (tipoDePersonaje)comboBoxTipo.SelectedIndex;
            nuevoPersonaje.FechaNac = dTPFechaNac.Value;
            nuevoPersonaje.Edad = calcularEdad(nuevoPersonaje.FechaNac);

            nuevoPersonaje.Velocidad = GenerarValoresRandom(0, 10);
            nuevoPersonaje.Destreza = GenerarValoresRandom(0, 5);
            nuevoPersonaje.Fuerza = GenerarValoresRandom(0, 10);
            nuevoPersonaje.Armadura = GenerarValoresRandom(0, 10);
            nuevoPersonaje.Nivel = 1;
        }

        private void mostrarPersonajeCreado(Personaje personajeCreado)
        {
            Ventana_mostrador ventanaVistaPersonaje = new Ventana_mostrador(personajeCreado);
            ventanaVistaPersonaje.Show();
        }


        //------------------Personajes random----------------------------
        private void btRellenarRandom_Click(object sender, EventArgs e)
        {
            crearPersonajeRandom();
        }

        private void crearPersonajeRandom()
        {
            txtNombre.Text = GenerarNombreRandom();
            txtApodo.Text = GenerarApodoRandom();
            comboBoxTipo.SelectedItem = GenerarTipoRandom();
            dTPFechaNac.Value = GenerarFechaRandom();

        }

        private string GenerarNombreRandom()
        {
            string[] nombres = { "Gandalf", "Legolas", "Gollum", "Gimli", "Galadriel", "Samsagaz", "Arwen", "Morgana" };
            int numNombre = random.Next(nombres.Length);
            return nombres[numNombre];
        }

        private string GenerarApodoRandom()
        {
            string[] apodos = { "El fuerte", "El rapido", "La poderosa", "La increible", "El mejor", "La inigualable", "El fortachon", "El imparable", "La bestia" };
            int numApodo = random.Next(apodos.Length);
            return apodos[numApodo];
        }

        private string GenerarTipoRandom()
        {

            int num = random.Next(5);
            string tipo;

            switch (num)
            {
                case 0:
                    tipo = "Elfo";
                    break;
                case 1:
                    tipo = "Hada";
                    break;
                case 2:
                    tipo = "Humano";
                    break;
                case 3:
                    tipo = "Mago";
                    break;
                default:
                    tipo = "Orco";
                    break;
            }

            return tipo;
        }

        private DateTime GenerarFechaRandom()
        {
            DateTime inicio = new DateTime(1753, 1, 1);
            int range = (DateTime.Today - inicio).Days;
            return inicio.AddDays(random.Next(range)).Date;
        }

        private int calcularEdad(DateTime fechaNacimiento)
        {
            return DateTime.Today.Year - fechaNacimiento.Year;
        }

        private int GenerarValoresRandom(int minimo, int maximo)
        {
            return random.Next(minimo, maximo) + 1;
        }

        public void limpiarDatos()
        {
            txtNombre.Text = "";
            txtApodo.Text = "";
            dTPFechaNac.Value = DateTime.Now;
        }
        
    }
}
