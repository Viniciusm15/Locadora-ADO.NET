using BusinessLogicalLayer;
using BusinessLogicalLayer.Security;
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
    public partial class FormLocacao : Form
    {
        Cliente clienteDados = new Cliente();
        public FormLocacao()
        {
            InitializeComponent();
            this.btnPesquisaCliente.Enabled = true;
        }

        private void btnPesquisaCliente_Click(object sender, EventArgs e)
        {
            FormPesquisaCliente frmPC = new FormPesquisaCliente();
            frmPC.ShowDialog();

            if (frmPC.ClienteSelecionado != null)
            {
                Cliente cliente = frmPC.ClienteSelecionado;
                this.txtClienteID.Text = cliente.ID.ToString();
                this.txtClienteNome.Text = cliente.Name;
                this.txtClienteCPF.Text = cliente.CPF;
                clienteDados = cliente;
            }
        }

        BindingList<Filme> filmes = new BindingList<Filme>();
        private void btnPesquisarFilmes_Click(object sender, EventArgs e)
        {
            FormPesquisaFilme frmPF = new FormPesquisaFilme();
            frmPF.ShowDialog();

            if (frmPF.FilmeSelecionado != null)
            {
                Filme filme = frmPF.FilmeSelecionado;
                foreach (Filme item in filmes)
                {
                    if (item.ID.Equals(filme.ID))
                    {
                        MessageBox.Show("Filme já foi selecionado.");
                        return;
                    }
                }

                filmes.Add(filme);
                dtgFilmesSelecionados.DataSource = filmes;
            }
        }

        LocacaoBLL locacaobll = new LocacaoBLL();
        private void btnCadastrarLocacao_Click(object sender, EventArgs e)
        {
            Locacao locacao = new Locacao();
            locacao.Cliente = clienteDados;
            locacao.Funcionario = User.FuncionarioLogado;
            locacao.filmes = filmes.ToList();
            locacao.FoiPago = chkFoiPago.Checked;

            Response response = locacaobll.EfeturarLocacao(locacao);
            if (response.Sucesso)
            {
                MessageBox.Show("Locação feita com sucesso!");
            }
            else
            {
                MessageBox.Show(response.GetErrorMessage());
            }
        }
    }
}