using BusinessLogicalLayer.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFPresentationLayer;

namespace WFPresentatioLayer
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        Timer timer = new Timer();
        private void cadastrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Show();
        }

        private void filmesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFilme formFil = new FormFilme();
            this.Hide();
            formFil.ShowDialog();
            this.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCliente formCli = new FormCliente();
            this.Hide();
            formCli.ShowDialog();
            this.Show();
        }

        private void funcionáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFuncionario formFun = new FormFuncionario();
            this.Hide();
            formFun.ShowDialog();
            this.Show();
        }

        private void gênerosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGenero formGen = new FormGenero();
            this.Hide();
            formGen.ShowDialog();
            this.Show();
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();

            this.toolStripStatusLabel1.Text = User.FuncionarioLogado.Name;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabel2.Text = DateTime.Now.ToString("dd/MM/yyyy - HH:mm:ss");
        }

        private void locaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLocacao formLoc = new FormLocacao();
            this.Hide();
            formLoc.ShowDialog();
            this.Show();
        }
    }
}
