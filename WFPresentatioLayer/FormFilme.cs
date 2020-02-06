using BusinessLogicalLayer;
using Entities;
using Entities.Enums;
using Entities.ResultSets;
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
    public partial class FormFilme : Form
    {
        public FormFilme()
        {
            InitializeComponent();
        }

        private GeneroBLL generoBLL = new GeneroBLL();
        private FilmeBLL filmeBLL = new FilmeBLL();
        private int idFilmeASerAtualizadoExcluido = 0;
        private void FormFilme_Load(object sender, EventArgs e)
        {
            //O .Data retorna uma List<Genero>
            cmbGenero.DataSource = generoBLL.GetData().Data;
            cmbGenero.DisplayMember = "Nome";
            cmbGenero.ValueMember = "ID";

            //Carregando os dados do enum.
            cmbClassificacao.DataSource = Enum.GetValues(typeof(Classificacao));
            dtgFilmes.DataSource = filmeBLL.GetFilmes().Data;
            cmbFiltro.DataSource = new List<string>() { "Nome", "Classificação", "Gênero" };
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            //Em aplicações WEB, o objeto FilmeInsertViewModel é criado. O mesmo seria convertido para "Filme" antes de ir para o BLL.
            Filme filme = new Filme()
            {
                Nome = txtNome.Text,
                DataLancamento = dtpDataLancamento.Value,
                Classificacao = (Classificacao)cmbClassificacao.SelectedItem,
                Duracao = txtDuracao.Text.ToInt(),

                //O select value conversa com a propriedade ValueMember, preenchida no evento "FormLoad".
                //Neste caso, setamos o ValueMember com o valor da propriedade ID do Gênero.
                //Enquanto o .Tet da combobox nos trás o Nome do G~enero, o .SelectedValue nos Trás o ID!
                GeneroID = (int)cmbGenero.SelectedValue
            };

            FilmeBLL filmeBLL = new FilmeBLL();
            Response response = filmeBLL.Insert(filme);

            if (response.Sucesso)
            {
                MessageBox.Show("Filme cadastrado com sucesso!");
                dtgFilmes.DataSource = filmeBLL.GetFilmes().Data;
            }
            else
            {
                MessageBox.Show(response.GetErrorMessage());
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNome.Clear();
            dtpDataLancamento.Value = DateTime.Now;
            cmbClassificacao.SelectedIndex = 0;
            txtDuracao.Clear();
            cmbGenero.SelectedIndex = 0;
        }

        private void cmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Se selecionarmos gênero ou classificação, queremos deixar visível a ComboBox,
            //caso contrário, a textbox para o nome.
            if (cmbFiltro.Text == "Nome")
            {
                cmbPesquisa.Visible = false;
                txtPesquisa.Visible = true;
            }
            else
            {
                if (cmbFiltro.Text == "Gênero")
                {
                    cmbPesquisa.DataSource = null;
                    cmbPesquisa.DataSource = generoBLL.GetData().Data;
                    cmbPesquisa.DisplayMember = "Nome";
                    cmbPesquisa.ValueMember = "ID";
                }
                else
                {
                    cmbPesquisa.DataSource = null;
                    cmbPesquisa.DataSource = Enum.GetValues(typeof(Classificacao));
                }
                cmbPesquisa.Visible = true;
                txtPesquisa.Visible = false;
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            dtgFilmes.DataSource = null;
            DataResponse<FilmeResultSet> response = null;

            if (cmbFiltro.Text == "Nome")
            {
                response = filmeBLL.GetFilmesByName(txtPesquisa.Text);
            }
            else if (cmbFiltro.Text == "Gênero")
            {
                response = filmeBLL.GetFilmesByGener(((Genero)cmbPesquisa.SelectedItem).ID);
            }
            else
            {
                response = filmeBLL.GetFilmesByClassification(((Classificacao)cmbPesquisa.SelectedItem));
            }

            if (response.Sucesso)
            {
                if (response.Data.Count == 0)
                {
                    MessageBox.Show("Não foram encontrados dados!");
                }
                else
                {
                    dtgFilmes.DataSource = response.Data;
                }
            }
            else
            {
                MessageBox.Show(response.GetErrorMessage());
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            Filme filme = new Filme();
            filme.ID = idFilmeASerAtualizadoExcluido;
            filme.Duracao = txtDuracao.Text.ToInt();
            filme.Classificacao = (Classificacao)cmbClassificacao.SelectedItem;
            filme.Nome = txtNome.Text;
            filme.DataLancamento = dtpDataLancamento.Value;

            //O SelectedValue conversa com a propriedade ValueMember, preenchida
            //lá no evento Form_Load. Neste caso, setamos o ValueMember com o
            //valor da propriedade ID do Gênero. Enquanto o .Text da combobox
            //nos trás o Nome do Gênero, o .SelectedValue nos trás o ID!
            filme.GeneroID = (int)cmbGenero.SelectedValue;

            //Após preencher todas as propriedades do objeto Filme, passaremos
            //ele ao bll!
            Response response = filmeBLL.Update(filme);
            if (response.Sucesso)
            {
                MessageBox.Show("Filme atualizado com sucesso!");
                dtgFilmes.DataSource = filmeBLL.GetFilmes().Data;
            }
            else
            {
                MessageBox.Show(response.GetErrorMessage());
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Response response = filmeBLL.Delete(idFilmeASerAtualizadoExcluido);
            if (response.Sucesso)
            {
                MessageBox.Show("Filme excluído com sucesso!");
                dtgFilmes.DataSource = filmeBLL.GetFilmes().Data;
            }
            else
            {
                MessageBox.Show(response.GetErrorMessage());
            }
        }

        private void dtgFilmes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FilmeResultSet result = (FilmeResultSet)dtgFilmes.SelectedRows[0].DataBoundItem;
            DataResponse<Filme> response = filmeBLL.GetByID(result.ID);

            if (response.Sucesso)
            {
                Filme filme = response.Data[0];
                idFilmeASerAtualizadoExcluido = filme.ID;
                txtDuracao.Text = filme.Duracao.ToString();
                txtNome.Text = filme.Nome;
                dtpDataLancamento.Value = filme.DataLancamento;
                cmbClassificacao.SelectedItem = filme.Classificacao;
                cmbGenero.SelectedValue = filme.GeneroID;
            }
        }
    }
}
