namespace WFPresentatioLayer
{
    partial class FormFilme
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
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.lbNome = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.dtpDataLancamento = new System.Windows.Forms.DateTimePicker();
            this.lbDataLancamento = new System.Windows.Forms.Label();
            this.cmbGenero = new System.Windows.Forms.ComboBox();
            this.lbGenero = new System.Windows.Forms.Label();
            this.lbClassificacao = new System.Windows.Forms.Label();
            this.txtDuracao = new System.Windows.Forms.TextBox();
            this.lbDuracao = new System.Windows.Forms.Label();
            this.cmbClassificacao = new System.Windows.Forms.ComboBox();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.cmbFiltro = new System.Windows.Forms.ComboBox();
            this.lbFiltro = new System.Windows.Forms.Label();
            this.cmbPesquisa = new System.Windows.Forms.ComboBox();
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.dtgFilmes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtgFilmes)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.BackColor = System.Drawing.Color.White;
            this.btnCadastrar.Location = new System.Drawing.Point(31, 337);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(307, 35);
            this.btnCadastrar.TabIndex = 0;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = false;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // lbNome
            // 
            this.lbNome.AutoSize = true;
            this.lbNome.Location = new System.Drawing.Point(28, 24);
            this.lbNome.Name = "lbNome";
            this.lbNome.Size = new System.Drawing.Size(48, 17);
            this.lbNome.TabIndex = 1;
            this.lbNome.Text = "Nome";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(31, 44);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(299, 23);
            this.txtNome.TabIndex = 2;
            // 
            // dtpDataLancamento
            // 
            this.dtpDataLancamento.CustomFormat = "MM/dd/yyyy";
            this.dtpDataLancamento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDataLancamento.Location = new System.Drawing.Point(31, 107);
            this.dtpDataLancamento.Name = "dtpDataLancamento";
            this.dtpDataLancamento.Size = new System.Drawing.Size(299, 23);
            this.dtpDataLancamento.TabIndex = 3;
            // 
            // lbDataLancamento
            // 
            this.lbDataLancamento.AutoSize = true;
            this.lbDataLancamento.Location = new System.Drawing.Point(28, 87);
            this.lbDataLancamento.Name = "lbDataLancamento";
            this.lbDataLancamento.Size = new System.Drawing.Size(153, 17);
            this.lbDataLancamento.TabIndex = 4;
            this.lbDataLancamento.Text = "Data de Lançamento";
            // 
            // cmbGenero
            // 
            this.cmbGenero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGenero.FormattingEnabled = true;
            this.cmbGenero.Location = new System.Drawing.Point(31, 283);
            this.cmbGenero.Name = "cmbGenero";
            this.cmbGenero.Size = new System.Drawing.Size(299, 24);
            this.cmbGenero.TabIndex = 5;
            // 
            // lbGenero
            // 
            this.lbGenero.AutoSize = true;
            this.lbGenero.Location = new System.Drawing.Point(28, 263);
            this.lbGenero.Name = "lbGenero";
            this.lbGenero.Size = new System.Drawing.Size(59, 17);
            this.lbGenero.TabIndex = 6;
            this.lbGenero.Text = "Gênero";
            // 
            // lbClassificacao
            // 
            this.lbClassificacao.AutoSize = true;
            this.lbClassificacao.Location = new System.Drawing.Point(28, 146);
            this.lbClassificacao.Name = "lbClassificacao";
            this.lbClassificacao.Size = new System.Drawing.Size(95, 17);
            this.lbClassificacao.TabIndex = 7;
            this.lbClassificacao.Text = "Classificação";
            // 
            // txtDuracao
            // 
            this.txtDuracao.Location = new System.Drawing.Point(31, 226);
            this.txtDuracao.Name = "txtDuracao";
            this.txtDuracao.Size = new System.Drawing.Size(299, 23);
            this.txtDuracao.TabIndex = 10;
            // 
            // lbDuracao
            // 
            this.lbDuracao.AutoSize = true;
            this.lbDuracao.Location = new System.Drawing.Point(28, 206);
            this.lbDuracao.Name = "lbDuracao";
            this.lbDuracao.Size = new System.Drawing.Size(66, 17);
            this.lbDuracao.TabIndex = 9;
            this.lbDuracao.Text = "Duração";
            // 
            // cmbClassificacao
            // 
            this.cmbClassificacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClassificacao.FormattingEnabled = true;
            this.cmbClassificacao.Location = new System.Drawing.Point(31, 166);
            this.cmbClassificacao.Name = "cmbClassificacao";
            this.cmbClassificacao.Size = new System.Drawing.Size(299, 24);
            this.cmbClassificacao.TabIndex = 11;
            // 
            // btnLimpar
            // 
            this.btnLimpar.BackColor = System.Drawing.Color.White;
            this.btnLimpar.Location = new System.Drawing.Point(821, 337);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(158, 35);
            this.btnLimpar.TabIndex = 12;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = false;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // cmbFiltro
            // 
            this.cmbFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltro.FormattingEnabled = true;
            this.cmbFiltro.Location = new System.Drawing.Point(394, 44);
            this.cmbFiltro.Name = "cmbFiltro";
            this.cmbFiltro.Size = new System.Drawing.Size(186, 24);
            this.cmbFiltro.TabIndex = 15;
            this.cmbFiltro.SelectedIndexChanged += new System.EventHandler(this.cmbFiltro_SelectedIndexChanged);
            // 
            // lbFiltro
            // 
            this.lbFiltro.AutoSize = true;
            this.lbFiltro.Location = new System.Drawing.Point(391, 24);
            this.lbFiltro.Name = "lbFiltro";
            this.lbFiltro.Size = new System.Drawing.Size(43, 17);
            this.lbFiltro.TabIndex = 14;
            this.lbFiltro.Text = "Filtro";
            // 
            // cmbPesquisa
            // 
            this.cmbPesquisa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPesquisa.FormattingEnabled = true;
            this.cmbPesquisa.Location = new System.Drawing.Point(591, 44);
            this.cmbPesquisa.Name = "cmbPesquisa";
            this.cmbPesquisa.Size = new System.Drawing.Size(186, 24);
            this.cmbPesquisa.TabIndex = 16;
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.Location = new System.Drawing.Point(591, 44);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(186, 23);
            this.txtPesquisa.TabIndex = 18;
            this.txtPesquisa.Visible = false;
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.BackColor = System.Drawing.Color.White;
            this.btnPesquisar.Location = new System.Drawing.Point(804, 45);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(175, 32);
            this.btnPesquisar.TabIndex = 19;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = false;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.BackColor = System.Drawing.Color.White;
            this.btnAtualizar.Location = new System.Drawing.Point(394, 337);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(154, 35);
            this.btnAtualizar.TabIndex = 20;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = false;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.BackColor = System.Drawing.Color.White;
            this.btnExcluir.Location = new System.Drawing.Point(608, 337);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(150, 35);
            this.btnExcluir.TabIndex = 21;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = false;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // dtgFilmes
            // 
            this.dtgFilmes.AllowUserToAddRows = false;
            this.dtgFilmes.AllowUserToDeleteRows = false;
            this.dtgFilmes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgFilmes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgFilmes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgFilmes.Location = new System.Drawing.Point(394, 87);
            this.dtgFilmes.Name = "dtgFilmes";
            this.dtgFilmes.ReadOnly = true;
            this.dtgFilmes.RowHeadersWidth = 51;
            this.dtgFilmes.RowTemplate.Height = 24;
            this.dtgFilmes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgFilmes.Size = new System.Drawing.Size(585, 220);
            this.dtgFilmes.TabIndex = 22;
            this.dtgFilmes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgFilmes_CellDoubleClick);
            // 
            // FormFilme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1009, 391);
            this.Controls.Add(this.dtgFilmes);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.txtPesquisa);
            this.Controls.Add(this.cmbPesquisa);
            this.Controls.Add(this.cmbFiltro);
            this.Controls.Add(this.lbFiltro);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.cmbClassificacao);
            this.Controls.Add(this.txtDuracao);
            this.Controls.Add(this.lbDuracao);
            this.Controls.Add(this.lbClassificacao);
            this.Controls.Add(this.lbGenero);
            this.Controls.Add(this.cmbGenero);
            this.Controls.Add(this.lbDataLancamento);
            this.Controls.Add(this.dtpDataLancamento);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lbNome);
            this.Controls.Add(this.btnCadastrar);
            this.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormFilme";
            this.ShowIcon = false;
            this.Text = "FormFilme";
            this.Load += new System.EventHandler(this.FormFilme_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgFilmes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.Label lbNome;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.DateTimePicker dtpDataLancamento;
        private System.Windows.Forms.Label lbDataLancamento;
        private System.Windows.Forms.ComboBox cmbGenero;
        private System.Windows.Forms.Label lbGenero;
        private System.Windows.Forms.Label lbClassificacao;
        private System.Windows.Forms.TextBox txtDuracao;
        private System.Windows.Forms.Label lbDuracao;
        private System.Windows.Forms.ComboBox cmbClassificacao;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.ComboBox cmbFiltro;
        private System.Windows.Forms.Label lbFiltro;
        private System.Windows.Forms.ComboBox cmbPesquisa;
        private System.Windows.Forms.TextBox txtPesquisa;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.DataGridView dtgFilmes;
    }
}