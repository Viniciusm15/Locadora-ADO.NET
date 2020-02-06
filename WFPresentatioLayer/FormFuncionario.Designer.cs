namespace WFPresentatioLayer
{
    partial class FormFuncionario
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
            this.dtpDataNascimento = new System.Windows.Forms.DateTimePicker();
            this.txtDataNascimento = new System.Windows.Forms.Label();
            this.lbCPF = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lbEmail = new System.Windows.Forms.Label();
            this.lbTelefone = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbInativo = new System.Windows.Forms.RadioButton();
            this.rdbAtivo = new System.Windows.Forms.RadioButton();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.lbSenha = new System.Windows.Forms.Label();
            this.txtCPF = new System.Windows.Forms.MaskedTextBox();
            this.txtTelefone = new System.Windows.Forms.MaskedTextBox();
            this.dtgFuncionario = new System.Windows.Forms.DataGridView();
            this.btnMostrarSenha = new System.Windows.Forms.Button();
            this.btnMostrarSenhaConfirmacao = new System.Windows.Forms.Button();
            this.txtConfirmarSenha = new System.Windows.Forms.TextBox();
            this.lbConfirmarSenha = new System.Windows.Forms.Label();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgFuncionario)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.BackColor = System.Drawing.Color.White;
            this.btnCadastrar.Location = new System.Drawing.Point(317, 283);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(231, 55);
            this.btnCadastrar.TabIndex = 0;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = false;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // lbNome
            // 
            this.lbNome.AutoSize = true;
            this.lbNome.Location = new System.Drawing.Point(40, 21);
            this.lbNome.Name = "lbNome";
            this.lbNome.Size = new System.Drawing.Size(48, 17);
            this.lbNome.TabIndex = 1;
            this.lbNome.Text = "Nome";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(43, 41);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(231, 23);
            this.txtNome.TabIndex = 2;
            // 
            // dtpDataNascimento
            // 
            this.dtpDataNascimento.CustomFormat = "MM/dd/yyyy";
            this.dtpDataNascimento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDataNascimento.Location = new System.Drawing.Point(40, 113);
            this.dtpDataNascimento.Name = "dtpDataNascimento";
            this.dtpDataNascimento.Size = new System.Drawing.Size(234, 23);
            this.dtpDataNascimento.TabIndex = 3;
            // 
            // txtDataNascimento
            // 
            this.txtDataNascimento.AutoSize = true;
            this.txtDataNascimento.Location = new System.Drawing.Point(40, 93);
            this.txtDataNascimento.Name = "txtDataNascimento";
            this.txtDataNascimento.Size = new System.Drawing.Size(149, 17);
            this.txtDataNascimento.TabIndex = 4;
            this.txtDataNascimento.Text = "Data de Nascimento";
            // 
            // lbCPF
            // 
            this.lbCPF.AutoSize = true;
            this.lbCPF.Location = new System.Drawing.Point(314, 21);
            this.lbCPF.Name = "lbCPF";
            this.lbCPF.Size = new System.Drawing.Size(34, 17);
            this.lbCPF.TabIndex = 5;
            this.lbCPF.Text = "CPF";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(317, 113);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(231, 23);
            this.txtEmail.TabIndex = 8;
            // 
            // lbEmail
            // 
            this.lbEmail.AutoSize = true;
            this.lbEmail.Location = new System.Drawing.Point(314, 93);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(44, 17);
            this.lbEmail.TabIndex = 7;
            this.lbEmail.Text = "Email";
            // 
            // lbTelefone
            // 
            this.lbTelefone.AutoSize = true;
            this.lbTelefone.Location = new System.Drawing.Point(37, 160);
            this.lbTelefone.Name = "lbTelefone";
            this.lbTelefone.Size = new System.Drawing.Size(65, 17);
            this.lbTelefone.TabIndex = 9;
            this.lbTelefone.Text = "Telefone";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbInativo);
            this.groupBox1.Controls.Add(this.rdbAtivo);
            this.groupBox1.Location = new System.Drawing.Point(40, 238);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(234, 100);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Status";
            // 
            // rdbInativo
            // 
            this.rdbInativo.AutoSize = true;
            this.rdbInativo.Location = new System.Drawing.Point(135, 45);
            this.rdbInativo.Name = "rdbInativo";
            this.rdbInativo.Size = new System.Drawing.Size(77, 21);
            this.rdbInativo.TabIndex = 1;
            this.rdbInativo.Text = "Inativo";
            this.rdbInativo.UseVisualStyleBackColor = true;
            // 
            // rdbAtivo
            // 
            this.rdbAtivo.AutoSize = true;
            this.rdbAtivo.Checked = true;
            this.rdbAtivo.Location = new System.Drawing.Point(29, 45);
            this.rdbAtivo.Name = "rdbAtivo";
            this.rdbAtivo.Size = new System.Drawing.Size(65, 21);
            this.rdbAtivo.TabIndex = 0;
            this.rdbAtivo.TabStop = true;
            this.rdbAtivo.Text = "Ativo";
            this.rdbAtivo.UseVisualStyleBackColor = true;
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(317, 180);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(231, 23);
            this.txtSenha.TabIndex = 13;
            this.txtSenha.UseSystemPasswordChar = true;
            // 
            // lbSenha
            // 
            this.lbSenha.AutoSize = true;
            this.lbSenha.Location = new System.Drawing.Point(314, 160);
            this.lbSenha.Name = "lbSenha";
            this.lbSenha.Size = new System.Drawing.Size(52, 17);
            this.lbSenha.TabIndex = 12;
            this.lbSenha.Text = "Senha";
            // 
            // txtCPF
            // 
            this.txtCPF.Location = new System.Drawing.Point(317, 41);
            this.txtCPF.Mask = "000,000,000-00";
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(231, 23);
            this.txtCPF.TabIndex = 14;
            // 
            // txtTelefone
            // 
            this.txtTelefone.Location = new System.Drawing.Point(40, 180);
            this.txtTelefone.Mask = "(00) 00000-0000";
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(231, 23);
            this.txtTelefone.TabIndex = 15;
            // 
            // dtgFuncionario
            // 
            this.dtgFuncionario.AllowUserToAddRows = false;
            this.dtgFuncionario.AllowUserToDeleteRows = false;
            this.dtgFuncionario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgFuncionario.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgFuncionario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgFuncionario.Location = new System.Drawing.Point(658, 41);
            this.dtgFuncionario.Name = "dtgFuncionario";
            this.dtgFuncionario.ReadOnly = true;
            this.dtgFuncionario.RowHeadersWidth = 51;
            this.dtgFuncionario.RowTemplate.Height = 24;
            this.dtgFuncionario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgFuncionario.Size = new System.Drawing.Size(558, 226);
            this.dtgFuncionario.TabIndex = 16;
            this.dtgFuncionario.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgFuncionario_CellDoubleClick);
            // 
            // btnMostrarSenha
            // 
            this.btnMostrarSenha.BackColor = System.Drawing.Color.White;
            this.btnMostrarSenha.Location = new System.Drawing.Point(564, 180);
            this.btnMostrarSenha.Name = "btnMostrarSenha";
            this.btnMostrarSenha.Size = new System.Drawing.Size(42, 23);
            this.btnMostrarSenha.TabIndex = 17;
            this.btnMostrarSenha.Text = "..";
            this.btnMostrarSenha.UseVisualStyleBackColor = false;
            this.btnMostrarSenha.Click += new System.EventHandler(this.btnMostrarSenha_Click);
            // 
            // btnMostrarSenhaConfirmacao
            // 
            this.btnMostrarSenhaConfirmacao.BackColor = System.Drawing.Color.White;
            this.btnMostrarSenhaConfirmacao.Location = new System.Drawing.Point(564, 244);
            this.btnMostrarSenhaConfirmacao.Name = "btnMostrarSenhaConfirmacao";
            this.btnMostrarSenhaConfirmacao.Size = new System.Drawing.Size(42, 23);
            this.btnMostrarSenhaConfirmacao.TabIndex = 18;
            this.btnMostrarSenhaConfirmacao.Text = "..";
            this.btnMostrarSenhaConfirmacao.UseVisualStyleBackColor = false;
            this.btnMostrarSenhaConfirmacao.Click += new System.EventHandler(this.btnMostrarSenhaConfirmacao_Click);
            // 
            // txtConfirmarSenha
            // 
            this.txtConfirmarSenha.Location = new System.Drawing.Point(317, 244);
            this.txtConfirmarSenha.Name = "txtConfirmarSenha";
            this.txtConfirmarSenha.Size = new System.Drawing.Size(231, 23);
            this.txtConfirmarSenha.TabIndex = 20;
            this.txtConfirmarSenha.UseSystemPasswordChar = true;
            // 
            // lbConfirmarSenha
            // 
            this.lbConfirmarSenha.AutoSize = true;
            this.lbConfirmarSenha.Location = new System.Drawing.Point(314, 224);
            this.lbConfirmarSenha.Name = "lbConfirmarSenha";
            this.lbConfirmarSenha.Size = new System.Drawing.Size(126, 17);
            this.lbConfirmarSenha.TabIndex = 19;
            this.lbConfirmarSenha.Text = "Confirmar Senha";
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.BackColor = System.Drawing.Color.White;
            this.btnAtualizar.Location = new System.Drawing.Point(658, 283);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(128, 55);
            this.btnAtualizar.TabIndex = 21;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = false;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.BackColor = System.Drawing.Color.White;
            this.btnExcluir.Location = new System.Drawing.Point(870, 283);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(135, 55);
            this.btnExcluir.TabIndex = 22;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = false;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.BackColor = System.Drawing.Color.White;
            this.btnLimpar.Location = new System.Drawing.Point(1084, 283);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(132, 55);
            this.btnLimpar.TabIndex = 23;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = false;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // FormFuncionario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1228, 365);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.txtConfirmarSenha);
            this.Controls.Add(this.lbConfirmarSenha);
            this.Controls.Add(this.btnMostrarSenhaConfirmacao);
            this.Controls.Add(this.btnMostrarSenha);
            this.Controls.Add(this.dtgFuncionario);
            this.Controls.Add(this.txtTelefone);
            this.Controls.Add(this.txtCPF);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.lbSenha);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbTelefone);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lbEmail);
            this.Controls.Add(this.lbCPF);
            this.Controls.Add(this.txtDataNascimento);
            this.Controls.Add(this.dtpDataNascimento);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lbNome);
            this.Controls.Add(this.btnCadastrar);
            this.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormFuncionario";
            this.ShowIcon = false;
            this.Text = "FormFuncionario";
            this.Load += new System.EventHandler(this.FormFuncionario_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgFuncionario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.Label lbNome;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.DateTimePicker dtpDataNascimento;
        private System.Windows.Forms.Label txtDataNascimento;
        private System.Windows.Forms.Label lbCPF;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.Label lbTelefone;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbInativo;
        private System.Windows.Forms.RadioButton rdbAtivo;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label lbSenha;
        private System.Windows.Forms.MaskedTextBox txtCPF;
        private System.Windows.Forms.MaskedTextBox txtTelefone;
        private System.Windows.Forms.DataGridView dtgFuncionario;
        private System.Windows.Forms.Button btnMostrarSenha;
        private System.Windows.Forms.Button btnMostrarSenhaConfirmacao;
        private System.Windows.Forms.TextBox txtConfirmarSenha;
        private System.Windows.Forms.Label lbConfirmarSenha;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnLimpar;
    }
}