using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP3_VariablesAleatorias.Distribuciones;
using TP3_VariablesAleatorias.PruebasBondad;

namespace TP3_VariablesAleatorias
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Uniforme uni = new Uniforme(0, 1);
            uni.generarSerie(30);
            uni.getFrecuenciasObservadas();
            uni.getProbabilidadObservada();
            uni.getProbabilidadEsperada();
            uni.getFrecuenciasEsperadas();
            ChiCuadrado chi = new ChiCuadrado(uni);

            var (resB, chiC, chiT, cadena) = chi.realizarPrueba();

            Console.WriteLine(resB.ToString(), chiC, chiT, cadena);
        }
    }
}
