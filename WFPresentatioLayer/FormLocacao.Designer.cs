namespace WFPresentatioLayer
{
    partial class FormLocacao
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
            this.lbID = new System.Windows.Forms.Label();
            this.btnPesquisaCliente = new System.Windows.Forms.Button();
            this.txtClienteID = new System.Windows.Forms.TextBox();
            this.txtClienteNome = new System.Windows.Forms.TextBox();
            this.lbNome = new System.Windows.Forms.Label();
            this.txtClienteCPF = new System.Windows.Forms.TextBox();
            this.lbCPF = new System.Windows.Forms.Label();
            this.grpDadosClientes = new System.Windows.Forms.GroupBox();
            this.lbFilmesSelecionados = new System.Windows.Forms.Label();
            this.btnPesquisarFilmes = new System.Windows.Forms.Button();
            this.dtgFilmesSelecionados = new System.Windows.Forms.DataGridView();
            this.btnCadastrarLocacao = new System.Windows.Forms.Button();
            this.chkFoiPago = new System.Windows.Forms.CheckBox();
            this.grpDadosClientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgFilmesSelecionados)).BeginInit();
            this.SuspendLayout();
            // 
            // lbID
            // 
            this.lbID.AutoSize = true;
            this.lbID.Location = new System.Drawing.Point(40, 54);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(21, 17);
            this.lbID.TabIndex = 0;
            this.lbID.Text = "ID";
            this.lbID.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnPesquisaCliente
            // 
            this.btnPesquisaCliente.Location = new System.Drawing.Point(141, 337);
            this.btnPesquisaCliente.Name = "btnPesquisaCliente";
            this.btnPesquisaCliente.Size = new System.Drawing.Size(152, 42);
            this.btnPesquisaCliente.TabIndex = 1;
            this.btnPesquisaCliente.Text = "Pesquisar Clientes";
            this.btnPesquisaCliente.UseVisualStyleBackColor = true;
            this.btnPesquisaCliente.Click += new System.EventHandler(this.btnPesquisaCliente_Click);
            // 
            // txtClienteID
            // 
            this.txtClienteID.Location = new System.Drawing.Point(43, 74);
            this.txtClienteID.Name = "txtClienteID";
            this.txtClienteID.Size = new System.Drawing.Size(179, 22);
            this.txtClienteID.TabIndex = 2;
            // 
            // txtClienteNome
            // 
            this.txtClienteNome.Location = new System.Drawing.Point(43, 157);
            this.txtClienteNome.Name = "txtClienteNome";
            this.txtClienteNome.Size = new System.Drawing.Size(179, 22);
            this.txtClienteNome.TabIndex = 4;
            // 
            // lbNome
            // 
            this.lbNome.AutoSize = true;
            this.lbNome.Location = new System.Drawing.Point(40, 137);
            this.lbNome.Name = "lbNome";
            this.lbNome.Size = new System.Drawing.Size(45, 17);
            this.lbNome.TabIndex = 3;
            this.lbNome.Text = "Nome";
            // 
            // txtClienteCPF
            // 
            this.txtClienteCPF.Location = new System.Drawing.Point(43, 240);
            this.txtClienteCPF.Name = "txtClienteCPF";
            this.txtClienteCPF.Size = new System.Drawing.Size(179, 22);
            this.txtClienteCPF.TabIndex = 6;
            // 
            // lbCPF
            // 
            this.lbCPF.AutoSize = true;
            this.lbCPF.Location = new System.Drawing.Point(40, 220);
            this.lbCPF.Name = "lbCPF";
            this.lbCPF.Size = new System.Drawing.Size(34, 17);
            this.lbCPF.TabIndex = 5;
            this.lbCPF.Text = "CPF";
            // 
            // grpDadosClientes
            // 
            this.grpDadosClientes.Controls.Add(this.lbID);
            this.grpDadosClientes.Controls.Add(this.txtClienteCPF);
            this.grpDadosClientes.Controls.Add(this.txtClienteID);
            this.grpDadosClientes.Controls.Add(this.lbCPF);
            this.grpDadosClientes.Controls.Add(this.lbNome);
            this.grpDadosClientes.Controls.Add(this.txtClienteNome);
            this.grpDadosClientes.Enabled = false;
            this.grpDadosClientes.Location = new System.Drawing.Point(37, 38);
            this.grpDadosClientes.Name = "grpDadosClientes";
            this.grpDadosClientes.Size = new System.Drawing.Size(256, 289);
            this.grpDadosClientes.TabIndex = 7;
            this.grpDadosClientes.TabStop = false;
            this.grpDadosClientes.Text = "Dados do Cliente";
            // 
            // lbFilmesSelecionados
            // 
            this.lbFilmesSelecionados.AutoSize = true;
            this.lbFilmesSelecionados.Location = new System.Drawing.Point(327, 38);
            this.lbFilmesSelecionados.Name = "lbFilmesSelecionados";
            this.lbFilmesSelecionados.Size = new System.Drawing.Size(133, 17);
            this.lbFilmesSelecionados.TabIndex = 9;
            this.lbFilmesSelecionados.Text = "FilmesSelecionados";
            // 
            // btnPesquisarFilmes
            // 
            this.btnPesquisarFilmes.Location = new System.Drawing.Point(330, 337);
            this.btnPesquisarFilmes.Name = "btnPesquisarFilmes";
            this.btnPesquisarFilmes.Size = new System.Drawing.Size(195, 42);
            this.btnPesquisarFilmes.TabIndex = 10;
            this.btnPesquisarFilmes.Text = "Pesquisar Filmes";
            this.btnPesquisarFilmes.UseVisualStyleBackColor = true;
            this.btnPesquisarFilmes.Click += new System.EventHandler(this.btnPesquisarFilmes_Click);
            // 
            // dtgFilmesSelecionados
            // 
            this.dtgFilmesSelecionados.AllowUserToAddRows = false;
            this.dtgFilmesSelecionados.AllowUserToDeleteRows = false;
            this.dtgFilmesSelecionados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgFilmesSelecionados.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgFilmesSelecionados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgFilmesSelecionados.Location = new System.Drawing.Point(330, 58);
            this.dtgFilmesSelecionados.Name = "dtgFilmesSelecionados";
            this.dtgFilmesSelecionados.ReadOnly = true;
            this.dtgFilmesSelecionados.RowHeadersWidth = 51;
            this.dtgFilmesSelecionados.RowTemplate.Height = 24;
            this.dtgFilmesSelecionados.Size = new System.Drawing.Size(663, 269);
            this.dtgFilmesSelecionados.TabIndex = 12;
            // 
            // btnCadastrarLocacao
            // 
            this.btnCadastrarLocacao.Location = new System.Drawing.Point(727, 337);
            this.btnCadastrarLocacao.Name = "btnCadastrarLocacao";
            this.btnCadastrarLocacao.Size = new System.Drawing.Size(266, 42);
            this.btnCadastrarLocacao.TabIndex = 13;
            this.btnCadastrarLocacao.Text = "Realizar Locacao";
            this.btnCadastrarLocacao.UseVisualStyleBackColor = true;
            this.btnCadastrarLocacao.Click += new System.EventHandler(this.btnCadastrarLocacao_Click);
            // 
            // chkFoiPago
            // 
            this.chkFoiPago.AutoSize = true;
            this.chkFoiPago.Location = new System.Drawing.Point(37, 349);
            this.chkFoiPago.Name = "chkFoiPago";
            this.chkFoiPago.Size = new System.Drawing.Size(86, 21);
            this.chkFoiPago.TabIndex = 14;
            this.chkFoiPago.Text = "Foi Pago";
            this.chkFoiPago.UseVisualStyleBackColor = true;
            // 
            // FormLocacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 389);
            this.Controls.Add(this.chkFoiPago);
            this.Controls.Add(this.btnCadastrarLocacao);
            this.Controls.Add(this.dtgFilmesSelecionados);
            this.Controls.Add(this.btnPesquisarFilmes);
            this.Controls.Add(this.lbFilmesSelecionados);
            this.Controls.Add(this.grpDadosClientes);
            this.Controls.Add(this.btnPesquisaCliente);
            this.Name = "FormLocacao";
            this.ShowIcon = false;
            this.Text = "FormLocacao";
            this.grpDadosClientes.ResumeLayout(false);
            this.grpDadosClientes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgFilmesSelecionados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbID;
        private System.Windows.Forms.Button btnPesquisaCliente;
        private System.Windows.Forms.TextBox txtClienteID;
        private System.Windows.Forms.TextBox txtClienteNome;
        private System.Windows.Forms.Label lbNome;
        private System.Windows.Forms.TextBox txtClienteCPF;
        private System.Windows.Forms.Label lbCPF;
        private System.Windows.Forms.GroupBox grpDadosClientes;
        private System.Windows.Forms.Label lbFilmesSelecionados;
        private System.Windows.Forms.Button btnPesquisarFilmes;
        private System.Windows.Forms.DataGridView dtgFilmesSelecionados;
        private System.Windows.Forms.Button btnCadastrarLocacao;
        private System.Windows.Forms.CheckBox chkFoiPago;
    }
}