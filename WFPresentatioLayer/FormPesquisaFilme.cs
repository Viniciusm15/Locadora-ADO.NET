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
    public partial class FormPesquisaFilme : Form
    {
        public FormPesquisaFilme()
        {
            InitializeComponent();
            this.Load += FormPesquisaFilme_Load;
            this.dtpPFilmes.CellDoubleClick += DataGridView1_CellDoubleClick;
            this.dtpPFilmes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        public Filme FilmeSelecionado { get; private set; }
        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.FilmeSelecionado = (Filme)this.dtpPFilmes.SelectedRows[0].DataBoundItem;
            this.Close();
        }

        private void FormPesquisaFilme_Load(object sender, EventArgs e)
        {
            this.dtpPFilmes.DataSource = new FilmeBLL().GetData().Data;
        }
    }
}
