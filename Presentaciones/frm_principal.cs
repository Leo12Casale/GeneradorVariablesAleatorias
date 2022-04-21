using System;
using System.Data;
using System.Windows.Forms;
using TP3_VariablesAleatorias.Distribuciones;
using TP3_VariablesAleatorias.PruebasBondad;

namespace TP3_VariablesAleatorias.Presentaciones
{
    public partial class frm_principal : Form
    {
        private Distribucion distribucion;
        private PruebaBondad pruebasBondad;
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
            }
            else if (cboDistribucion.SelectedIndex == 2 || cboDistribucion.SelectedIndex == 3)
            {
                lblMedia.Enabled = true;
                nudMedia.Enabled = true;
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
                grafico.Show();

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
    }
}
