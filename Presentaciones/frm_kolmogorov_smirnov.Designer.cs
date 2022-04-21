
namespace TP3_VariablesAleatorias.Presentaciones
{
    partial class frm_kolmogorov_smirnov
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
            this.dgvKS = new System.Windows.Forms.DataGridView();
            this.lblKsTab = new System.Windows.Forms.Label();
            this.lblKsCalculado = new System.Windows.Forms.Label();
            this.txtKsTab = new System.Windows.Forms.TextBox();
            this.txtKsCalculado = new System.Windows.Forms.TextBox();
            this.lblCadenaRes = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKS)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvKS
            // 
            this.dgvKS.AllowUserToAddRows = false;
            this.dgvKS.AllowUserToDeleteRows = false;
            this.dgvKS.AllowUserToResizeColumns = false;
            this.dgvKS.AllowUserToResizeRows = false;
            this.dgvKS.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKS.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvKS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKS.Location = new System.Drawing.Point(12, 12);
            this.dgvKS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvKS.Name = "dgvKS";
            this.dgvKS.ReadOnly = true;
            this.dgvKS.RowHeadersVisible = false;
            this.dgvKS.RowHeadersWidth = 51;
            this.dgvKS.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvKS.RowTemplate.Height = 24;
            this.dgvKS.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvKS.Size = new System.Drawing.Size(1209, 423);
            this.dgvKS.TabIndex = 2;
            // 
            // lblKsTab
            // 
            this.lblKsTab.AutoSize = true;
            this.lblKsTab.Location = new System.Drawing.Point(20, 481);
            this.lblKsTab.Name = "lblKsTab";
            this.lblKsTab.Size = new System.Drawing.Size(77, 17);
            this.lblKsTab.TabIndex = 8;
            this.lblKsTab.Text = "KS teórico:";
            // 
            // lblKsCalculado
            // 
            this.lblKsCalculado.AutoSize = true;
            this.lblKsCalculado.Location = new System.Drawing.Point(20, 453);
            this.lblKsCalculado.Name = "lblKsCalculado";
            this.lblKsCalculado.Size = new System.Drawing.Size(89, 17);
            this.lblKsCalculado.TabIndex = 7;
            this.lblKsCalculado.Text = "KS obtenido:";
            // 
            // txtKsTab
            // 
            this.txtKsTab.Enabled = false;
            this.txtKsTab.Location = new System.Drawing.Point(115, 478);
            this.txtKsTab.Name = "txtKsTab";
            this.txtKsTab.Size = new System.Drawing.Size(100, 22);
            this.txtKsTab.TabIndex = 18;
            // 
            // txtKsCalculado
            // 
            this.txtKsCalculado.Enabled = false;
            this.txtKsCalculado.Location = new System.Drawing.Point(115, 450);
            this.txtKsCalculado.Name = "txtKsCalculado";
            this.txtKsCalculado.Size = new System.Drawing.Size(100, 22);
            this.txtKsCalculado.TabIndex = 17;
            // 
            // lblCadenaRes
            // 
            this.lblCadenaRes.AutoSize = true;
            this.lblCadenaRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCadenaRes.Location = new System.Drawing.Point(472, 463);
            this.lblCadenaRes.Name = "lblCadenaRes";
            this.lblCadenaRes.Size = new System.Drawing.Size(20, 25);
            this.lblCadenaRes.TabIndex = 19;
            this.lblCadenaRes.Text = "-";
            this.lblCadenaRes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frm_kolmogorov_smirnov
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1233, 515);
            this.Controls.Add(this.lblCadenaRes);
            this.Controls.Add(this.txtKsTab);
            this.Controls.Add(this.txtKsCalculado);
            this.Controls.Add(this.lblKsTab);
            this.Controls.Add(this.lblKsCalculado);
            this.Controls.Add(this.dgvKS);
            this.Name = "frm_kolmogorov_smirnov";
            this.Text = "Prueba de Bondad de Ajuste - Kolmogorov-Smirnov";
            this.Load += new System.EventHandler(this.frm_kolmogorov_smirnov_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvKS;
        private System.Windows.Forms.Label lblKsTab;
        private System.Windows.Forms.Label lblKsCalculado;
        private System.Windows.Forms.TextBox txtKsTab;
        private System.Windows.Forms.TextBox txtKsCalculado;
        private System.Windows.Forms.Label lblCadenaRes;
    }
}