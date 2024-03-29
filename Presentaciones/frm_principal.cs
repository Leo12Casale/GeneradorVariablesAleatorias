﻿using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using TP3_VariablesAleatorias.Distribuciones;
using TP3_VariablesAleatorias.PruebasBondad;

namespace TP3_VariablesAleatorias.Presentaciones
{
    public partial class frm_principal : Form
    {
        private Distribucion distribucion;
        
        public frm_principal()
        {  
            InitializeComponent(); 
        }
        private void frm_principal_Load(object sender, EventArgs e)
        {
            cboDistribucion.SelectedIndex = 0;            
            cboIntervalos.SelectedIndex = 0;

            btnKS.Enabled = false;
            btnChi.Enabled = false;
        }

        private void disableParameters()
        {
            lblValores.Enabled = false;
            nudValores.Enabled = false;
            lblIntervalos.Enabled = false;
            cboIntervalos.Enabled = false;
            lblIntervalo.Enabled = false;
            lblA.Enabled = false;
            nudA.Enabled = false;
            lblB.Enabled = false;
            nudB.Enabled = false;
            lblMedia.Enabled = false;
            nudMedia.Enabled = false;
            lblMedia.Enabled = false;
            nudMedia.Enabled = false;
            lblDesviacion.Enabled = false;
            nudDesviacion.Enabled = false;
            lblLambda.Enabled = false;
            nudLambda.Enabled = false;
        }

        private void resetForm()
        {            
            dgvTabla.Columns.Clear();
            disableParameters();
            grafico.Hide();

            lblValores.Enabled = true;
            nudValores.Enabled = true;
            lblIntervalos.Enabled = true;
            cboIntervalos.Enabled = true;
            btnKS.Enabled = false;
            btnChi.Enabled = false;

            if (cboDistribucion.SelectedIndex == 0)
            {
                lblIntervalo.Enabled = true;
                lblA.Enabled = true;
                nudA.Enabled = true;
                lblB.Enabled = true;
                nudB.Enabled = true;
            }
            else if (cboDistribucion.SelectedIndex == 1)
            {
                lblMedia.Enabled = true;
                nudMedia.Enabled = true;
                nudMedia.Minimum = (decimal)0.00001;
            }
            else if (cboDistribucion.SelectedIndex == 2 || cboDistribucion.SelectedIndex == 3)
            {
                lblMedia.Enabled = true;
                nudMedia.Enabled = true;
                nudMedia.Minimum = -10000;
                lblDesviacion.Enabled = true;
                nudDesviacion.Enabled = true;
            }
            else if (cboDistribucion.SelectedIndex == 4)
            {
                lblLambda.Enabled = true;
                nudLambda.Enabled = true;
            }
        }

