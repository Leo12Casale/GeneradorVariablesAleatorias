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

namespace TP3_VariablesAleatorias.Presentaciones
{
    public partial class frm_chi_cuadrado : Form
    {
        ChiCuadrado pruebaBondad;
        bool resBool;
        double chCaculado;
        double chTab;
        string cadenaRes;

        public frm_chi_cuadrado(Distribucion distribucion)
        {
            InitializeComponent();
            pruebaBondad = new ChiCuadrado(distribucion);
            var (resBool, chCaculado, chTab, cadenaRes) = pruebaBondad.realizarPrueba();
            this.resBool = resBool;
            this.chCaculado = chCaculado;
            this.chTab = chTab;
            this.cadenaRes = cadenaRes;
        }
        
        private void frm_chi_cuadrado_Load(object sender, EventArgs e)
        {
            dgvChi.DataSource = pruebaBondad.generarTabla();
            txtChiCalculado.Text = chCaculado.ToString();
            txtChiTab.Text = chTab.ToString();

            if (resBool)
            {
                lblCadenaRes.BackColor = Color.Green;
            }
            else
            {
                lblCadenaRes.BackColor = Color.Red;
            }
            lblCadenaRes.Text = cadenaRes;
        }
    }
}
