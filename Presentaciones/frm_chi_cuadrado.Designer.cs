
namespace TP3_VariablesAleatorias.Presentaciones
{
    partial class frm_chi_cuadrado
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvChi = new System.Windows.Forms.DataGridView();
            this.lblChiCalculado = new System.Windows.Forms.Label();
            this.lblChiTab = new System.Windows.Forms.Label();
            this.lblCadenaRes = new System.Windows.Forms.Label();
            this.txtChiTab = new System.Windows.Forms.TextBox();
            this.txtChiCalculado = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChi)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvChi
            // 
            this.dgvChi.AllowUserToAddRows = false;
            this.dgvChi.AllowUserToDeleteRows = false;
            this.dgvChi.AllowUserToResizeColumns = false;
            this.dgvChi.AllowUserToResizeRows = false;
            this.dgvChi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvChi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChi.Location = new System.Drawing.Point(12, 11);
            this.dgvChi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvChi.Name = "dgvChi";
            this.dgvChi.ReadOnly = true;
            this.dgvChi.RowHeadersVisible = false;
            this.dgvChi.RowHeadersWidth = 51;
            this.dgvChi.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvChi.RowTemplate.Height = 24;
            this.dgvChi.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvChi.Size = new System.Drawing.Size(860, 407);
            this.dgvChi.TabIndex = 1;
            // 
            // lblChiCalculado
            // 
            this.lblChiCalculado.AutoSize = true;
            this.lblChiCalculado.Location = new System.Drawing.Point(9, 436);
            this.lblChiCalculado.Name = "lblChiCalculado";
            this.lblChiCalculado.Size = new System.Drawing.Size(157, 17);
            this.lblChiCalculado.TabIndex = 2;
            this.lblChiCalculado.Text = "Chi Cuadrado obtenido:";
            // 
            // lblChiTab
            // 
            this.lblChiTab.AutoSize = true;
            this.lblChiTab.Location = new System.Drawing.Point(9, 464);
            this.lblChiTab.Name = "lblChiTab";
            this.lblChiTab.Size = new System.Drawing.Size(145, 17);
            this.lblChiTab.TabIndex = 3;
            this.lblChiTab.Text = "Chi Cuadrado teórico:";
            // 
            // lblCadenaRes
            // 
            this.lblCadenaRes.AutoSize = true;
            this.lblCadenaRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCadenaRes.Location = new System.Drawing.Point(399, 446);
            this.lblCadenaRes.Name = "lblCadenaRes";
            this.lblCadenaRes.Size = new System.Drawing.Size(20, 25);
            this.lblCadenaRes.TabIndex = 6;
            this.lblCadenaRes.Text = "-";
            this.lblCadenaRes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChiTab
            // 
            this.txtChiTab.Enabled = false;
            this.txtChiTab.Location = new System.Drawing.Point(172, 461);
            this.txtChiTab.Name = "txtChiTab";
            this.txtChiTab.Size = new System.Drawing.Size(100, 22);
            this.txtChiTab.TabIndex = 15;
            // 
            // txtChiCalculado
            // 
            this.txtChiCalculado.Enabled = false;
            this.txtChiCalculado.Location = new System.Drawing.Point(172, 433);
            this.txtChiCalculado.Name = "txtChiCalculado";
            this.txtChiCalculado.Size = new System.Drawing.Size(100, 22);
            this.txtChiCalculado.TabIndex = 14;
            // 
            // frm_chi_cuadrado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(884, 497);
            this.Controls.Add(this.txtChiTab);
            this.Controls.Add(this.txtChiCalculado);
            this.Controls.Add(this.lblCadenaRes);
            this.Controls.Add(this.lblChiTab);
            this.Controls.Add(this.lblChiCalculado);
            this.Controls.Add(this.dgvChi);
            this.Name = "frm_chi_cuadrado";
            this.Text = "Prueba de Bondad de Ajuste - Chi Cuadrado";
            this.Load += new System.EventHandler(this.frm_chi_cuadrado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvChi;
        private System.Windows.Forms.Label lblChiCalculado;
        private System.Windows.Forms.Label lblChiTab;
        private System.Windows.Forms.Label lblCadenaRes;
        private System.Windows.Forms.TextBox txtChiTab;
        private System.Windows.Forms.TextBox txtChiCalculado;
    }
}