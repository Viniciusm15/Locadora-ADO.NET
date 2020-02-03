using BusinessLogicalLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFPresentatioLayer
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        FuncionarioBLL funcionarioBLL = new FuncionarioBLL();
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            DataResponse<Funcionario> dataresponse = funcionarioBLL.Autenticar(txtEmailLogin.Text, txtSenhaLogin.Text);
            if (dataresponse.Sucesso)
            {
                FormMenu formMenu = new FormMenu();
                this.Hide();
                formMenu.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show(dataresponse.GetErrorMessage());
            }
        }
    }
}
