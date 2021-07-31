using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Juego_rol
{
    public partial class Ventana_ranking : Form
    {
        public Ventana_ranking()
        {
            InitializeComponent();
            cargarDatos();
        }

        private void cargarDatos()
        {
            List<Personaje> listaGanadores = Ventana_batallas.leerJson();

            if(listaGanadores.Count < 10)
            {
                for(int i = listaGanadores.Count; i < 10; i++)
                {
                    Personaje vacio = new Personaje();
                    vacio.Nombre = "";
                    vacio.Nivel = 0;
                    listaGanadores.Add(vacio);
                }
            }

            label14.Text = listaGanadores[0].Nombre;
            label24.Text = listaGanadores[0].Nivel.ToString();

            label15.Text = listaGanadores[1].Nombre;
            label25.Text = listaGanadores[1].Nivel.ToString();

            label16.Text = listaGanadores[2].Nombre;
            label26.Text = listaGanadores[2].Nivel.ToString();

            label17.Text = listaGanadores[3].Nombre;
            label27.Text = listaGanadores[3].Nivel.ToString();

            label18.Text = listaGanadores[4].Nombre;
            label28.Text = listaGanadores[4].Nivel.ToString();

            label19.Text = listaGanadores[5].Nombre;
            label29.Text = listaGanadores[5].Nivel.ToString();

            label20.Text = listaGanadores[6].Nombre;
            label30.Text = listaGanadores[6].Nivel.ToString();

            label21.Text = listaGanadores[7].Nombre;
            label31.Text = listaGanadores[7].Nivel.ToString();

            label22.Text = listaGanadores[8].Nombre;
            label32.Text = listaGanadores[8].Nivel.ToString();

            label23.Text = listaGanadores[9].Nombre;
            label33.Text = listaGanadores[9].Nivel.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
