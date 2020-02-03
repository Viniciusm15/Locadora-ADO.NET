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
    public partial class FormPesquisaCliente : Form
    {
        public FormPesquisaCliente()
        {
            InitializeComponent();
            this.Load += FormPesquisaCliente_Load;
            this.dtpClientes.CellDoubleClick += DataGridView1_CellDoubleClick;
            this.dtpClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        public Cliente ClienteSelecionado { get; private set; }
        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.ClienteSelecionado = (Cliente)this.dtpClientes.SelectedRows[0].DataBoundItem;
            this.Close();
        }

        private void FormPesquisaCliente_Load(object sender, EventArgs e)
        {
            this.dtpClientes.DataSource = new ClienteBLL().GetData().Data;
        }
    }
}
