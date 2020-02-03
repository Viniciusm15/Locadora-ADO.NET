namespace WFPresentatioLayer
{
    partial class FormPesquisaCliente
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
            this.dtpClientes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtpClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpClientes
            // 
            this.dtpClientes.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dtpClientes.AllowUserToAddRows = false;
            this.dtpClientes.AllowUserToDeleteRows = false;
            this.dtpClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtpClientes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtpClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtpClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpClientes.Location = new System.Drawing.Point(0, 0);
            this.dtpClientes.MultiSelect = false;
            this.dtpClientes.Name = "dtpClientes";
            this.dtpClientes.ReadOnly = true;
            this.dtpClientes.RowHeadersWidth = 51;
            this.dtpClientes.RowTemplate.Height = 24;
            this.dtpClientes.Size = new System.Drawing.Size(800, 450);
            this.dtpClientes.TabIndex = 0;
            // 
            // FormPesquisaCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dtpClientes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormPesquisaCliente";
            this.Text = "Selecione um Cliente";
            ((System.ComponentModel.ISupportInitialize)(this.dtpClientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtpClientes;
    }
}