        private bool validateParameters()
        {
            if (nudValores.Value == 0)
            {
                MessageBox.Show("La cantidad de valores a generar debe ser mayor a 0.", "Generación de Valores", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cboDistribucion.SelectedIndex == 0 & nudB.Value <= nudA.Value)
            {
                MessageBox.Show("Verifique los valores del intervalo [A; B]. 'B' debe ser mayor a 'A'.", "Generación de Valores", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (getIntervalos() > nudValores.Value)
            {
                MessageBox.Show("La cantidad de intervalos no puede ser mayor a la cantidad de números generados", "Generación de Valores", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void cboMetodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            resetForm();
        }

        private void numActive(object sender, EventArgs e)
        {
            NumericUpDown clickedNumeric = (NumericUpDown)sender;
            clickedNumeric.Select(0, clickedNumeric.Text.Length);
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (validateParameters())
            {
                distribucion = obtenerDistribucion();
                distribucion.generarSerie((int)nudValores.Value);
                dgvTabla.DataSource = distribucion.generarTabla(); 
                generarGrafico();
                disableParameters();
                if (!distribucion.esPoisson()) btnKS.Enabled = true;
                btnChi.Enabled = true;                
            } 
        }
        
        private int getIntervalos()
        {
            switch (cboIntervalos.SelectedIndex)
            {
                case 0: return 8;
                case 1: return 10;
                case 2: return 15;
                case 3: return 20;
                default: return 8;
            }
        }
        
        private Distribucion obtenerDistribucion()
        {
            if (cboDistribucion.SelectedIndex == 0)
                return new Uniforme((double)nudA.Value, (double)nudB.Value, getIntervalos());
            if (cboDistribucion.SelectedIndex == 1) 
                return new Exponencial((double)nudMedia.Value, getIntervalos());
            if (cboDistribucion.SelectedIndex == 2)
                return new NormalBoxMuller((double)nudMedia.Value, (double)nudDesviacion.Value, getIntervalos());
            if (cboDistribucion.SelectedIndex == 3) 
                return new NormalConvolucion((double) nudMedia.Value, (double) nudDesviacion.Value, getIntervalos());
            if (cboDistribucion.SelectedIndex == 4)
                return new Poisson((double)nudLambda.Value);
            return null;
        } 

        private void btnRestablecer_Click(object sender, EventArgs e)
        {
            resetForm();
        }
        
        private void btnChi_Click(object sender, EventArgs e)
        {
            frm_chi_cuadrado frm_chi = new frm_chi_cuadrado(distribucion);
            frm_chi.ShowDialog();
        }
        
        private void btnKS_Click(object sender, EventArgs e)
        {
            frm_kolmogorov_smirnov frm_ks = new frm_kolmogorov_smirnov(distribucion);
            frm_ks.ShowDialog();
        } 

        #region Grafico

        private void generarGrafico()
        {
            if (distribucion == null)
            {
                MessageBox.Show("Debe generar datos para graficar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int[] frecuenciasObservadas = distribucion.getFrecuenciasObservadas();
            double[] frecuenciasEsperadas = distribucion.getFrecuenciasEsperadas();
            double[] intervalosDesde = distribucion.getIntervalosDesde();
            double[] intervalosHasta = distribucion.getIntervalosHasta();
            double min = intervalosDesde[0];
            double max = intervalosHasta[frecuenciasObservadas.Length - 1];
            //string[] labelsIntervalos = distribucion.getIntervalos();

            if (frecuenciasObservadas == null || frecuenciasObservadas.Length == 0)
            {
                MessageBox.Show("Debe generar datos para graficar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            grafico.Show();

            double offsetX = (intervalosHasta[0] - intervalosDesde[0]);
            if (distribucion.esPoisson()) offsetX = 2;
            grafico.ChartAreas[0].AxisX.Minimum = min - offsetX;
            grafico.ChartAreas[0].AxisX.Maximum = max + offsetX;


            grafico.Series[0].Points.Clear();
            grafico.Series[1].Points.Clear();
            Series serieEsperada = grafico.Series[0];
            Series serieObtenida = grafico.Series[1];

            for (int i = 0; i < frecuenciasObservadas.Length; i++)
            {
                double xCoord = intervalosDesde[i];
                int pointEsperado = serieEsperada.Points.AddXY(xCoord, frecuenciasEsperadas[i]);
                int pointObtenido = serieObtenida.Points.AddXY(xCoord, frecuenciasObservadas[i]);

                string labelIntervalo = "[" + intervalosDesde[i] + " - " + intervalosHasta[i] + ")";
                if (distribucion.esPoisson())
                    labelIntervalo = intervalosDesde[i].ToString();
                serieEsperada.Points[pointEsperado].ToolTip = labelIntervalo + ": " + frecuenciasEsperadas[i];
                serieObtenida.Points[pointObtenido].ToolTip = labelIntervalo + ": " + frecuenciasObservadas[i];
            }
        }
        #endregion

        private void grafico_Click(object sender, EventArgs e)
        {

        }
    }
}
