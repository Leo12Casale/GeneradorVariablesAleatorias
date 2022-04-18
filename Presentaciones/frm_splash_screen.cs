using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP3_VariablesAleatorias.Presentaciones;

namespace TP3_VariablesAleatorias.Presentaciones
{
    public partial class frm_splash_screen : Form
    {
        public frm_splash_screen()
        {
            InitializeComponent();
        }

        private void btn_iniciar_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_principal frp = new frm_principal();
            frp.ShowDialog();
            this.Close();
        }
    }
}
