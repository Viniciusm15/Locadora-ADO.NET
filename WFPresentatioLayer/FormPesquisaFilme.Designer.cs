namespace WFPresentatioLayer
{
    partial class FormPesquisaFilme
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
            this.dtpPFilmes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtpPFilmes)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpPFilmes
            // 
            this.dtpPFilmes.AllowUserToAddRows = false;
            this.dtpPFilmes.AllowUserToDeleteRows = false;
            this.dtpPFilmes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtpPFilmes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtpPFilmes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtpPFilmes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpPFilmes.Location = new System.Drawing.Point(0, 0);
            this.dtpPFilmes.Name = "dtpPFilmes";
            this.dtpPFilmes.ReadOnly = true;
            this.dtpPFilmes.RowHeadersWidth = 51;
            this.dtpPFilmes.RowTemplate.Height = 24;
            this.dtpPFilmes.Size = new System.Drawing.Size(800, 450);
            this.dtpPFilmes.TabIndex = 0;
            // 
            // FormPesquisaFilme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dtpPFilmes);
            this.Name = "FormPesquisaFilme";
            this.ShowIcon = false;
            this.Text = "FormPesquisaFilme";
            ((System.ComponentModel.ISupportInitialize)(this.dtpPFilmes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtpPFilmes;
    }
}