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

        private ClienteBLL clienteBLL = new ClienteBLL();
        private int idClienteASerAtualizadoExcluido = 0;
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente()
            {
                Name = txtNome.Text,
                CPF = txtCPF.Text,
                Email = txtEmail.Text,
                Birth_Day = dtpDataNascimento.Value,
                IsActive = rdbAtivo.Checked
            };

            ClienteBLL clienteBLL = new ClienteBLL();
            Response response = clienteBLL.Insert(cliente);

            if (response.Sucesso)
            {
                MessageBox.Show("Cliente cadastrado com sucesso!");
                dtgClientes.DataSource = clienteBLL.GetData();
            }
            else
            {
                MessageBox.Show(response.GetErrorMessage());
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNome.Clear();
            txtCPF.Clear();
            txtEmail.Clear();
            dtpDataNascimento.Value = DateTime.Now;
            rdbAtivo.Checked = false;
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.ID = idClienteASerAtualizadoExcluido;
            cliente.Name = txtNome.Text;
            cliente.CPF = txtNome.Text;
            cliente.Email = txtEmail.Text;
            cliente.Birth_Day = dtpDataNascimento.Value;
            cliente.IsActive = rdbAtivo.Checked;

            //Após preencher todas as propriedades do objeto Filme, passaremos
            //ele ao bll!
            Response response = clienteBLL.Update(cliente);
            if (response.Sucesso)
            {
                MessageBox.Show("Cliente atualizado com sucesso!");
                dtgClientes.DataSource = clienteBLL.GetData().Data;
            }
            else
            {
                MessageBox.Show(response.GetErrorMessage());
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Response response = clienteBLL.Delete(idClienteASerAtualizadoExcluido);
            if (response.Sucesso)
            {
                MessageBox.Show("Cliente excluído com sucesso!");
                dtgClientes.DataSource = clienteBLL.GetData().Data;
            }
            else
            {
                MessageBox.Show(response.GetErrorMessage());
            }
        }

        private void dtgClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Cliente result = (Cliente)dtgClientes.SelectedRows[0].DataBoundItem;
            DataResponse<Cliente> response = clienteBLL.GetByID(result.ID);

            if (response.Sucesso)
            {
                Cliente cliente = response.Data[0];
                idClienteASerAtualizadoExcluido = cliente.ID;
                txtNome.Text = cliente.Name;
                txtCPF.Text = cliente.CPF;
                txtEmail.Text = cliente.Email;
                dtpDataNascimento.Value = cliente.Birth_Day;
            }
        }

        private void FormCliente_Load(object sender, EventArgs e)
        {
            dtgClientes.DataSource = clienteBLL.GetData().Data;
        }
    }
}
