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
    public partial class FormFuncionario : Form
    {
        public FormFuncionario()
        {
            InitializeComponent();
        }

        private FuncionarioBLL funcionarioBLL = new FuncionarioBLL();
        private int idFuncionarioASerAtualizadoExcluido = 0;
        private void btnCadastrar_Click(object sender, EventArgs e)
        {

            if (txtConfirmarSenha.Text != txtSenha.Text)
            {
                MessageBox.Show("Senhas diferentes");
                return;
            }

            Funcionario funcionario = new Funcionario()
            {
                Name = txtNome.Text,
                BirthDate = dtpDataNascimento.Value,
                CPF = txtCPF.Text,
                Email = txtEmail.Text,
                Telephone = txtTelefone.Text,
                Password = txtSenha.Text
            };

            FuncionarioBLL funcionarioBLL = new FuncionarioBLL();
            Response response = funcionarioBLL.Insert(funcionario);

            if (response.Sucesso)
            {
                MessageBox.Show("Funcionário cadastrado com sucesso!");
                dtgFuncionario.DataSource = funcionarioBLL.GetData();
            }
            else
            {
                MessageBox.Show(response.GetErrorMessage());
            }
        }

        private void btnMostrarSenha_Click(object sender, EventArgs e)
        {
            if (txtSenha.UseSystemPasswordChar)
            {
                txtSenha.UseSystemPasswordChar = false;
            }
            else
            {
                txtSenha.UseSystemPasswordChar = true;
            }
        }

        private void btnMostrarSenhaConfirmacao_Click(object sender, EventArgs e)
        {
            if (txtConfirmarSenha.UseSystemPasswordChar)
            {
                txtConfirmarSenha.UseSystemPasswordChar = false;
            }
            else
            {
                txtConfirmarSenha.UseSystemPasswordChar = true;
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            Funcionario funcionario = new Funcionario();
            funcionario.ID = idFuncionarioASerAtualizadoExcluido;
            funcionario.Name = txtNome.Text;
            funcionario.BirthDate = dtpDataNascimento.Value;
            funcionario.CPF = txtCPF.Text;
            funcionario.Email = txtEmail.Text;
            funcionario.Telephone = txtTelefone.Text;
            funcionario.Password = txtSenha.Text;
            funcionario.IsActive = rdbAtivo.Checked;

            //Após preencher todas as propriedades do objeto Funcionario, passaremos
            //ele ao bll!
            Response response = funcionarioBLL.Update(funcionario);
            if (response.Sucesso)
            {
                MessageBox.Show("Funcionário atualizado com sucesso!");
                dtgFuncionario.DataSource = funcionarioBLL.GetData().Data;
            }
            else
            {
                MessageBox.Show(response.GetErrorMessage());
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Response response = funcionarioBLL.Delete(idFuncionarioASerAtualizadoExcluido);
            if (response.Sucesso)
            {
                MessageBox.Show("Funcionário excluído com sucesso!");
                dtgFuncionario.DataSource = funcionarioBLL.GetData().Data;
            }
            else
            {
                MessageBox.Show(response.GetErrorMessage());
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNome.Clear();
            dtpDataNascimento.Value = DateTime.Now;
            txtTelefone.Clear();
            txtCPF.Clear();
            txtEmail.Clear();
            txtSenha.Clear();
            rdbAtivo.Checked = false; ;
        }

        private void dtgFuncionario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Funcionario result = (Funcionario)dtgFuncionario.SelectedRows[0].DataBoundItem;
            DataResponse<Funcionario> response = funcionarioBLL.GetByID(result.ID);

            if (response.Sucesso)
            {
                Funcionario funcionario = response.Data[0];
                idFuncionarioASerAtualizadoExcluido = funcionario.ID;
                txtNome.Text = funcionario.Name;
                dtpDataNascimento.Value = funcionario.BirthDate;
                txtCPF.Text = funcionario.CPF;
                txtEmail.Text = funcionario.Email;
                txtTelefone.Text = funcionario.Telephone;
                txtSenha.Text = funcionario.Password;
                rdbAtivo.Checked = funcionario.IsActive;
            }
        }

        private void FormFuncionario_Load(object sender, EventArgs e)
        {
            dtgFuncionario.DataSource = funcionarioBLL.GetData().Data;
        }
    }
}
