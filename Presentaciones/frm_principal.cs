using System;
using System.Data;
using System.Windows.Forms;

namespace TP3_VariablesAleatorias.Presentaciones
{
    public partial class frm_principal : Form
    {
        public frm_principal()
        {  
            InitializeComponent(); 
        }
        private void frm_principal_Load(object sender, EventArgs e)
        {
            cboDistribucion.SelectedIndex = 0;
        }

        private void disableParameters()
        {
            lblValores.Enabled = false;
            nudValores.Enabled = false;
            lblIntervalos.Enabled = false;
            cbIntervalos.Enabled = false;
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
            cbIntervalos.Enabled = true;

            if (cboDistribucion.SelectedIndex == 0)
            {
                lblIntervalo.Enabled = true;
                lblA.Enabled = true;
                nudA.Enabled = true;
                lblB.Enabled = true;
                nudB.Enabled = true;
            }
            if (cboDistribucion.SelectedIndex == 1)
            {
                lblMedia.Enabled = true;
                nudMedia.Enabled = true;
            }
            if (cboDistribucion.SelectedIndex == 2)
            {
                lblMedia.Enabled = true;
                nudMedia.Enabled = true;
                lblDesviacion.Enabled = true;
                nudDesviacion.Enabled = true;
            }
            if (cboDistribucion.SelectedIndex == 3)
            {
                lblLambda.Enabled = true;
                nudLambda.Enabled = true;
            }
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
            disableParameters();
            DataTable tabla = crearTabla();
            dgvTabla.DataSource = tabla;
            grafico.Show();
        }

        private DataTable crearTabla()
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("Intervalo");
            tabla.Columns.Add("Marca de Clase");
            tabla.Columns.Add("fo");
            tabla.Columns.Add("P() c / mc");
            tabla.Columns.Add("P() c/Pac");
            tabla.Columns.Add("fe");

            tabla.Rows.Add(1, 1, 1, 1, 1, 1);
            tabla.Rows.Add(1, 1, 1, 1, 1, 1);
            
            return tabla;
        }

        private void btnRestablecer_Click(object sender, EventArgs e)
        {
            resetForm();
        }
    }
}
