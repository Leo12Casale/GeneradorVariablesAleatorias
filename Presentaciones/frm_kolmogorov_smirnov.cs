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
    public partial class frm_kolmogorov_smirnov : Form
    {
        KolmogorovSmirnov pruebaBondad;
        bool resBool;
        double ksCaculado;
        double ksTab;
        string cadenaRes;

        public frm_kolmogorov_smirnov(Distribucion distribucion)
        {
            InitializeComponent();
            pruebaBondad = new KolmogorovSmirnov(distribucion);
            var (resBool, ksCaculado, ksTab, cadenaRes) = pruebaBondad.realizarPrueba();
            this.resBool = resBool;
            this.ksCaculado = ksCaculado;
            this.ksTab = ksTab;
            this.cadenaRes = cadenaRes;
        }

        private void frm_kolmogorov_smirnov_Load(object sender, EventArgs e)
        {
            dgvKS.DataSource = pruebaBondad.generarTabla();
            txtKsCalculado.Text = ksCaculado.ToString();
            txtKsTab.Text = ksTab.ToString();

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
