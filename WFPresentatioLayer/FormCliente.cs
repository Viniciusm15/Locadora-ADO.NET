using BusinessLogicalLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFPresentatioLayer
{
    public partial class FormCliente : Form
    {
        public FormCliente()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click_1(object sender, EventArgs e)
        {
            ClienteEF cliente = new ClienteEF();
            cliente.Name = txtNome.Text;
            cliente.CPF = txtCPF.Text;
            cliente.Email = txtEmail.Text;
            cliente.Birth_Day = dtpDataNascimento.Value;
            cliente.IsActive = rdbAtivo.Checked;

            ClienteService clienteBLL = new ClienteService();
            Response response = clienteBLL.Insert(cliente);

            if (response.Sucesso)
            {
                MessageBox.Show("Cliente cadastrado com sucesso!");
            }
            else
            {
                MessageBox.Show(response.GetErrorMessage());
            }
        }
    }
}
