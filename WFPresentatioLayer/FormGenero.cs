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

namespace WFPresentationLayer
{
    public partial class FormGenero : Form
    {
        public FormGenero()
        {
            InitializeComponent();
        }
        

        private GeneroBLL generoBLL = new GeneroBLL();
        private int idGeneroASerAtualizadoExcluido = 0;
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            //Entidade criada.
            //Formatada e validada no BLL.
            //Inserida no DAL.
            Genero genero = new Genero();
            genero.Nome = txtGenero.Text;

            GeneroBLL bll = new GeneroBLL();
            //Invoca a sequência de operações de insersão (bll depois dal)
            //Recebe a resposta destas operações.
            Response response = bll.Insert(genero);

            if (response.Sucesso)
            {
                MessageBox.Show("Cadastrado com sucesso!");
                dtgGenero.DataSource = generoBLL.GetData().Data;
            }
            else 
            {
                MessageBox.Show(response.GetErrorMessage());
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            Genero genero = new Genero();
            genero.ID = idGeneroASerAtualizadoExcluido;
            genero.Nome = txtGenero.Text;
            
            //Após preencher todas as propriedades do objeto Gênero, passaremos
            //ele ao bll!
            Response response = generoBLL.Update(genero);
            if (response.Sucesso)
            {
                MessageBox.Show("Gênero atualizado com sucesso!");
                dtgGenero.DataSource = generoBLL.GetData().Data;
            }
            else
            {
                MessageBox.Show(response.GetErrorMessage());
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Response response = generoBLL.Delete(idGeneroASerAtualizadoExcluido);
            if (response.Sucesso)
            {
                MessageBox.Show("Gênero excluído com sucesso!");
                dtgGenero.DataSource = generoBLL.GetData().Data;
            }
            else
            {
                MessageBox.Show(response.GetErrorMessage());
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtGenero.Clear();
        }

        private void FormGenero_Load(object sender, EventArgs e)
        {
            dtgGenero.DataSource = generoBLL.GetData().Data;
        }

        private void dtgGenero_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Genero result = (Genero)dtgGenero.SelectedRows[0].DataBoundItem;
            DataResponse<Genero> response = generoBLL.GetByID(result.ID);

            if (response.Sucesso)
            {
                Genero genero = response.Data[0];
                idGeneroASerAtualizadoExcluido = genero.ID;
                txtGenero.Text = genero.Nome;
            }
        }
    }
}
