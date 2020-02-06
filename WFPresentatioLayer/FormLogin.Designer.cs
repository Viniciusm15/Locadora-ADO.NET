namespace WFPresentatioLayer
{
    partial class FormLogin
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
            this.txtEmailLogin = new System.Windows.Forms.TextBox();
            this.btnEntrar = new System.Windows.Forms.Button();
            this.lbEmailLogin = new System.Windows.Forms.Label();
            this.lbSenhaLogin = new System.Windows.Forms.Label();
            this.txtSenhaLogin = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtEmailLogin
            // 
            this.txtEmailLogin.Location = new System.Drawing.Point(47, 55);
            this.txtEmailLogin.Name = "txtEmailLogin";
            this.txtEmailLogin.Size = new System.Drawing.Size(221, 23);
            this.txtEmailLogin.TabIndex = 0;
            // 
            // btnEntrar
            // 
            this.btnEntrar.Location = new System.Drawing.Point(82, 238);
            this.btnEntrar.Name = "btnEntrar";
            this.btnEntrar.Size = new System.Drawing.Size(155, 54);
            this.btnEntrar.TabIndex = 1;
            this.btnEntrar.Text = "Entrar";
            this.btnEntrar.UseVisualStyleBackColor = true;
            this.btnEntrar.Click += new System.EventHandler(this.btnEntrar_Click);
            // 
            // lbEmailLogin
            // 
            this.lbEmailLogin.AutoSize = true;
            this.lbEmailLogin.Location = new System.Drawing.Point(44, 26);
            this.lbEmailLogin.Name = "lbEmailLogin";
            this.lbEmailLogin.Size = new System.Drawing.Size(44, 17);
            this.lbEmailLogin.TabIndex = 2;
            this.lbEmailLogin.Text = "Email";
            // 
            // lbSenhaLogin
            // 
            this.lbSenhaLogin.AutoSize = true;
            this.lbSenhaLogin.Location = new System.Drawing.Point(44, 123);
            this.lbSenhaLogin.Name = "lbSenhaLogin";
            this.lbSenhaLogin.Size = new System.Drawing.Size(52, 17);
            this.lbSenhaLogin.TabIndex = 4;
            this.lbSenhaLogin.Text = "Senha";
            // 
            // txtSenhaLogin
            // 
            this.txtSenhaLogin.Location = new System.Drawing.Point(47, 152);
            this.txtSenhaLogin.Name = "txtSenhaLogin";
            this.txtSenhaLogin.Size = new System.Drawing.Size(221, 23);
            this.txtSenhaLogin.TabIndex = 3;
            this.txtSenhaLogin.UseSystemPasswordChar = true;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(326, 314);
            this.Controls.Add(this.lbSenhaLogin);
            this.Controls.Add(this.txtSenhaLogin);
            this.Controls.Add(this.lbEmailLogin);
            this.Controls.Add(this.btnEntrar);
            this.Controls.Add(this.txtEmailLogin);
            this.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormLogin";
            this.ShowIcon = false;
            this.Text = "FormLogin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEmailLogin;
        private System.Windows.Forms.Button btnEntrar;
        private System.Windows.Forms.Label lbEmailLogin;
        private System.Windows.Forms.Label lbSenhaLogin;
        private System.Windows.Forms.TextBox txtSenhaLogin;
    }
}